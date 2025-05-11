using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YT_DLP.player
{
    public static class ImmersiveDarkModeHelper
    {
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20; // Windows 10 1809+
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (!IsSupported()) return false;

            int attribute = GetAttribute();
            int useImmersiveDarkMode = enabled ? 1 : 0;
            return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
        }

        private static int GetAttribute()
        {
            // Windows 10 1903 and newer uses 20
            if (Environment.OSVersion.Version.Build >= 18362)
                return DWMWA_USE_IMMERSIVE_DARK_MODE;
            return DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
        }

        private static bool IsSupported()
        {
            return Environment.OSVersion.Version.Major >= 10;
        }
    }
}
