using System.Collections.Generic;
using System.Linq;
using Improbable.Gdk.CodeGeneration.CodeWriter;
using Improbable.Gdk.CodeGeneration.CodeWriter.Scopes;
using Improbable.Gdk.CodeGeneration.Model.Details;
using NLog;

namespace Improbable.Gdk.CodeGenerator
{
    public static class UnityTypeContent
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static TypeBlock Generate(UnityTypeDetails details, string typeNamespace)
        {
            var nestedTypes = details.ChildTypes;
            var nestedEnums = details.ChildEnums;

            var typeDetails = details;
            var fieldDetailsList = details.FieldDetails;
            var hasPartial = PartialDatabase.TryGetPartial(typeDetails.GetPartialResourceTypeName(), out var partial);

            Logger.Trace($"Generating {typeNamespace}.{typeDetails.CapitalisedName} struct.");

            return Scope.AnnotatedType("global::System.Serializable",
                $"public struct {typeDetails.CapitalisedName}", s =>
                {
                    if (fieldDetailsList.Count > 0)
                    {
                        s.Line(fieldDetailsList
                            .Select(fd => $"public {fd.Type} {fd.PascalCaseName};")
                            .ToList());

                        var constructorArgs = GetConstructorArgs(fieldDetailsList);

                        s.Method($"public {typeDetails.CapitalisedName}({constructorArgs})", m =>
                        {
                            m.Line(sb =>
                            {
                                foreach (var fd in fieldDetailsList)
                                {
                                    sb.AppendLine($"{fd.PascalCaseName} = {fd.CamelCaseName};");
                                }
                            });
                        });
                    }

                    if (hasPartial)
                    {
                        s.Line(partial);
                    }

                    s.Type(GenerateSerializationClass(typeDetails));

                    foreach (var nestedType in nestedTypes)
                    {
                        s.Type(Generate(nestedType, $"{typeNamespace}.{typeDetails.CapitalisedName}"));
                    }

                    foreach (var nestedEnum in nestedEnums)
                    {
                        s.Enum(UnityEnumContent.Generate(nestedEnum, $"{typeNamespace}.{typeDetails.CapitalisedName}"));
                    }
                });
        }

        private static TypeBlock GenerateSerializationClass(UnityTypeDetails typeDetails)
        {
            var fieldDetails = typeDetails.FieldDetails;

            return Scope.Type("public static class Serialization", s =>
            {
                s.Method($"public static void Serialize({typeDetails.CapitalisedName} instance, global::Improbable.Worker.CInterop.SchemaObject obj)",
                    serializeMethod =>
                    {
                        if (typeDetails.HasSerializationOverride)
                        {
                            serializeMethod.CustomScope(() => new[]
                            {
                                typeDetails.SerializationOverride.GetSerializationString("instance", "obj")
                            });
                        }
                        else
                        {
                            foreach (var fieldDetail in fieldDetails)
                            {
                                serializeMethod.CustomScope(() => new[]
                                {
                                    fieldDetail.GetSerializationString($"instance.{fieldDetail.PascalCaseName}", "obj", 0)
                                });
                            }
                        }
                    });

                s.Method($"public static {typeDetails.CapitalisedName} Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj)",
                    deserializeMethod =>
                    {
                        if (typeDetails.HasSerializationOverride)
                        {
                            var deserializeString = typeDetails.SerializationOverride.GetDeserializeString("obj");
                            deserializeMethod.Return(deserializeString);
                        }
                        else
                        {
                            deserializeMethod.Line($"var instance = new {typeDetails.CapitalisedName}();");

                            foreach (var fieldDetail in fieldDetails)
                            {
                                deserializeMethod.CustomScope(() => new[]
                                {
                                    fieldDetail.GetDeserializeString($"instance.{fieldDetail.PascalCaseName}", "obj", 0)
                                });
                            }

                            deserializeMethod.Return("instance");
                        }
                    });
            });
        }

        private static string GetConstructorArgs(IEnumerable<UnityFieldDetails> fieldDetailsList)
        {
            var constructorArgsList = fieldDetailsList
                .Select(fieldDetails => $"{fieldDetails.Type} {fieldDetails.CamelCaseName}");
            return string.Join(", ", constructorArgsList);
        }
    }
}
