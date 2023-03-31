using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SerialisationApp;

public class SerialiserYAML : ISerialise
{
    public T DeserialiseFromFile<T>(string filePath)
    {
        using (StreamReader fileStream = File.OpenText(filePath))
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();
            return deserializer.Deserialize<T>(fileStream);
        }
    }

    public void SerialiseToFile<T>(string filePath, T item)
    {
        using (StreamWriter fileStream = File.CreateText(filePath))
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            serializer.Serialize(fileStream, item);
        }
    }
}
