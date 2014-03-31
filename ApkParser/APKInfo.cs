using System;
using System.Collections.Generic;
using System.Globalization;

namespace ApkParser.Model
{
    public class ApkInfo
    {
        public static int FINE = 0;
        public static int NULL_VERSION_CODE = 1;
        public static int NULL_VERSION_NAME = 2;
        public static int NULL_PERMISSION = 3;
        public static int NULL_ICON = 4;
        public static int NULL_CERT_FILE = 5;
        public static int BAD_CERT = 6;
        public static int NULL_SF_FILE = 7;
        public static int BAD_SF = 8;
        public static int NULL_MANIFEST = 9;
        public static int NULL_RESOURCES = 10;
        public static int NULL_DEX = 13;
        public static int NULL_METAINFO = 14;
        public static int BAD_JAR = 11;
        public static int BAD_READ_INFO = 12;
        public static int NULL_FILE = 15;
        public static int HAS_REF = 16;


        public List<String> Permissions;
        public bool hasIcon;
        public List<String> iconFileName;
        public List<String> iconFileNameToGet;
        public List<String> iconHash;
        public String label;
        public Dictionary<String, String> layoutStrings;
        public String minSdkVersion;
        public String packageName;
        public Dictionary<String, List<String>> resStrings;
        public byte[] resourcesFileBytes;
        public String resourcesFileName;
        public bool supportAnyDensity;
        public bool supportLargeScreens;
        public bool supportNormalScreens;
        public bool supportSmallScreens;
        public String targetSdkVersion;
        public String versionCode;
        public String versionName;

        public ApkInfo()
        {
            hasIcon = false;
            supportSmallScreens = false;
            supportNormalScreens = false;
            supportLargeScreens = false;
            supportAnyDensity = true;
            versionCode = null;
            versionName = null;
            iconFileName = null;
            iconFileNameToGet = null;

            Permissions = new List<String>();
        }

        public static bool supportSmallScreen(byte[] dpi)
        {
            if (dpi[0] == 1)
                return true;
            return false;
        }

        public static bool supportNormalScreen(byte[] dpi)
        {
            if (dpi[1] == 1)
                return true;
            return false;
        }

        public static bool supportLargeScreen(byte[] dpi)
        {
            if (dpi[2] == 1)
                return true;
            return false;
        }

        //public byte[] getDPI()
        //{
        //    byte[] dpi = new byte[3];
        //    if (this.supportAnyDensity)
        //    {
        //        dpi[0] = 1;
        //        dpi[1] = 1;
        //        dpi[2] = 1;
        //    }
        //    else
        //    {
        //        if (this.supportSmallScreens)
        //            dpi[0] = 1;
        //        if (this.supportNormalScreens)
        //            dpi[1] = 1;
        //        if (this.supportLargeScreens)
        //            dpi[2] = 1;
        //    }
        //    return dpi;
        //}

        private bool isReference(List<String> strs)
        {
            try
            {
                foreach (String str in strs)
                {
                    if (isReference(str))
                        return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }

        private bool isReference(String str)
        {
            try
            {
                if (str != null && str.StartsWith("@"))
                {
                    int.Parse(str, NumberStyles.HexNumber);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }
    }
}