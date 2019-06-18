# Untitled

Title: Deployment manager read me

Date: 2019-feb-19

Status: rough draft

Author: Laura H

SME: Jess  
Version: 3

Intel from Jess on Slack: [https://improbable.slack.com/archives/D9V9LUB0W/p1550679968000600](https://www.google.com/url?q=https://improbable.slack.com/archives/D9V9LUB0W/p1550679968000600&sa=D&ust=1560855034164000)  
See also: design doc: [https://docs.google.com/document/d/1bvv69dXE015ZpeWnc8oeQqGlJMB237zHwpmCj3Hq-CQ/edit\#](https://www.google.com/url?q=https://docs.google.com/document/d/1bvv69dXE015ZpeWnc8oeQqGlJMB237zHwpmCj3Hq-CQ/edit%23&sa=D&ust=1560855034165000)

See also: white board image  \(Laura’s phone\)

Filename: README.md

## \# SpatialOS Deployment Manager[\[a\]]()[\[b\]]()[\[c\]]() <a id="h.tsfhuggkedi6"></a>

\* Repo: [https://github.com/improbable/deployment-manager](https://www.google.com/url?q=https://github.com/improbable/deployment-manager&sa=D&ust=1560855034166000)

\* License: [MIT license](https://www.google.com/url?q=https://github.com/spatialos/deployment-manager/blob/master/LICENSE.md&sa=D&ust=1560855034166000)

\* System requirements:  See SpatialOS [Worker SDK system requirements](https://www.google.com/url?q=https://docs.improbable.io/reference/13.7/shared/setup/requirements&sa=D&ust=1560855034167000) documentation  
\* Compatible with SpatialOS development kits:    

      \* \*\*GDK for Unreal\*\*

      \* \*\*GDK for Unity\*\*

      \* \*\*Worker SDK and Platform SDK\*\*         

\* Supporting documentation:  
     \* \[GDK for Unreal\]\([https://docs.improbable.io/unreal/latest](https://www.google.com/url?q=https://docs.improbable.io/unreal/latest&sa=D&ust=1560855034168000)\)

     \* \[GDK for Unity\]\([https://docs.improbable.io/unity/latest](https://www.google.com/url?q=https://docs.improbable.io/unity/latest&sa=D&ust=1560855034168000)\)

     \* \[SpatialOS Worker SDK and Platform SDK\]\([https://docs.improbable.io/reference/latest/index](https://www.google.com/url?q=https://docs.improbable.io/reference/latest/index&sa=D&ust=1560855034168000)\) \(Links to definitions in this readme are to the glossary in this set of documentation.\)

The SpatialOS Deployment Manager is a \[SpatialOS\]\(https://docs.improbable.io/reference/latest/index\) game management tool. It starts and stops \[game deployments\]\(https://docs.improbable.io/reference/latest/shared/glossary\#deploying\) - instances of your game running in SpatialOS. It’s useful for player-limited and time-limited match-based games such as battle royales where you have multiple game sessions, with a defined number of players.

### \#\# Overview <a id="h.gm57ophqs4n4"></a>

The Deployment Manager is a C\# SpatialOS project. You \[set it up and deploy it\]\(\#how-to-set-it-up-for-your-g        ame\) separately to setting up and deploying your game project.

Once set up and deployed, the Deployment Manager starts and stops multiple deployments of your game: Every deployment of your game which it can start and stop is a separate game instance with its own SpatialOS \[game world\]\([https://docs.improbable.io/reference/latest/shared/glossary\#spatialos-world](https://www.google.com/url?q=https://docs.improbable.io/reference/latest/shared/glossary%23spatialos-world&sa=D&ust=1560855034169000)\).  
&lt;br/&gt;  
\*\*Note\*\*: The Deployment Manager does not manage its own deployment; you have to manually start and stop the Deployment Manager as it only starts and stops game deployments.

The Deployment Manager is one \[worker\]\(https://docs.improbable.io/reference/latest/shared/glossary\#worker\) instance.

![](.gitbook/assets/image1.png)

\_Conceptual organization of a Deployment Manager and a game’s deployments\_

### \#\# How to set your game with the Deployment Manager <a id="h.24v5rspqczee"></a>

#### \#\#\# Overview <a id="h.85pvjamsejdv"></a>

There are two elements to preparing your Deployment Manager:

**\#\#\#\# Configure a Deployment Manager project\[d\]**

Inside your Deployment Manager project, there is a \`deploymentmanager/config.json\` file containing the configuration for your Deployment Manager. Use this to configure the Deployment Manager and your game deployments.

**\#\#\#\# Add a deployment state entity to your game project**

Add an entity type to act as a Deployment State Entity to your game.  
The Deployment Manager then gets updates on the components in the Deployment State Entity in each of your running game deployments.

\*\*\_ExampleDeployment State Entity\_\*\*

  
\* \*\*GDK for Unity\*\*: Deployment State Entity template in the \[FPS Starter Project\]\([https://github.com/spatialos/gdk-for-unity-fps-starter-project/blob/master/workers/unity/Assets/Fps/Scripts/Config/FpsEntityTemplates.cs\#L19](https://www.google.com/url?q=https://github.com/spatialos/gdk-for-unity-fps-starter-project/blob/master/workers/unity/Assets/Fps/Scripts/Config/FpsEntityTemplates.cs%23L19&sa=D&ust=1560855034172000)\).

\* \*\*GDK for Unreal\*\*:  Deployment State Entity template in the \[Example Project\]\([https://github.com/spatialos/UnrealGDKExampleProject](https://www.google.com/url?q=https://github.com/improbable/UnrealGDKExampleProject&sa=D&ust=1560855034172000)\).  
\[//\]: \# \(TODO: Fix this liatialos/gdk-for-unity-fps-starter-project/blob/develop/workers/unity/Assets/Fps/nk when it’s in the public repo - needs to link to the Deployment State Entity template.\)  
[\[e\]]()[\[f\]]()

**\#\#\#\# Example of a Deployment Manager integrated with a game**

There is an example implementation of a Deployment Manager in a GDK for Unreal project and a GDK for Unity project:  


\* \*\*GDK for Unity\*\*: \[FPS Starter Project guide on the GDK for Unity documentation website\]\([https://github.com/spatialos/gdk-for-unity-fps-starter-project](https://www.google.com/url?q=https://github.com/spatialos/gdk-for-unity-fps-starter-project&sa=D&ust=1560855034173000)\)  


\* \*\*GDK for Unreal\*\*: \[Example Project on GitHub\]\([https://github.com/spatialos/UnrealGDKExampleProject](https://www.google.com/url?q=https://github.com/improbable/UnrealGDKExampleProject&sa=D&ust=1560855034173000)\)  
\[//\]: \# \(TODO: Fix this link when it’s in the public repo.\)[\[g\]]()[\[h\]]()[\[i\]]()

####  \#\#\# Steps <a id="h.wo4az5hhhp9s"></a>

**\#\#\#\# 1. Download and set up a Deployment Manager project**

1. Clone the \[Deployment Manager project\]\(https://github.com/spatialos/deployment-manager\). 
2. Run a script to download and build the SpatialOS dependencies. To do this, in a command line or terminal window, from the root directory of the cloned Deployment Manager project, enter: 

&lt;br/&gt;\*\*Windows\*\*

  
\`\`\`

powershell ./build-nuget-packages.ps1

\`\`\`

&lt;br/&gt; \*\*Mac\*\*

\`\`\`

./build-nuget-packages.sh

\`\`\`

1. You need to generate a service account token. The service account token enables the Deployment Manager to list, start and stop deployments in your SpatialOS project.  
   \(See SpatialOS documentation on \[development authentification\]\([https://docs.improbable.io/reference/latest/shared/auth/development-authentication](https://www.google.com/url?q=https://docs.improbable.io/reference/latest/shared/auth/development-authentication&sa=D&ust=1560855034175000)\) for more details on tokens.\)  &lt;/br&gt;

   Togenerate the token, from the root directory of the cloned Deployment Manager project, open a command line or terminal window and enter:  

&lt;br/&gt;\*\*Windows\*\*

  
\`\`\`

powershell ./generate-service-account-token.ps1 &lt;your SpatialOS project name&gt; &lt;token life time in days&gt;

\`\`\`

&lt;br/&gt; \*\*Mac\*\*

\`\`\`

./generate-service-account-token.sh &lt;your SpatialOS project name&gt; &lt;token life time in days&gt;[\[j\]]()[\[k\]]()[\[l\]]()[\[m\]]()[\[n\]]()

\`\`\`

This automatically generates and adds a service account token to your Deployment Manager project. You do not need to make a note of the token or add it to the project manually.

**\#\#\#\# 2. Set up and launch your game**

1. Add an entity template to act as a Deployment State Entity to your game project. &lt;br/&gt; \(See examples in the projects in the \[Overview\]\(\#Overview\) section above.\)  
2. Add a worker configuration file \(\`spatialos.DeploymentManager.worker.json\`\) for the Deployment Manager worker type to your game project. &lt;br/&gt; \(You can copy the worker configuration file examples in the projects \[Overview\]\(\#Overview\) section above.\)
3. Go through the usual workflow to deploy your game locally or to the cloud. See: \* the GDK for Unreal \[local deployment\]\([https://docs.improbable.io/unreal/latest/content/local-deployment-workflow](https://www.google.com/url?q=https://docs.improbable.io/unreal/alpha/content/local-deployment-workflow&sa=D&ust=1560855034176000)\) and \[cloud deployment\]\([https://docs.improbable.io/unreal/alpha/content/cloud-deployment-workflow](https://www.google.com/url?q=https://docs.improbable.io/unreal/alpha/content/cloud-deployment-workflow&sa=D&ust=1560855034176000)\) workflow summaries. \* the GDK for Unity FPS Starter Project guide to \[Build your workers\]\([https://docs-staging.improbable.io/unity/latest/projects/fps/get-started/build-workers](https://www.google.com/url?q=https://docs-staging.improbable.io/unity/alpha/projects/fps/get-started/build-workers&sa=D&ust=1560855034177000)\) and \[Upload & launch your game\]\([https://docs-staging.improbable.io/unity/latest/projects/fps/get-started/upload-launch](https://www.google.com/url?q=https://docs-staging.improbable.io/unity/alpha/projects/fps/get-started/upload-launch&sa=D&ust=1560855034177000)\) \* the SpatialOS SDKs documentation on \[deploying locally\]\([https://docs-staging.improbable.io/reference/latest/shared/deploy/deploy-local](https://www.google.com/url?q=https://docs-staging.improbable.io/reference/13.6/shared/deploy/deploy-local&sa=D&ust=1560855034177000)\) and \[deploying to the cloud\]\([https://docs-staging.improbable.io/reference/latest/shared/deploy/deploy-cloud](https://www.google.com/url?q=https://docs-staging.improbable.io/reference/13.6/shared/deploy/deploy-local&sa=D&ust=1560855034177000)\).   

**\#\#\#\# 3. Configure and Launch the Deployment Manager**  


1. Update the configuration: navigate to the deployment-manager/DeploymentManager/ directory and, in a text editor, edit the config.json file as shown below:

   \*\`"ClientType": “&lt;edit this&gt;”\` is your SpatialOS development platform’s game client type, for example,  \`”UnityClient"\` or  \`"UnrealClient"\`.  
   \*  \`"NumberOfDeployments": “&lt;edit this&gt;”\` is the number of game deployments you want to launch.  
   \* \`"AssemblyName": “&lt;edit this&gt;”\` is the name of the assembly you uploaded to the cloud in step 2. This enables the Deployment Manager to launch deployments using this assembly.  

2. Launch your Deployment Manager locally on your computer or to the cloud. To do this, follow the steps below.

**\#\#\#\#\# Launch the Deployment Manager locally on your computer**

Open a command line or terminal window and enter:

\*\*\_Windows\_\*\*&lt;br/&gt;

\`\`\`

powershell ./publish-windows-workers.ps1 &lt;game launch config path&gt; &lt;game snapshot path&gt;

powershell ./local-launch.ps1

\`\`\`

\*\*\_Mac\_\*\*&lt;br/&gt;

\`\`\`

./publish-macos-workers.sh &lt;game launch config path&gt; &lt;game snapshot path&gt;

./local-launch.sh

\`\`\`

**\#\#\#\#\# Launch the Deployment Manager in the cloud**

Open a command line or terminal window and enter:

\*\*\_Windows\_\*\*&lt;br/&gt;

\`\`\`

powershell ./publish-linux-workers.ps1 &lt;game launch config path&gt; &lt;game snapshot path&gt;

powershell ./cloud-launch.ps1 &lt;Deployment Manager assembly name&gt; &lt;Deployment Manager deployment name&gt;

\`\`\`

\*\*\_Mac\_\*\*&lt;br/&gt;

\`\`\`

sh./publish-linux-workers.sh &lt;game launch config path&gt; &lt;game snapshot path&gt;

sh ./cloud-launch.sh &lt;Deployment Manager assembly name&gt; &lt;Deployment Manager deployment name&gt;  
\`\`\`

[\[a\]]()I think it's become "Deployment Manager" but the project isn't a proper noun.

[\[b\]]()not sure I'm following

[\[c\]]()It's ended up being a Proper Noun  \(Deployment Manager\) but a deployement manager project isn't. \(I know, it's a mare.\)

[\[d\]]()the deployment manager project isn't a proper noun.

[\[e\]]()We are going to add this later.

[\[f\]]()This link ain't gonna work.

[\[g\]]()We are going to add this later.

[\[h\]]()This link ain't gonna work

[\[i\]]()is it public now?

[\[j\]]()Make this a table?

[\[k\]]()If you fancy.

[\[l\]]()There's a few below could be table-ized. It's just a bit of a fiddle.

[\[m\]]()Maybe worth doing when converting into Markdown? Rather than here

[\[n\]]()yeah, will table-ize them when converting into markdown

