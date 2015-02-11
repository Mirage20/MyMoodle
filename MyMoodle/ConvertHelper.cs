using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoodle
{
    class ConvertHelper
    {
        public static string byteConvet(long bytes)
        {
            string unit = "Bytes";
            float size = bytes;
            if ((size / (float)1024) >= 1)
            {
                unit = "KB";
                size /= 1024;
                if ((size / (float)1024) >= 1)
                {
                    unit = "MB";
                    size /= 1024;

                    if ((size / (float)1024) >= 1)
                    {
                        unit = "GB";
                        size /= 1024;
                    }
                }
            }
            return size.ToString("0.000") + " " + unit;
        }

        public static string minConvet(long min)
        {
            string unit = "Minutes";
            float time = min;
            if ((time / (float)60) >= 1)
            {
                unit = "Hour";
                time /= 60;

            }
            return time.ToString("0.00") + " " + unit;
        }

        public static string timeDifferenceConvert(DateTime oldTime,DateTime newTime)
        {
            TimeSpan tSpan = newTime.Subtract(oldTime);

            if(tSpan.Days> 0)
            {
                if (tSpan.Days > 1)
                    return tSpan.Days.ToString() + " days";
                else
                    return tSpan.Days.ToString() + " day";
            }
            else if (tSpan.Hours > 0)
            {
                if (tSpan.Hours > 5)
                    return tSpan.Hours.ToString() + " hours";
                else
                {
                    if (tSpan.Hours > 1)
                    {
                        if (tSpan.Minutes > 0)
                        {
                            if (tSpan.Minutes > 1)
                                return tSpan.Hours.ToString() + " hours and "+ tSpan.Minutes.ToString() + " minutes";
                            else
                                return tSpan.Hours.ToString() + " hours and " +tSpan.Minutes.ToString() + " minute";
                        }
                        return tSpan.Hours.ToString() + " hours";
                    }
                    else
                    {
                        if (tSpan.Minutes > 0)
                        {
                            if (tSpan.Minutes > 1)
                                return tSpan.Hours.ToString() + " hour and " + tSpan.Minutes.ToString() + " minutes";
                            else
                                return tSpan.Hours.ToString() + " hour and " + tSpan.Minutes.ToString() + " minute";
                        }
                        return tSpan.Hours.ToString() + " hour";
                    }
                    
                }
            }
            else if (tSpan.Minutes > 0)
            {
                if (tSpan.Minutes > 1)
                    return tSpan.Minutes.ToString() + " minutes";
                else
                    return tSpan.Minutes.ToString() + " minute";
            }
            else if (tSpan.Seconds > 0)
            {
                if (tSpan.Seconds > 1)
                    return tSpan.Seconds.ToString() + " seconds";
                else
                    return tSpan.Seconds.ToString() + " second";
            }

            return "0 seconds";
        }
    }
}
