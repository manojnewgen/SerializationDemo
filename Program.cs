using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");

        var memberDetail = new Person { UserName = "Manoj", UserAge = 30 };

        // Perform Binary Serialization
        SerializeToBinary(memberDetail, "Person.dat");

        // Perform XML Serialization
        SerializeToXml(memberDetail, "person.xml");

        // Perform JSON Serialization
        SerializeToJson(memberDetail, "person.json");

        Console.WriteLine("All serializations are complete.");
    }

    // Method to serialize to binary format
    private static void SerializeToBinary(Person memberDetail, string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            bw.Write(memberDetail.UserName);
            bw.Write(memberDetail.UserAge);
        }
        Console.WriteLine($"Binary serialization completed to {fileName}");
    }

    // Method to serialize to XML format
    private static void SerializeToXml(Person memberDetail, string fileName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
        using (var sw = new StreamWriter(fileName))
        {
            xmlSerializer.Serialize(sw, memberDetail);
        }
        Console.WriteLine($"XML serialization completed to {fileName}");
    }

    // Method to serialize to JSON format
    private static void SerializeToJson(Person memberDetail, string fileName)
    {
        var jsonString = JsonSerializer.Serialize(memberDetail);
        File.WriteAllText(fileName, jsonString);
        Console.WriteLine($"JSON serialization completed to {fileName}");
    }
}

public class Person
{
    public string UserName { get; set; }
    public int UserAge { get; set; }
}
