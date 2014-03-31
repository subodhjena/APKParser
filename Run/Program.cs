using System;
using APKParser;
using ApkParser.Model;

namespace Run
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Path to the APK file
            const string filePath = @"C:\Users\subodh\Downloads\Android Sample APKs\OnePunch Notes.apk";

            //Parsing the APK file
            var parseApk = new ParseApk();
            ApkInfo apkInfo = parseApk.ParseApkInfo(filePath);

            Console.WriteLine("Package Name: {0}", apkInfo.packageName);
            Console.WriteLine("Version Name: {0}", apkInfo.versionName);
            Console.WriteLine("Version Code: {0}", apkInfo.versionCode);

            Console.WriteLine("App Has Icon: {0}", apkInfo.hasIcon);
            if (apkInfo.iconFileName.Count > 0)
                Console.WriteLine("App Icon: {0}", apkInfo.iconFileName[0]);
            Console.WriteLine("Min SDK Version: {0}", apkInfo.minSdkVersion);
            Console.WriteLine("Target SDK Version: {0}", apkInfo.targetSdkVersion);

            if (apkInfo.Permissions != null && apkInfo.Permissions.Count > 0)
            {
                Console.WriteLine("Permissions:");
                apkInfo.Permissions.ForEach(f => Console.WriteLine(string.Format("{0}", f)));
            }
            else
                Console.WriteLine("No Permissions Found");

            Console.WriteLine("Supports Any Density: {0}", apkInfo.supportAnyDensity);
            Console.WriteLine("Supports Large Screens: {0}", apkInfo.supportLargeScreens);
            Console.WriteLine("Supports Normal Screens: {0}", apkInfo.supportNormalScreens);
            Console.WriteLine("Supports Small Screens: {0}", apkInfo.supportSmallScreens);

            Console.ReadLine();
        }
    }
}