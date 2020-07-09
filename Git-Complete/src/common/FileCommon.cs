using System;
using System.Collections.Generic;
using System.Text;
using Git_Complete.src.entity;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Git_Complete.src.common
{
    class FileCommon
    {

       public void OutFileTo<T>(T obj, String outPath)
        {
            if (obj is null)
            { 
                throw new Exception();

            }
            Directory.CreateDirectory(Path.GetDirectoryName(outPath));

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
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public T getInstanceFrom<T>(String filePath)
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
            catch (Exception)
            {
                throw new Exception();
            } 
        }
    }
}
