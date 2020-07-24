using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Git_Complete.src.function.common
{
    class FileCommon
    {
        /// <summary>
        /// シリアライズされたオブジェクトをjsonファイルに書き出す
        /// </summary>
        /// <typeparam name="T">出力するオブジェクトの型</typeparam>
        /// <param name="obj">出力するオブジェクト</param>
        /// <param name="outPath">出力先のフルパス。</param>
        public static void OutFileToJson<T>(T obj, String outPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outPath));

            try
            {
                var settings = new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };
                var serializer = JsonSerializer.Create(settings);

                using var fs = new FileStream(outPath, FileMode.Create);
                using var sw = new StreamWriter(fs);
                using var jsonTextWriter = new JsonTextWriter(sw);

                // オブジェクトをシリアル化してXMLファイルに書き込む
                serializer.Serialize(jsonTextWriter, obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception();
            }
        }

        /// <summary>
        /// jsonファイルからシリアル化されたオブジェクトを読み込んで返す。
        /// </summary>
        /// <typeparam name="T">シリアル化されたオブジェクトの型</typeparam>
        /// <param name="filePath">読み込むxmlフルパス</param>
        /// <returns></returns>
        public static T GetInstanceFromJson<T>(String filePath)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };
                var serializer = JsonSerializer.Create(settings);

                using var fs = new FileStream(filePath, FileMode.Open);
                using var sw = new StreamReader(fs);

                var ret = JsonConvert.DeserializeObject<T>(sw.ReadToEnd());

                return (T)ret;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception();
            }
        }

        /// <summary>
        /// シリアライズされたオブジェクトをxmlファイルに書き出す
        /// </summary>
        /// <typeparam name="T">出力するオブジェクトの型</typeparam>
        /// <param name="obj">出力するオブジェクト</param>
        /// <param name="outPath">出力先のフルパス。</param>
        public static void OutFileToXml<T>(T obj, String outPath)
        {
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
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception();
            }
        }

        /// <summary>
        /// xmlファイルからシリアル化されたオブジェクトを読み込んで返す。
        /// </summary>
        /// <typeparam name="T">シリアル化されたオブジェクトの型</typeparam>
        /// <param name="filePath">読み込むxmlフルパス</param>
        /// <returns></returns>
        public static T GetInstanceFromXml<T>(String filePath)
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(T));

                using var fs = new FileStream(filePath, FileMode.Open);
                using XmlWriter xw = XmlWriter.Create(fs, new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t"

                });
                // XMLファイルからオブジェクトを読み込む
                var ret = (T)serializer.ReadObject(fs);
                return ret;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception();
            }
        }
    }
}
