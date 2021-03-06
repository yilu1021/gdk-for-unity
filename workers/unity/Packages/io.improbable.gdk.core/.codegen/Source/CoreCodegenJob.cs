using System.Collections.Generic;
using System.IO;
using System.Linq;
using Improbable.Gdk.CodeGeneration.FileHandling;
using Improbable.Gdk.CodeGeneration.Jobs;
using Improbable.Gdk.CodeGeneration.Model.Details;

namespace Improbable.Gdk.CodeGenerator.Core
{
    public class CoreCodegenJob : CodegenJob
    {
        private readonly List<GenerationTarget<UnityComponentDetails>> componentsToGenerate;

        private readonly List<GenerationTarget<UnityTypeDetails>> typesToGenerate;

        private readonly List<GenerationTarget<UnityEnumDetails>> enumsToGenerate;

        private const string FileExtension = ".cs";

        public CoreCodegenJob(string outputDir, IFileSystem fileSystem, DetailsStore store, bool force)
            : base(outputDir, fileSystem, store, force)
        {
            var jobName = nameof(CoreCodegenJob);
            logger.Info($"Initialising {jobName}.");

            AddInputFiles(store.SchemaFiles.ToList());

            logger.Info("Gathering nested types.");
            var allNestedTypes = store.Types
                .SelectMany(kv => store.GetNestedTypes(kv.Key))
                .ToHashSet();

            logger.Info("Gathering types details.");
            typesToGenerate = store.Types
                .Where(kv => !allNestedTypes.Contains(kv.Key))
                .Select(kv => new GenerationTarget<UnityTypeDetails>(kv.Value, kv.Value.Package))
                .ToList();

            logger.Info("Gathering enum details.");
            enumsToGenerate = store.Enums
                .Where(kv => !allNestedTypes.Contains(kv.Key))
                .Select(kv => new GenerationTarget<UnityEnumDetails>(kv.Value, kv.Value.Package))
                .ToList();

            logger.Info("Gathering component details.");
            componentsToGenerate = store.Components
                .Select(kv => new GenerationTarget<UnityComponentDetails>(kv.Value, kv.Value.Package))
                .ToList();

            logger.Trace("Adding job output files for types.");
            foreach (var typeTarget in typesToGenerate)
            {
                logger.Trace($"Adding output file for type {typeTarget.Content.QualifiedName}.");

                var fileName = Path.ChangeExtension(typeTarget.Content.CapitalisedName, FileExtension);
                AddOutputFile(Path.Combine(typeTarget.OutputPath, fileName));
            }

            logger.Info($"Added output files for {typesToGenerate.Count} types.");

            logger.Trace("Adding job output files for components.");
            foreach (var componentTarget in componentsToGenerate)
            {
                var relativeOutputPath = componentTarget.OutputPath;
                var componentName = componentTarget.Content.ComponentName;

                logger.Trace($"Adding job output files for component {componentTarget.Content.QualifiedName}.");

                AddOutputFile(Path.Combine(relativeOutputPath, Path.ChangeExtension(componentTarget.Content.ComponentName, FileExtension)));

                if (componentTarget.Content.CommandDetails.Count > 0)
                {
                    logger.Trace("Adding job output files for commands.");

                    AddOutputFile(Path.Combine(relativeOutputPath,
                        Path.ChangeExtension($"{componentName}CommandPayloads", FileExtension)));
                    AddOutputFile(Path.Combine(relativeOutputPath,
                        Path.ChangeExtension($"{componentName}CommandComponents", FileExtension)));
                    AddOutputFile(Path.Combine(relativeOutputPath,
                        Path.ChangeExtension($"{componentName}CommandDiffDeserializer", FileExtension)));
                    AddOutputFile(Path.Combine(relativeOutputPath,
                        Path.ChangeExtension($"{componentName}CommandDiffStorage", FileExtension)));
                    AddOutputFile(Path.Combine(relativeOutputPath,
                        Path.ChangeExtension($"{componentName}CommandMetaDataStorage", FileExtension)));
                }

                if (componentTarget.Content.EventDetails.Count > 0)
                {
                    logger.Trace("Adding job output file for events.");

                    AddOutputFile(Path.Combine(relativeOutputPath,
                        Path.ChangeExtension($"{componentName}Events", FileExtension)));
                }

                AddOutputFile(Path.Combine(relativeOutputPath,
                    Path.ChangeExtension($"{componentName}UpdateSender", FileExtension)));
                AddOutputFile(Path.Combine(relativeOutputPath,
                    Path.ChangeExtension($"{componentName}EcsViewManager", FileExtension)));
                AddOutputFile(Path.Combine(relativeOutputPath,
                    Path.ChangeExtension($"{componentName}ComponentDiffStorage", FileExtension)));
                AddOutputFile(Path.Combine(relativeOutputPath,
                    Path.ChangeExtension($"{componentName}ComponentDiffDeserializer", FileExtension)));
                AddOutputFile(Path.Combine(relativeOutputPath,
                    Path.ChangeExtension($"{componentName}Providers", FileExtension)));
                AddOutputFile(Path.Combine(relativeOutputPath,
                    Path.ChangeExtension($"{componentName}ViewStorage", FileExtension)));
                AddOutputFile(Path.Combine(relativeOutputPath,
                    Path.ChangeExtension($"{componentName}Metaclass", FileExtension)));
            }

            logger.Info($"Added output files for {componentsToGenerate.Count} components.");

            logger.Trace("Adding job output files for enums.");
            foreach (var enumTarget in enumsToGenerate)
            {
                logger.Trace($"Adding job output file for enum {enumTarget.Content.QualifiedName}.");

                var fileName = Path.ChangeExtension(enumTarget.Content.TypeName, FileExtension);
                AddOutputFile(Path.Combine(enumTarget.OutputPath, fileName));
            }

            logger.Info($"Added output files for {enumsToGenerate.Count} enums.");
            logger.Info($"Finished initialising {jobName}.");
        }

        protected override void RunImpl()
        {
            logger.Trace("Starting code generation for enums.");
            foreach (var enumTarget in enumsToGenerate)
            {
                logger.Trace($"Generating code for {enumTarget.Content.QualifiedName}.");

                var fileName = Path.ChangeExtension(enumTarget.Content.TypeName, FileExtension);
                var enumCode = UnityEnumGenerator.Generate(enumTarget.Content, enumTarget.Package);
                AddContent(Path.Combine(enumTarget.OutputPath, fileName), enumCode);
            }

            logger.Info($"Finished code generation for {enumsToGenerate.Count} enums.");

            logger.Trace("Starting code generation for types.");
            foreach (var typeTarget in typesToGenerate)
            {
                logger.Trace($"Generating code for {typeTarget.Content.QualifiedName}.");

                var fileName = Path.ChangeExtension(typeTarget.Content.CapitalisedName, FileExtension);
                var typeCode = UnityTypeGenerator.Generate(typeTarget.Content, typeTarget.Package);
                AddContent(Path.Combine(typeTarget.OutputPath, fileName), typeCode);
            }

            logger.Info($"Finished code generation for {typesToGenerate.Count} types.");

            logger.Trace("Starting code generation for components.");
            foreach (var componentTarget in componentsToGenerate)
            {
                logger.Trace($"Generating code for {componentTarget.Content.QualifiedName}.");

                var relativeOutputPath = componentTarget.OutputPath;
                var componentName = componentTarget.Content.ComponentName;
                var package = componentTarget.Package;

                var componentFileName = Path.ChangeExtension(componentName, FileExtension);
                var componentCode = UnityComponentDataGenerator.Generate(componentTarget.Content, package);
                AddContent(Path.Combine(relativeOutputPath, componentFileName), componentCode);

                if (componentTarget.Content.CommandDetails.Count > 0)
                {
                    logger.Trace("Generating code for commands.");

                    var commandPayloadsFileName =
                        Path.ChangeExtension($"{componentName}CommandPayloads", FileExtension);
                    var commandPayloadCode =
                        UnityCommandPayloadGenerator.Generate(componentTarget.Content, package);
                    AddContent(Path.Combine(relativeOutputPath, commandPayloadsFileName), commandPayloadCode);

                    var commandDiffDeserializerFileName =
                        Path.ChangeExtension($"{componentName}CommandDiffDeserializer", FileExtension);
                    var commandDiffDeserializerCode =
                        CommandDiffDeserializerGenerator.Generate(componentTarget.Content, package);
                    AddContent(Path.Combine(relativeOutputPath, commandDiffDeserializerFileName),
                        commandDiffDeserializerCode);

                    var commandDiffStorageFileName =
                        Path.ChangeExtension($"{componentName}CommandDiffStorage", FileExtension);
                    var commandDiffStorageCode =
                        CommandDiffStorageGenerator.Generate(componentTarget.Content, package);
                    AddContent(Path.Combine(relativeOutputPath, commandDiffStorageFileName),
                        commandDiffStorageCode);

                    var commandMetaDataStorageFileName =
                        Path.ChangeExtension($"{componentName}CommandMetaDataStorage", FileExtension);
                    var commandMetaDataStorageCode =
                        CommandMetaDataStorageGenerator.Generate(componentTarget.Content, package);
                    AddContent(Path.Combine(relativeOutputPath, commandMetaDataStorageFileName),
                        commandMetaDataStorageCode);
                }

                if (componentTarget.Content.EventDetails.Count > 0)
                {
                    logger.Trace("Generating code for events.");

                    var eventsFileName = Path.ChangeExtension($"{componentName}Events", FileExtension);
                    var eventsCode = UnityEventGenerator.Generate(componentTarget.Content, package);
                    AddContent(Path.Combine(relativeOutputPath, eventsFileName), eventsCode);
                }

                var updateSenderFileName = Path.ChangeExtension($"{componentName}UpdateSender", FileExtension);
                var updateSenderCode = UnityComponentSenderGenerator.Generate(componentTarget.Content, package);
                AddContent(Path.Combine(relativeOutputPath, updateSenderFileName), updateSenderCode);

                var ecsViewManagerFileName = Path.ChangeExtension($"{componentName}EcsViewManager", FileExtension);
                var ecsViewManagerCode = UnityEcsViewManagerGenerator.Generate(componentTarget.Content, package);
                AddContent(Path.Combine(relativeOutputPath, ecsViewManagerFileName), ecsViewManagerCode);

                var componentDiffStorageFileName = Path.ChangeExtension($"{componentName}ComponentDiffStorage", FileExtension);
                var componentDiffStorageCode = ComponentDiffStorageGenerator.Generate(componentTarget.Content, package);
                AddContent(Path.Combine(relativeOutputPath, componentDiffStorageFileName), componentDiffStorageCode);

                var componentDiffDeserializerFileName = Path.ChangeExtension($"{componentName}ComponentDiffDeserializer", FileExtension);
                var componentDiffDeserializerCode = ComponentDiffDeserializerGenerator.Generate(componentTarget.Content, package);
                AddContent(Path.Combine(relativeOutputPath, componentDiffDeserializerFileName), componentDiffDeserializerCode);

                if (componentTarget.Content.FieldDetails.Any(field => !field.IsBlittable))
                {
                    logger.Trace("Generating code for non-blittable fields.");

                    var referenceProviderFileName = Path.ChangeExtension($"{componentName}Providers", FileExtension);
                    var referenceProviderTranslationCode =
                        UnityReferenceTypeProviderGenerator.Generate(componentTarget.Content, package);
                    AddContent(Path.Combine(relativeOutputPath, referenceProviderFileName),
                        referenceProviderTranslationCode);
                }

                var viewStorageFileName = Path.ChangeExtension($"{componentName}ViewStorage", FileExtension);
                var viewStorageCode = ViewStorageGenerator.Generate(componentTarget.Content, package);
                AddContent(Path.Combine(relativeOutputPath, viewStorageFileName), viewStorageCode);

                var metaclassFileName = Path.ChangeExtension($"{componentName}Metaclass", FileExtension);
                var metaclassCode = MetaclassGenerator.Generate(componentTarget.Content, package);
                AddContent(Path.Combine(relativeOutputPath, metaclassFileName), metaclassCode);
            }

            logger.Info($"Finished code generation for {componentsToGenerate.Count} components.");
        }
    }
}
