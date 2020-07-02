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

       public void OutFileFrom<T>(T obj, String outPath)
        {
            if (obj is null)
            { 
                throw new Exception();

            }

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
    }
}
