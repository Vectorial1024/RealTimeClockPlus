using HarmonyLib;
using RealTimeClockPlus.PlayTimeTracker;
using Verse;

namespace RealTimeClockPlus
{
    public class RealTimeClockPlusMod : Mod
    {
        public static string MODSHORTID => "V1024-RTCP";

        // Static objects

        private static RimWorldSPTT spttObject;

        /// <summary>
        /// The session play time tracker.
        /// 
        /// It is possible to use this idempotently in eg Zetrith's Multiplayer:
        /// - This property will auto-create a static tracker if prior instances do not exist
        /// - You call the idempotent-reset function to reset the timer when the game quits to main menu (the other exit path "Quit to OS" is obviously irrelevant)
        /// - You do not call AccumulateTime when the game is not in active state.
        /// </summary>
        public static RimWorldSPTT SessionPlayTimeTracker
        {
            get
            {
                if (spttObject == null)
                {
                    spttObject = new RimWorldSPTT();
                }
                return spttObject;
            }
            private set
            {
                spttObject = value;
            }
        }

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

        // User-defined methods

        public static void IdempotentBeginTimer()
        {
            // the main idea is to avoid resetting it when it is already counting, eg when in multiplayer and a new player joins.
            if (SessionPlayTimeTracker != null)
            {
                SessionPlayTimeTracker = new RimWorldSPTT();
            }
        }

        public static void IdempotentResetTimer()
        {
            SessionPlayTimeTracker = null;
        }

        /// <summary>
        /// Warning: DO NOT CALL THIS IF NOT IN PLAY MAP!!!
        /// </summary>
        /// <param name="amount"></param>
        public static void AccumulateTime(float amount)
        {
            SessionPlayTimeTracker?.AccumulateTime(amount);
        }
    }
}
