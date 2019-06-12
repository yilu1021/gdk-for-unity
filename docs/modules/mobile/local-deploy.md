# local-deploy

\[can we add an in-page TOC?\]

## Connect to a local deployment

{% hint style="info" %}
* [Setting up Android support for the GDK](https://github.com/spatialos/gdk-for-unity/tree/1adc338e9fafa1fdad09b457b5bab54ece3e4ed1/docs/modules/mobile/%7B%7BurlRoot%7D%7D/modules/mobile/setup-android/README.md)
* [Setting up iOS support for the GDK](https://github.com/spatialos/gdk-for-unity/tree/1adc338e9fafa1fdad09b457b5bab54ece3e4ed1/docs/modules/mobile/%7B%7BurlRoot%7D%7D/modules/mobile/setup-ios/README.md)
{% endhint %}

### Prepare your project to connect to a local deployment

To connect your mobile device to a local deployment, you need to configure the Runtime IP parameter. This ensures that your mobile device is able to connect to local deployments running on your machine.

Open your project in your Unity Editor.

1. Select **SpatialOS** &gt; **GDK Tools configuration** to open the configuration window.
2. In the **Local runtime IP** field, enter your development machine's IP address. \(You can find how to do this on the [Lifehacker website](https://lifehacker.com/5833108/how-to-find-your-local-and-external-ip-address).\)
3. Select **Save** and close the window.

### Start a local deployment

Before connecting your mobile client-worker you need to start a local deployment. In your Unity Editor, select **SpatialOS** &gt; **Local launch**. Your deployment is ready when you see the following message in the terminal:

```text
SpatialOS ready. Access the Inspector at http://localhost:21000/inspector.
```

### Choose how to run your mobile client-worker

See [Ways to run your client](https://github.com/spatialos/gdk-for-unity/tree/1adc338e9fafa1fdad09b457b5bab54ece3e4ed1/docs/modules/mobile/%7B%7BurlRoot%7D%7D/modules/mobile/run-client/README.md) for more information.

#### Unity Editor or Unity Remote <a id="in-editor"></a>

1. In your Unity Editor, open the Scene that contains your mobile client worker and your server-workers.
2. Navigate to your mobile client-worker GameObject and ensure the **Should Connect Locally**  checkbox is checked in the script’s drop-down window of the Inspector window.
3. \(Optional\) If you want to use Unity Remote, open the Unity Remote app on your mobile device that is connected to your development machine.
4. Click the Play button.

#### Android emulator or device <a id="android-device"></a>

1. [Start your Android Emulator in Android Studio](https://developer.android.com/studio/run/managing-avds) or connect your Android device to your development machine.
2. In your Unity Editor, navigate to **SpatialOS** &gt; **Build for local**. Select your mobile worker, and wait for the build to complete.
3. Navigate to your server-worker Scene and start it via the Editor.
4. Select **SpatialOS** &gt; **Launch mobile client** &gt; **Android for local** to start your Android client.
5. Play the game on your device or emulator.

> As soon as you have built your Android app once, you are able to launch your app for either local or cloud deployments.

#### iOS Simulator or iOS device

> **Note:** You cannot run the [First Person Shooter \(FPS\) Starter Project](https://github.com/spatialos/gdk-for-unity/tree/1adc338e9fafa1fdad09b457b5bab54ece3e4ed1/docs/modules/mobile/%7B%7BurlRoot%7D%7D/projects/fps/overview/README.md) on the iOS Simulator. This is due to an incompatibility between the [Metal Graphics API](https://developer.apple.com/metal/) used by the project and the iOS Simulator.

1. In your Unity Editor, go to your mobile client game object
   * Enter your local IP address in the **IP Address** field.
   * Ensure that the **Should Connect Locally** checkbox is checked.
2. In your Unity Editor, navigate to **SpatialOS** &gt; **Build for local**. Select your mobile worker, and wait for the build to complete.
3. Navigate to your server-worker Scene and start it via the Editor.
4. In Finder, navigate to `/workers/unity/build/worker/` and locate the `.xcodeproj` that corresponds to your iOS client-worker, it may be in a sub-folder.
5. Open the project in XCode.
6. If you want to run it on a physical device, you need to follow these additional steps:
   * Connect your device to your development machine.
   * In XCode, click on your project. This should open the **General** tab for your project.
   * In the **General** tab, navigate to the **Identity** section and enter a unique string for the **Project Bundle Identifier**.
   * In the **General** tab, navigate to the **Signing** section and sign the project. For more information, see [Apple's documentation on code signing and provisioning](https://help.apple.com/xcode/mac/current/#/dev60b6fbbc7).
7. Still in XCode, select the Play button in the top left of the window. This builds and install the game on your device or Simulator.
8. Play the game on your device or Simulator.

