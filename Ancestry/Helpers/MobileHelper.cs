﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ancestry.Helpers
{
    /// <summary>
    /// This Helper contains methods for Mobile view.
    /// </summary>
    public static class MobileHelper
    {
        /// <summary>
        /// This method check if Device is a tablet by UserAgent
        /// </summary>
        /// <param name="userAgent">User Agent string passed by the browser</param>
        /// <returns>True if the device is Tablet</returns>
        public static bool IsTablet(string userAgent)
        {
            bool result = false;
            // Check if user agent is a Tablet
            if ((Regex.IsMatch(userAgent, "iP(a|ro)d", RegexOptions.IgnoreCase) || (Regex.IsMatch(userAgent, "tablet", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(userAgent, "RX-34", RegexOptions.IgnoreCase)) || (Regex.IsMatch(userAgent, "FOLIO", RegexOptions.IgnoreCase))))
            {
                result = true;
            }
            // Check if user agent is an Android Tablet
            else if ((Regex.IsMatch(userAgent, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "Android", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(userAgent, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945", RegexOptions.IgnoreCase)))
            {
                result = true;
            }
            // Check if user agent is a Kindle or Kindle Fire
            else if ((Regex.IsMatch(userAgent, "Kindle", RegexOptions.IgnoreCase)) || (Regex.IsMatch(userAgent, "Mac.OS", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "Silk", RegexOptions.IgnoreCase)))
            {
                result = true;
            }
            // Check if user agent is a pre Android 3.0 Tablet
            else if ((Regex.IsMatch(userAgent, @"GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|\\_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook", RegexOptions.IgnoreCase)) || (Regex.IsMatch(userAgent, "MB511", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "RUTEM", RegexOptions.IgnoreCase)))
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// This method return the Device Type of mobile view checking the UserAgent
        /// </summary>
        /// <param name="userAgent">User Agent string passed by the browser</param>
        /// <returns>The Device Type string</returns>
        public static string GetDeviceType(string userAgent)
        {
            string result = "";
            // Check if user agent is a smart TV - http://goo.gl/FocDk
            if (Regex.IsMatch(userAgent, @"GoogleTV|SmartTV|Internet.TV|NetCast|NETTV|AppleTV|boxee|Kylo|Roku|DLNADOC|CE\-HTML", RegexOptions.IgnoreCase))
            {
                result = "tv";
            }
            // Check if user agent is a TV Based Gaming Console
            else if (Regex.IsMatch(userAgent, "Xbox|PLAYSTATION.3|Wii", RegexOptions.IgnoreCase))
            {
                result = "tv";
            }
            // Check if user agent is a Tablet
            else if ((Regex.IsMatch(userAgent, "iP(a|ro)d", RegexOptions.IgnoreCase) || (Regex.IsMatch(userAgent, "tablet", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(userAgent, "RX-34", RegexOptions.IgnoreCase)) || (Regex.IsMatch(userAgent, "FOLIO", RegexOptions.IgnoreCase))))
            {
                result = "tablet";
            }
            // Check if user agent is an Android Tablet
            else if ((Regex.IsMatch(userAgent, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "Android", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(userAgent, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945", RegexOptions.IgnoreCase)))
            {
                result = "tablet";
            }
            // Check if user agent is a Kindle or Kindle Fire
            else if ((Regex.IsMatch(userAgent, "Kindle", RegexOptions.IgnoreCase)) || (Regex.IsMatch(userAgent, "Mac.OS", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "Silk", RegexOptions.IgnoreCase)))
            {
                result = "tablet";
            }
            // Check if user agent is a pre Android 3.0 Tablet
            else if ((Regex.IsMatch(userAgent, @"GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|\\_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook", RegexOptions.IgnoreCase)) || (Regex.IsMatch(userAgent, "MB511", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "RUTEM", RegexOptions.IgnoreCase)))
            {
                result = "tablet";
            }
            // Check if user agent is unique Mobile User Agent
            else if ((Regex.IsMatch(userAgent, "BOLT|Fennec|Iris|Maemo|Minimo|Mobi|mowser|NetFront|Novarra|Prism|RX-34|Skyfire|Tear|XV6875|XV6975|Google.Wireless.Transcoder", RegexOptions.IgnoreCase)))
            {
                result = "mobile";
            }
            // Check if user agent is an odd Opera User Agent - http://goo.gl/nK90K
            else if ((Regex.IsMatch(userAgent, "Opera", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "Windows.NT.5", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, @"HTC|Xda|Mini|Vario|SAMSUNG\-GT\-i8000|SAMSUNG\-SGH\-i9", RegexOptions.IgnoreCase)))
            {
                result = "mobile";
            }
            // Check if user agent is Windows Desktop
            else if ((Regex.IsMatch(userAgent, "Windows.(NT|XP|ME|9)")) && (!Regex.IsMatch(userAgent, "Phone", RegexOptions.IgnoreCase)) || (Regex.IsMatch(userAgent, "Win(9|.9|NT)", RegexOptions.IgnoreCase)))
            {
                result = "desktop";
            }
            // Check if agent is Mac Desktop
            else if ((Regex.IsMatch(userAgent, "Macintosh|PowerPC", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(userAgent, "Silk", RegexOptions.IgnoreCase)))
            {
                result = "desktop";
            }
            // Check if user agent is a Linux Desktop
            else if ((Regex.IsMatch(userAgent, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(userAgent, "X11", RegexOptions.IgnoreCase)))
            {
                result = "desktop";
            }
            // Check if user agent is a Solaris, SunOS, BSD Desktop
            else if ((Regex.IsMatch(userAgent, "Solaris|SunOS|BSD", RegexOptions.IgnoreCase)))
            {
                result = "desktop";
            }
            // Check if user agent is a Desktop BOT/Crawler/Spider
            else if ((Regex.IsMatch(userAgent, "Bot|Crawler|Spider|Yahoo|ia_archiver|Covario-IDS|findlinks|DataparkSearch|larbin|Mediapartners-Google|NG-Search|Snappy|Teoma|Jeeves|TinEye", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(userAgent, "Mobile", RegexOptions.IgnoreCase)))
            {
                result = "desktop";
            }
            // Otherwise assume it is a Mobile Device
            else
            {
                result = "mobile";
            }
            return result;
        }
    }
}
