using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp;

[Serializable]
public class Trainee 
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int? SpartaNo { get; set; }
    [JsonIgnore]
    public string FullName => $"{FirstName} {LastName}";
    public override string? ToString() => $"{SpartaNo} - {FullName}";
}

[Serializable]
public class Course
{
    public string Subject { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public List<Trainee> Trainees { get; } = new List<Trainee>();
    [field: NonSerialized]
    private readonly DateTime _lastRead;
    public Course()
    {
        _lastRead = DateTime.Now;
    }
    public void AddTrainee(Trainee newTrainee)
    {
        Trainees.Add(newTrainee);
    }
}