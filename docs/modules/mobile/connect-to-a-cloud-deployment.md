---
description: What happens if I add a page description I wonder?
---

# Connect to a cloud deployment

{% hint style="info" %}
Before reading this document, make sure you have read:

* [Setting up Android support for the GDK](https://docs.improbable.io/unity/alpha/modules/mobile/setup-android)
* [Setting up iOS support for the GDK](https://docs.improbable.io/unity/alpha/modules/mobile/setup-ios)
* [Development authentication flow](https://docs.improbable.io/reference/latest/shared/auth/development-authentication)
{% endhint %}

To connect your mobile device to a cloud deployment, you need to authenticate with our services.

This guide describes how to authenticate using the [development authentication flow](https://docs.improbable.io/reference/latest/shared/auth/development-authentication) which we provide for the early stages of game development.

### Start a cloud deployment[\#](https://docs.improbable.io/unity/alpha/modules/mobile/cloud-deploy#start-a-cloud-deployment) <a id="start-a-cloud-deployment"></a>

The development authentication flow allows you to connect deployments that have the deployment tag `dev_login`. The following steps explain how to start such a cloud deployment:

1. In your Unity Editor, select **SpatialOS** &gt; **Build for cloud** &gt; **All workers** to build all your workers and wait for the build to finish.
2. Upload your workers by running the following command in the terminal: `spatial cloud upload <assembly name>`
3. Start your cloud deployment by running the following command in the terminal:

```text
Copy spatial cloud launch --tags=dev_login --snapshot==<path to your snapshot> <assembly name> <path to your launch configuration> <deployment name> 
```

### Choose how to run your mobile client-worker[\#](https://docs.improbable.io/unity/alpha/modules/mobile/cloud-deploy#choose-how-to-run-your-mobile-client-worker) <a id="choose-how-to-run-your-mobile-client-worker"></a>

See [this page](https://docs.improbable.io/unity/alpha/modules/mobile/run-client) for more information on the different ways to run your client.

#### Unity Editor or Unity Remote[\#](https://docs.improbable.io/unity/alpha/modules/mobile/cloud-deploy#unity-editor-or-unity-remote) <a id="unity-editor-or-unity-remote"></a>

1. In your Unity Editor, open the scene that contains your mobile client-worker.
2. Navigate to your mobile client-worker GameObject and ensure the **Should Connect Locally** checkbox is **not** checked in the script’s drop-down window of the Inspector window.
3. \(Optional\) If you want to use Unity Remote, open the Unity Remote app on your Android device that is connected to your development machine.
4. Click the Play button.

#### Android device or Android emulator[\#](https://docs.improbable.io/unity/alpha/modules/mobile/cloud-deploy#android-device-or-android-emulator) <a id="android-device-or-android-emulator"></a>

1. [Start your Android Emulator in Android Studio](https://developer.android.com/studio/run/managing-avds) or connect your Android device to your development machine.
2. In your Unity Editor, select **SpatialOS** &gt; **Launch mobile client** &gt; **Android for cloud**.
3. Play the game on your device or emulator.

> As soon as you have built your Android app once, you are able to launch your app for either local or cloud deployments.

#### iOS Simulator or iOS device[\#](https://docs.improbable.io/unity/alpha/modules/mobile/cloud-deploy#ios-simulator-or-ios-device) <a id="ios-simulator-or-ios-device"></a>

> **Note:** You cannot run the [First Person Shooter \(FPS\) Starter Project](https://docs.improbable.io/unity/alpha/projects/fps/overview) on the iOS Simulator. This is due to an incompatibility between the [Metal Graphics API](https://developer.apple.com/metal/) used by the project and the iOS Simulator.

1. In your Unity Editor, go to your mobile client game object and ensure that the checkbox **Should Connect Locally** is not checked.
2. In your Unity Editor, navigate to **SpatialOS** &gt; **Build for cloud**. Select your mobile client-worker, and wait for the build to complete.
3. In Finder, navigate to `/workers/unity/build/worker/` and locate the `.xcodeproj` that corresponds to your iOS client-worker, it may be in a sub-folder.
4. Open the project in XCode
5. If you want to run it on a physical device, you need to follow these additional steps:
   * Connect your device to your development machine.
   * In XCode, click on your project. This should open the **General**tab for your project.
   * In the **General** tab, navigate to the **Identity** section and enter a unique string for the **Project Bundle Identifier**.
   * In the **General** tab, navigate to the **Signing** section and sign the project. For more information, see [Apple’s documentation on code signing and provisioning](https://help.apple.com/xcode/mac/current/#/dev60b6fbbc7).
6. Still in XCode, select the **Play** button in the top left of the window.
7. Play the game on your device or Simulator.

