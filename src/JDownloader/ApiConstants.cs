namespace JDownloader
{
    public static class ApiConstants
    {
        public const string SERVER_ROOT = "https://api.jdownloader.org";
        public const int API_VERSION = 1;

        public static class Server
        {
            public const string Connect = "/my/connect?email={0}&appkey={1}";
            public const string Disconnect = "/my/disconnect?sessiontoken={0}";
            public const string ListDevices = "/my/listdevices?sessiontoken={0}";
            public const string Reconnect = "/my/reconnect?sessiontoken={0}&regaintoken={1}";
        }

        public static class AccountsV2
        {
            public const string AddAccount = "addAccount";
            public const string AddBasicAuth = "addBasicAuth";
            public const string DisableAccounts = "disableAccounts";
            public const string EnableAccounts = "enableAccounts";
            public const string GetPremiumHosterUrl = "getPremiumHosterUrl";
            public const string ListAccounts = "listAccounts";
            public const string ListBasicAuth = "listBasicAuth";
            public const string ListPremiumHoster = "listPremiumHoster";
            public const string ListPremiumHosterUrls = "listPremiumHosterUrls";
            public const string RefreshAccounts = "refreshAccounts";
            public const string RemoveAccounts = "removeAccounts";
            public const string RemoveBasicAuths = "removeBasicAuths";
            public const string SetUsernameAndPassword = "setUserNameAndPassword";
            public const string UpdateBasicAuth = "updateBasicAuth";
        }

        public static class Captcha
        {
            public const string Get = "get";
            public const string GetCaptchaJob = "getCaptchaJob";
            public const string List = "list";
            public const string Skip = "skip";
            public const string Solve = "solve";
        }

        public static class CaptchaForward
        {
            public const string CreateJobRecaptchaV2 = "createJobRecaptchaV2";
            public const string GetResult = "getResult";
        }

        public static class Config
        {
            public const string Get = "get";
            public const string GetDefault = "getDefault";
            public const string List = "list";
            public const string ListEnum = "listEnum";
            public const string Query = "query";
            public const string Reset = "reset";
            public const string Set = "set";
        }

        public static class Device
        {
            public const string GetDirectConnectionInfos = "getDirectConnectionInfos";
            public const string GetSessionPublicKey = "getSessionPublicKey";
            public const string Ping = "ping";
        }

        public static class Dialogs
        {
            public const string Answer = "answer";
            public const string Get = "get";
            public const string GetTypeInfo = "getTypeInfo";
            public const string List = "list";
        }

        public static class DownloadController
        {
            public const string ForceDownload = "forceDownload";
            public const string GetCurrentState = "getCurrentState";
            public const string GetSpeedInBps = "getSpeedInBps";
            public const string Pause = "pause";
            public const string Start = "start";
            public const string Stop = "stop";
        }

        public static class DownloadEvents
        {
            public const string QueryLinks = "queryLinks";
            public const string SetStatusEventInterval = "setStatusEventInterval";
        }

        public static class DownloadsV2
        {
            public const string Cleanup = "cleanup";
            public const string ForceDownload = "forceDownload";
            public const string GetDownloadUrls = "getDownloadUrls";
            public const string GetStopMark = "getStopMark";
            public const string GetStopMarkedLink = "getStopMarkedLink";
            public const string GetStructureChangeCounter = "getstatic classureChangeCounter";
            public const string MoveLinks = "moveLinks";
            public const string MovePackages = "movePackages";
            public const string MoveToNewPackage = "movetoNewPackage";
            public const string PackageCount = "packageCount";
            public const string QueryLinks = "queryLinks";
            public const string QueryPackages = "queryPackages";
            public const string RemoveLinks = "removeLinks";
            public const string RemoveStopMark = "removeStopMark";
            public const string RenameLink = "renameLink";
            public const string RenamePackage = "renamePackage";
            public const string ResetLinks = "resetLinks";
            public const string ResumeLinks = "resumeLinks";
            public const string SetComment = "setComment";
            public const string SetDownloadDirectory = "setDownloadDirectory";
            public const string SetDownloadPassword = "setDownloadPassword";
            public const string SetEnabled = "setEnabled";
            public const string SetPriority = "setPriority";
            public const string SetStopMark = "setStopMark";
            public const string SplitPackageByHoster = "splitPackageByHoster";
            public const string StartOnlineStatusCheck = "startOnlineStatusCheck";
            public const string Unskip = "unskip";
        }

        public static class Events
        {
            public const string AddSubscription = "addsubscription";
            public const string ChangeSubscriptionTimeouts = "changesubscriptiontimeouts";
            public const string GetSubscription = "getsubscription";
            public const string GetSubscriptionStatus = "getsubscriptionstatus";
            public const string Listen = "listen";
            public const string ListPublisher = "listpublisher";
            public const string RemoveSubscription = "removesubscription";
            public const string SetSubscription = "setsubscription";
            public const string Subscribe = "subscribe";
            public const string Unsubscribe = "unsubscribe";
        }

        public static class Extensions
        {
            public const string Install = "install";
            public const string IsEnabled = "isEnabled";
            public const string IsInstalled = "isInstalled";
            public const string List = "list";
            public const string SetEnabled = "setEnabled";
        }

        public static class Extraction
        {
            public const string AddArchivePassword = "addArchivePassword";
            public const string CancelExtraction = "cancelExtraction";
            public const string GetArchiveInfo = "getArchiveInfo";
            public const string GetArchiveSettings = "getArchiveSettings";
            public const string GetQueue = "getQueue";
            public const string SetArchiveSettings = "setArchiveSettings";
            public const string StartExtractionNow = "startExtractionNow";
        }

        public static class Flash
        {
            public const string Add = "add";
            public const string AddCnl = "addcnl";
            public const string AddCrypted = "addcrypted";
            public const string AddCrypted2 = "addcrypted2";
            public const string AddCrypted2Remote = "addcrypted2Remote";
        }

        public static class Jd
        {
            public const string GetCoreRevision = "getCoreRevision";
            public const string RefreshPlugins = "refreshPlugins";
            public const string Uptime = "uptime";
            public const string Version = "version";
        }

        public static class LinkCrawler
        {
            public const string IsCrawling = "isCrawling";
        }

        public static class LinkGrabberV2
        {
            public const string Abort = "abort";
            public const string AddContainer = "addContainer";
            public const string AddLinks = "addLinks";
            public const string AddVariantCopy = "addVariantCopy";
            public const string Cleanup = "cleanup";
            public const string ClearList = "clearList";
            public const string GetChildrenChanged = "getChildrenChanged";
            public const string GetDownloadFolderHistorySelectionBase = "getDownloadFolderHistorySelectionBase";
            public const string GetDownloadUrls = "getDownloadUrls";
            public const string GetPackageCount = "getPackageCount";
            public const string GetVariants = "getVariants";
            public const string IsCollecting = "isCollecting";
            public const string MoveLinks = "moveLinks";
            public const string MovePackages = "movePackages";
            public const string MoveToDownloadList = "moveToDownloadlist";
            public const string MoveToNewPackage = "movetoNewPackage";
            public const string QueryLinkCrawlerJobs = "queryLinkCrawlerJobs";
            public const string QueryLinks = "queryLinks";
            public const string QueryPackages = "queryPackages";
            public const string RemoveLinks = "removeLinks";
            public const string RenameLink = "renameLink";
            public const string RenamePackage = "renamePackage";
            public const string SetComment = "setComment";
            public const string SetDownloadDirectory = "setDownloadDirectory";
            public const string SetDownloadPassword = "setDownloadPassword";
            public const string SetEnabled = "setEnabled";
            public const string SetPriority = "setPriority";
            public const string SetVariant = "setVariant";
            public const string SplitPackageByHoster = "splitPackageByHoster";
            public const string StartOnlineStatusCheck = "startOnlineStatusCheck";
        }

        public static class Log
        {
            public const string GetAvailableLogs = "getAvailableLogs";
            public const string SendLogFile = "sendLogFile";
        }

        public static class Plugins
        {
            public const string Get = "get";
            public const string GetAllPluginRegex = "getAllPluginRegex";
            public const string GetPluginRegex = "getPluginRegex";
            public const string List = "list";
            public const string Query = "query";
            public const string Reset = "reset";
            public const string Set = "set";
        }

        public static class Polling
        {
            public const string Poll = "poll";
        }

        public static class Reconnect
        {
            public const string DoReconnect = "doReconnect";
        }

        public static class Session
        {
            public const string Disconnect = "disconnect";
            public const string Handshake = "handshake";
        }

        public static class System
        {
            public const string ExitJD = "exitJD";
            public const string GetStorageInfos = "getStorageInfos";
            public const string GetSystemInfos = "getSystemInfos";
            public const string HibernateOS = "hibernateOS";
            public const string RestartJD = "restartJD";
            public const string ShutdownOS = "shutdownOS";
            public const string StandbyOS = "standbyOS";
        }

        public static class Toolbar
        {
            public const string AddLinksFromDOM = "addLinksFromDOM";
            public const string CheckLinksFromDOM = "checkLinksFromDOM";
            public const string GetStatus = "getStatus";
            public const string IsAvailable = "isAvailable";
            public const string PollCheckedLinksFromDOM = "pollCheckedLinksFromDOM";
            public const string SpecialURLHandling = "specialURLHandling";
            public const string StartDownloads = "startDownloads";
            public const string StopDownloads = "stopDownloads";
            public const string ToggleAutomaticReconnect = "toggleAutomaticReconnect";
            public const string ToggleClipboardMonitoring = "toggleClipboardMonitoring";
            public const string ToggleDownloadSpeedLimit = "toggleDownloadSpeedLimit";
            public const string TogglePauseDownloads = "togglePauseDownloads";
            public const string TogglePremium = "togglePremium";
            public const string ToggleStopAfterCurrentDownload = "toggleStopAfterCurrentDownload";
            public const string TriggerUpdate = "triggerUpdate";
        }

        public static class Ui
        {
            public const string GetMenu = "getMenu";
            public const string InvokeAction = "invokeAction";
        }

        public static class Update
        {
            public const string IsUpdateAvailable = "isUpdateAvailable";
            public const string RestartAndUpdate = "restartAndUpdate";
            public const string RunUpdateCheck = "runUpdateCheck";
        }
    }
}
