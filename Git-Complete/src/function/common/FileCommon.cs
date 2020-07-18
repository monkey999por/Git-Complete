using System;
using System.Collections.Generic;
using System.Text;
using Git_Complete.src.entity;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Git_Complete.src.function.common
{
    class FileCommon
    {

        public static void OutFileTo<T>(T obj, String outPath)
        {

            Directory.CreateDirectory(Path.GetDirectoryName(outPath));

            //File.Delete(outPath);

            try
            {
                var serializer = new DataContractSerializer(typeof(T));

                using (var fs = new FileStream(outPath, FileMode.Create))
                using (var xw = XmlWriter.Create(fs, new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t"
                }))
                {
                    // オブジェクトをシリアル化してXMLファイルに書き込む
                    serializer.WriteObject(xw, obj);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);

                throw new Exception();
            }
        }

        public static T GetInstanceFrom<T>(String filePath)
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(T));

                using (var fs = new FileStream(filePath, FileMode.Open))
                using (XmlWriter xw = XmlWriter.Create(fs, new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t"

                }))
                {
                    // XMLファイルからオブジェクトを読み込む
                    var ret = (T)serializer.ReadObject(fs);
                    return ret;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception();
            }
        }
    }
}
