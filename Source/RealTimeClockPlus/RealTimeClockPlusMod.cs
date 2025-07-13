using HarmonyLib;
using Verse;

namespace RealTimeClockPlus
{
    public class RealTimeClockPlusMod : Mod
    {
        public static string MODSHORTID => "V1024-RTCP";

        public RealTimeClockPlusMod(ModContentPack content) : base(content)
        {
            // since we no longer depend on HugsLib, we have to apply the harmony patches ourselves
            LogInfo("Real Time Clock Plus, starting up. Hopefully the patches work.");
            Harmony harmony = new Harmony("rimworld." + content.PackageId);
            harmony.PatchAll();
        }

        /// <summary>
        /// Already includes a space character.
        /// </summary>
        public static string MODPREFIX => "[" + MODSHORTID + "]";

        public static void LogError(string message)
        {
            Log.Error(MODPREFIX + " " + message);
        }

        public static void LogWarning(string message)
        {
            Log.Warning(MODPREFIX + " " + message);
        }

        public static void LogInfo(string message)
        {
            Log.Message(MODPREFIX + " " + message);
        }
    }
}
