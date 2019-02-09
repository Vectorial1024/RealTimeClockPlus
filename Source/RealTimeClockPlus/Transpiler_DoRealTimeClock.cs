using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace RealTimeClockPlus
{
    [HarmonyPatch(typeof(GlobalControlsUtility))]
    [HarmonyPatch("DoRealtimeClock", MethodType.Normal)]
    public class Transpiler_DoRealTimeClock
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            // Look for the only ldstr, then replace it with GetFormattingStringFromDisplayEnum().
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldstr)
                {
                    yield return new CodeInstruction(OpCodes.Call, typeof(ClockStringCustomDrawer).GetMethod("GetFormattingStringFromDisplayEnum"));
                }
                else
                {
                    yield return instruction;
                }
            }
        }
    }
}
