using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Time
    {
        public double result;
        public string[] timeConversions = {
        "SecondMinute", "SecondHour", "SecondDay",
        "MinuteSecond", "MinuteHour", "MinuteDay",
        "HourSecond", "HourMinute", "HourDay",
        "DaySecond", "DayMinute", "DayHour"
        };

    public double convertTime(string conversionType, double value)
        {
            switch (conversionType)
            {
                case "SecondMinute":
                    result = value / 60.0;
                    break;
                case "SecondHour":
                    result = value / 3600.0;
                    break;
                case "SecondDay":
                    result = value / 86400.0;
                    break;
                case "MinuteSecond":
                    result = value * 60.0;
                    break;
                case "MinuteHour":
                    result = value / 60.0;
                    break;
                case "MinuteDay":
                    result = value / 1440.0;
                    break;
                case "HourSecond":
                    result = value * 3600.0;
                    break;
                case "HourMinute":
                    result = value * 60.0;
                    break;
                case "HourDay":
                    result = value / 24.0;
                    break;
                case "DaySecond":
                    result = value * 86400.0;
                    break;
                case "DayMinute":
                    result = value * 1440.0;
                    break;
                case "DayHour":
                    result = value * 24.0;
                    break;
            }
            return result;
        }
    }
}
