using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp;

public class SerialiserJSON : ISerialise
{
    public T DeserialiseFromFile<T>(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(jsonString);
    }

    public void SerialiseToFile<T>(string filePath, T item)
    {
        string jsonString = JsonConvert.SerializeObject(item);
        File.WriteAllText(filePath, jsonString);
    }
}
