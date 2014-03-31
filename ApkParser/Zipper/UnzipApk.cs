using System;
using System.IO;
using Ionic.Zip;

namespace APKParser.Zipper
{
    internal class UnzipApk
    {
        public void UnzipApkFile(String filePath)
        {
            try
            {
                var zipFileDirectory = Path.GetDirectoryName(filePath);
                var zipExtractFileDirectory = zipFileDirectory + "\\" + Path.GetFileNameWithoutExtension(filePath);

                // If exists then delete folder 
                if (Directory.Exists(zipExtractFileDirectory))
                {
                    Directory.Delete(zipExtractFileDirectory, true);
                }

                // Extract the zip
                using (ZipFile zip = ZipFile.Read(filePath))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(zipExtractFileDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Error in extracting the APK file, Please consider the below Message.");
                Console.WriteLine(x.StackTrace);
            }
        }
    }
}