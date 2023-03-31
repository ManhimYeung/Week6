using SerialisationApp;

namespace Serialisation;

public class Program
{
    static ISerialise _serialiser;
    static string? _path;

    static void Main(string[] args)
    {
        Trainee trainee = new Trainee { FirstName = "Ali", LastName = "Cengiz", SpartaNo = 100};
        _path = @"C:\Users\manhi\Desktop\Sparta\Training\Week6Notes\Serialisation";

        _serialiser = new SerialiserXML();
        _serialiser.SerialiseToFile($"{_path}/XMLTrainee.xml", trainee);

        Trainee deserialisedXMLTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/XMLTrainee.xml");

        Course tech206 = new Course { Title = "Tech 206", Subject = "C# TAE", StartDate = new DateTime(2023, 2, 20) };
        tech206.AddTrainee(trainee);
        tech206.AddTrainee(new Trainee { FirstName = "Cormac", LastName = "Porter", SpartaNo = 101});
        _serialiser.SerialiseToFile($"{_path}/XMLCourse.xml", tech206);

        var editedCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/XMLCourseEdited.xml");

        _serialiser = new SerialiserJSON();
        _serialiser.SerialiseToFile($"{_path}/JsonTrainee.json", trainee);
        Trainee deserialisedJsonTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/JsonTrainee.json");
        _serialiser.SerialiseToFile($"{_path}/JsonCourse.json", tech206);

        _serialiser = new SerialiserYAML();
        _serialiser.SerialiseToFile($"{_path}/YamlTrainee.yaml", trainee);
        Trainee deserialisedYamlTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/YamlTrainee.yaml");
        _serialiser.SerialiseToFile($"{_path}/YamlCourse.yaml", tech206);
    }
}