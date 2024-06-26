using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializationLibrary
{
    public class SerializationHelper
    {
        // XML Serialization
        public void SerializeToXml<T>(T data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, data);
            }
        }

        public T DeserializeFromXml<T>(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        // JSON Serialization using System.Text.Json
        public void SerializeToJson<T>(T data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }

        public T DeserializeFromJson<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        // Binary Serialization using System.Text.Json
        public void SerializeToBinary<T>(T data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllBytes(filePath, System.Text.Encoding.UTF8.GetBytes(json));
        }

        public T DeserializeFromBinary<T>(string filePath)
        {
            var json = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(filePath));
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}