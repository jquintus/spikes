using Android.App;
using Android.Content;
using Android.Util;
using Android.Widget;
using System;
using System.Linq;

namespace MediaBroadcastReceiver
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new string[] { Intent.ActionHeadsetPlug })]
    public class HeadphoneBroadcastReceiver : BroadcastReceiver
    {
        public HeadphoneBroadcastReceiver()
        {
            Log.Debug("HBR", "Receiver online");
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string msg = "Intent recieved";

            try
            {
                int state = intent.Extras.GetInt("state");
                string name = intent.Extras.GetString("name");
                int mic = intent.Extras.GetInt("microphone");

                if (state == 1)
                {
                    msg = string.Format("Headset {0}plugged in:  {1}", mic == 1 ? "with mic " : "", name);
                }
                else
                {
                    msg = string.Format("Headset {0}unplugged:  {1}", mic == 1 ? "with mic " : "", name);
                }
            }
            catch (Exception ex)
            {
                msg += " - " + ex.Message;
            }

            Toast.MakeText(context, msg, ToastLength.Long);
            Log.Info("HBR", msg);
        }
    }

    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new string[] { Intent.ActionPowerConnected, Intent.ActionPowerDisconnected, Intent.ActionAirplaneModeChanged, Intent.ActionAllApps, Intent.ActionAnswer, Intent.ActionAppError, Intent.ActionAttachData, Intent.ActionBatteryChanged, Intent.ActionBatteryLow, Intent.ActionBatteryOkay, Intent.ActionBootCompleted, Intent.ActionBugReport, Intent.ActionCall, Intent.ActionCallButton, Intent.ActionCameraButton, Intent.ActionChooser, Intent.ActionCloseSystemDialogs, Intent.ActionConfigurationChanged, Intent.ActionCreateShortcut, Intent.ActionDateChanged, Intent.ActionDefault, Intent.ActionDelete, Intent.ActionDeviceStorageLow, Intent.ActionDeviceStorageOk, Intent.ActionDial, Intent.ActionDockEvent, Intent.ActionEdit, Intent.ActionExternalApplicationsAvailable, Intent.ActionExternalApplicationsUnavailable, Intent.ActionFactoryTest, Intent.ActionGetContent, Intent.ActionGtalkServiceConnected, Intent.ActionGtalkServiceDisconnected, Intent.ActionHeadsetPlug, Intent.ActionInputMethodChanged, Intent.ActionInsert, Intent.ActionInsertOrEdit, Intent.ActionInstallPackage, Intent.ActionLocaleChanged, Intent.ActionMain, Intent.ActionManageNetworkUsage, Intent.ActionManagePackageStorage, Intent.ActionMediaBadRemoval, Intent.ActionMediaButton, Intent.ActionMediaChecking, Intent.ActionMediaEject, Intent.ActionMediaMounted, Intent.ActionMediaNofs, Intent.ActionMediaRemoved, Intent.ActionMediaScannerFinished, Intent.ActionMediaScannerScanFile, Intent.ActionMediaScannerStarted, Intent.ActionMediaShared, Intent.ActionMediaUnmountable, Intent.ActionMediaUnmounted, Intent.ActionMyPackageReplaced, Intent.ActionNewOutgoingCall, Intent.ActionPackageAdded, Intent.ActionPackageChanged, Intent.ActionPackageDataCleared, Intent.ActionPackageFirstLaunch, Intent.ActionPackageFullyRemoved, Intent.ActionPackageInstall, Intent.ActionPackageNeedsVerification, Intent.ActionPackageRemoved, Intent.ActionPackageReplaced, Intent.ActionPackageRestarted, Intent.ActionPaste, Intent.ActionPick, Intent.ActionPickActivity, Intent.ActionPowerConnected, Intent.ActionPowerDisconnected, Intent.ActionPowerUsageSummary, Intent.ActionProviderChanged, Intent.ActionReboot, Intent.ActionRun, Intent.ActionScreenOff, Intent.ActionScreenOn, Intent.ActionSearch, Intent.ActionSearchLongPress, Intent.ActionSend, Intent.ActionSendMultiple, Intent.ActionSendto, Intent.ActionSetWallpaper, Intent.ActionShutdown, Intent.ActionSync, Intent.ActionSystemTutorial, Intent.ActionTimeChanged, Intent.ActionTimeTick, Intent.ActionTimezoneChanged, Intent.ActionUidRemoved, Intent.ActionUmsConnected, Intent.ActionUmsDisconnected, Intent.ActionUninstallPackage, Intent.ActionUserPresent, Intent.ActionView, Intent.ActionVoiceCommand, Intent.ActionWallpaperChanged, Intent.ActionWebSearch, Intent.CategoryAlternative, Intent.CategoryAppBrowser, Intent.CategoryAppCalculator, Intent.CategoryAppCalendar, Intent.CategoryAppContacts, Intent.CategoryAppEmail, Intent.CategoryAppGallery, Intent.CategoryAppMaps, Intent.CategoryAppMarket, Intent.CategoryAppMessaging, Intent.CategoryAppMusic, Intent.CategoryBrowsable, Intent.CategoryCarDock, Intent.CategoryCarMode, Intent.CategoryDefault, Intent.CategoryDeskDock, Intent.CategoryDevelopmentPreference, Intent.CategoryEmbed, Intent.CategoryFrameworkInstrumentationTest, Intent.CategoryHeDeskDock, Intent.CategoryHome, Intent.CategoryInfo, Intent.CategoryLauncher, Intent.CategoryLeDeskDock, Intent.CategoryMonkey, Intent.CategoryOpenable, Intent.CategoryPreference, Intent.CategorySampleCode, Intent.CategorySelectedAlternative, Intent.CategoryTab, Intent.CategoryTest, Intent.CategoryUnitTest, Intent.ExtraAlarmCount, Intent.ExtraAllowReplace, Intent.ExtraBcc, Intent.ExtraBugReport, Intent.ExtraCc, Intent.ExtraChangedComponentName, Intent.ExtraChangedComponentNameList, Intent.ExtraChangedPackageList, Intent.ExtraChangedUidList, Intent.ExtraDataRemoved, Intent.ExtraDockState, Intent.ExtraDontKillApp, Intent.ExtraEmail, Intent.ExtraInitialIntents, Intent.ExtraInstallerPackageName, Intent.ExtraIntent, Intent.ExtraKeyEvent, Intent.ExtraLocalOnly, Intent.ExtraNotUnknownSource, Intent.ExtraPhoneNumber, Intent.ExtraRemoteIntentToken, Intent.ExtraReplacing, Intent.ExtraReturnResult, Intent.ExtraShortcutIcon, Intent.ExtraShortcutIconResource, Intent.ExtraShortcutIntent, Intent.ExtraShortcutName, Intent.ExtraStream, Intent.ExtraSubject, Intent.ExtraTemplate, Intent.ExtraText, Intent.ExtraTitle, Intent.ExtraUid, Intent.MetadataDockHome })]
    public class PowerBroadcastReceiever : BroadcastReceiver
    {
        public PowerBroadcastReceiever()
        {
            Log.Debug(A.B, "Power Reciever Online");
        }

        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                var keys = intent.Extras.KeySet();

                var argList = keys.Select(k => string.Format("{0} => {1}", k, intent.Extras.Get(k) ?? "<no value>")).ToArray();
                string args = string.Join(", ", argList);

                Log.Info(A.B, intent.Action + " " + args);
            }
            catch (Exception)
            {
                Log.Info(A.B, "Something happened:  " + intent.Action);
            }
        }
    }

    internal class A
    {
        public const string B = "HBR";
    }
}