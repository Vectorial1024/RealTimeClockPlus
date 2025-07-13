using RealTimeClockPlus.PlayTimeTracker;
using RealTimeClockPlus.RealTimeReadout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RealTimeClockPlus
{
    public class ClockSettings : ModSettings
    {
        public const int StandardRowHeight = 30;
        public const int StandardColumnPadding = 10;

        public ClockReadoutFormatEnum clockDisplayFormat;
        private TimerDisplayLocationEnum spttDisplayLocation;
        public bool spttUseGradient = false;
        public bool spttTrackMilliseconds = false;
        public bool spttMinimal = false;

        public bool DisplaySpttAtClock => spttDisplayLocation == TimerDisplayLocationEnum.REALTIMECLOCK;
        public bool DisplaySpttAsAlert => spttDisplayLocation == TimerDisplayLocationEnum.NOTIFICATION;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref clockDisplayFormat, "clockDisplayFormat", ClockReadoutFormatEnum.SIMPLE_24HR);
            Scribe_Values.Look(ref spttDisplayLocation, "spttDisplayLocation", TimerDisplayLocationEnum.NOTIFICATION);
            Scribe_Values.Look(ref spttUseGradient, "spttUseGradient", true);
            Scribe_Values.Look(ref spttTrackMilliseconds, "spttTrackMilliseconds", true);
            Scribe_Values.Look(ref spttMinimal, "spttMinimal", false);
            base.ExposeData();
        }

        public void DoSettingsWindowContents(Rect inRect)
        {
            // since we no longer rely on HugsLib, we gotta do the UI ourselves
            Listing_Standard listing = new Listing_Standard();

            // ...
            listing.verticalSpacing = 8; // make it more clickable/readable
            listing.Begin(inRect);

            /*
             * concept:
             * left column handles real time clock plus
             * right column handles session play time tracker
             */
            listing.ColumnWidth = listing.ColumnWidth / 2 - StandardColumnPadding;

            // left column handles the real time clock

            // display format
            listing.Label("RTCP_DisplayFormatChoice_title".Translate(), tooltip: "RTCP_DisplayFormatChoice_descr".Translate());
            foreach (var theValue in Enum.GetValues(typeof(ClockReadoutFormatEnum)).Cast<ClockReadoutFormatEnum>())
            {
                string label = "ClockReadoutFormat_" + theValue.ToString();
                if (listing.RadioButton(label.Translate(), clockDisplayFormat == theValue))
                {
                    // on click, set value
                    clockDisplayFormat = theValue;
                }
            }

            // right column handles session play time tracker
            listing.NewColumn();

            // sptt display location
            listing.Label("SPTT_DisplayLocation_title".Translate(), tooltip: "SPTT_DisplayLocation_desc".Translate());
            foreach (var theValue in Enum.GetValues(typeof(TimerDisplayLocationEnum)).Cast<TimerDisplayLocationEnum>())
            {
                string label = "TimerDisplayLocation_" + theValue.ToString();
                if (listing.RadioButton(label.Translate(), spttDisplayLocation == theValue))
                {
                    // on click, set value
                    spttDisplayLocation = theValue;
                }
            }

            // gap it
            listing.Gap(StandardRowHeight);

            // sptt gradient
            listing.CheckboxLabeled("SPTT_UseColorGradient_title".Translate(), ref spttUseGradient, "SPTT_UseColorGradient_desc".Translate());

            // sptt milliseconds
            listing.CheckboxLabeled("SPTT_UseMillisecondPart_title".Translate(), ref spttTrackMilliseconds, "SPTT_UseMillisecondPart_desc".Translate());

            // sptt minimal
            listing.CheckboxLabeled("SPTT_BeMinimalist_title".Translate(), ref spttMinimal, "SPTT_BeMinimalist_desc".Translate());

            // all done
            listing.End();
        }
    }
}
