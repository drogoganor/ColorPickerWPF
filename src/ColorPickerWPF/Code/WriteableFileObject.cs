using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace ColorPickerWPF.Code
{
    [Serializable]
    public class WriteableFileObject<T>
    {
        public void SaveToXml(string filename)
        {
            var xml = GetXmlText();

            File.WriteAllText(filename, xml);
        }

        public static T LoadFromXml(string filename)
        {
            T result = default(T);
            if (File.Exists(filename))
            {
                var sr = new StreamReader(filename);
                var xr = new XmlTextReader(sr);

                var xmlSerializer = new XmlSerializer(typeof(T));
                
                result = (T)xmlSerializer.Deserialize(xr);

                xr.Close();
                sr.Close();
                xr.Dispose();
                sr.Dispose();
            }
            return result;
        }
        

        public static T LoadFromXmlText(string xml)
        {
            T result = default(T);
            if (!String.IsNullOrEmpty(xml))
            {
                var xr = XmlReader.Create(new StringReader(xml));

                var xmlSerializer = new XmlSerializer(typeof(T));
                
                result = (T)xmlSerializer.Deserialize(xr);

                xr.Close();
                xr.Dispose();
            }
            return result;
        }

        public static T LoadFromDataBlob(byte[] data)
        {
            T result = default(T);
            if (data != null && data.Length > 0)
            {
                var formatter = new BinaryFormatter();
                var stream = new MemoryStream(data, 0, data.Length);
                stream.Position = 0;
                result = (T)formatter.Deserialize(stream);
            }
            return result;
        }

        public static T LoadFromBinaryFile(string filename)
        {
            T result = default(T);
            if (File.Exists(filename))
            {
                var bytes = File.ReadAllBytes(filename);

                var formatter = new BinaryFormatter();
                var stream = new MemoryStream(bytes, 0, bytes.Length);
                stream.Position = 0;
                result = (T)formatter.Deserialize(stream);
            }
            return result;
        }


        public void SaveToBinaryFile(string filename)
        {
            var bytes = GetByteData();

            File.WriteAllBytes(filename, bytes);
        }



        public string GetXmlText()
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            var sww = new StringWriter();

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    ",
                NewLineOnAttributes = false,
                //OmitXmlDeclaration = true
            };
            var writer = XmlWriter.Create(sww, settings);

            xmlSerializer.Serialize(writer, this);
            var xml = sww.ToString();

            writer.Close();
            writer.Dispose();

            return xml;
        }


        public byte[] GetByteData()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            try
            {
                formatter.Serialize(stream, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Return the streamed object graph.

            stream.Position = 0;

            byte[] bytes = null;
            if (stream.Length > 0)
            {
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
            }
            stream.Close();
            stream.Dispose();
            

            return bytes;
        }

    }
}