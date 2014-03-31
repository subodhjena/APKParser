using System;
using System.IO;
using ApkParser.Model;
using APKParser.Zipper;
using ApkParser;

namespace APKParser
{
    public class ParseApk
    {
        public ApkInfo ParseApkInfo(String filePath)
        {
            // Reading the APK File
            var apkReader = new ApkReader();

            //Unzipping the APK file to read the information from the APK file
            var unzipApk = new UnzipApk();
            unzipApk.UnzipApkFile(filePath);

            //Variables will store the binary data
            byte[] manifestData = null;
            byte[] resourcesData = null;

            // Looping through each and every sub directory in the extracted directory
            String zipExtractFileDirectory = Path.GetDirectoryName(filePath) + "\\" +
                                             Path.GetFileNameWithoutExtension(filePath);
            try
            {
                foreach (string file in Directory.GetFiles(zipExtractFileDirectory))
                {
                    var fileName = Path.GetFileName(file);

                    if (fileName != null && fileName.ToLower() == "androidmanifest.xml")
                    {
                        manifestData = new byte[50*1024];
                        using (var binaryStream = new BinaryReader(File.Open(file, FileMode.Open)))
                        {
                            manifestData = binaryStream.ReadBytes((int)binaryStream.BaseStream.Length);
                        }
                    }
                    else if (fileName != null && fileName.ToLower() == "resources.arsc")
                    {
                        using (var binaryStream = new BinaryReader(File.Open(file, FileMode.Open)))
                        {
                            resourcesData = binaryStream.ReadBytes((int)binaryStream.BaseStream.Length);
                        }
                    }
                }

                // Reading the manifest file and Resources file
                var apkInfo = apkReader.ExtractInfo(manifestData, resourcesData);
                return apkInfo;
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                return null;
            }
        }
    }
}