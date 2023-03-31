using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationApp;

public class SerialiserXML : ISerialise
{
    public T DeserialiseFromFile<T>(string filePath)
    {
        // create Stream object for reading
        Stream fileStream = File.OpenRead(filePath);
        // Create an XMLSerialiser object (from the System.Xml.Serialization namespace)
        var reader = new XmlSerializer(typeof(T));
        var deserialisedItem = (T)reader.Deserialize(fileStream);
        fileStream.Close();
        return deserialisedItem;
    }

    public void SerialiseToFile<T>(string filePath, T item)
    {
        // Sets up a file stream for us to write to
        FileStream fileStream = File.Create(filePath);
        // Create an XMLSerialiser object (from the System.Xml.Serialization namespace)
        XmlSerializer writer = new XmlSerializer(item.GetType());
        // Use the serialiser to serialise the item to file
        writer.Serialize(fileStream, item);
        fileStream.Close();
    }
}
