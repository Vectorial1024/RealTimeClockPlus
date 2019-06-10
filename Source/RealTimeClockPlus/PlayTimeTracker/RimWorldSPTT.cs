using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RealTimeClockPlus.PlayTimeTracker
{
    /// <summary>
    /// RimWorld Session Play Time Tracker, abbreviated as RimWorld SPTT
    /// </summary>
    public class RimWorldSPTT
    {
        /// <summary>
        /// Lambda expression. Calculates and returns the cumulative time elapsed.
        /// </summary>
        public TimeSpan ElapsedTime => TimeSpan.FromSeconds(accumulation);

        /// <summary>
        /// Internal variable to store how much time has passed since whatever moment we start counting.
        /// </summary>
        private float accumulation = 0;

        public RimWorldSPTT()
        {
            accumulation = 0;
        }

        /// <summary>
        /// Generates a string (format is "hh:mm:ss:f") to represent the time elapsed since the Commencement Time.
        /// <para/>
        /// Note that since we are in Framework v3.5, formatting strings does not exist, so we have to construct the string ourselves.
        /// </summary>
        /// <returns>The string representing the time elapsed.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            // Hours: Displayed in full.
            // Supposedly people won't play more than 24 hours in one go.
            int hours = (int)ElapsedTime.TotalHours;
            builder.Append(hours.ToStringCached());
            builder.Append(":");
            // Minutes
            int minutes = ElapsedTime.Minutes;
            if (minutes == 0)
            {
                builder.Append("00");
            }
            else
            {
                if (minutes < 10)
                {
                    builder.Append("0");
                }
                builder.Append(minutes.ToStringCached());
            }
            builder.Append(":");
            // Seconds
            int seconds = ElapsedTime.Seconds;
            if (seconds == 0)
            {
                builder.Append("00");
            }
            else
            {
                if (seconds < 10)
                {
                    builder.Append("0");
                }
                builder.Append(seconds.ToStringCached());
            }
            builder.Append(":");
            // Milliseconds
            // Policy is to display 2 d.p. of milliseconds
            int millisecondsTenths = ElapsedTime.Milliseconds / 10;
            if (millisecondsTenths < 10)
            {
                builder.Append("0");
            }
            builder.Append(millisecondsTenths.ToStringCached());
            // Everything is done.
            return builder.ToString();
        }

        /// <summary>
        /// Instructs this counter to accumulate such amount of time.
        /// </summary>
        /// <param name="amount"></param>
        public void AccumulateTime(float amount)
        {
            accumulation += amount;
        }
    }
}
