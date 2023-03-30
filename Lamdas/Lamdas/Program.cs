using System.Linq;
namespace Lamdas;

internal class Program
{
    static void Main(string[] args)
    {
        // Linq: Language integrated query
        // Syntax to mimic query databases

        var nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

        int allCount = nums.Count();
        int countEven = 0;
        foreach (var n in nums)
            if (IsEven(n)) countEven++;

        int linqCount = nums.Count(IsEven);

        var people = new List<Person>
        {
            new Person { Name = "Cormac", Age = 40, City = "Wexford"},
            new Person { Name = "Tahsin", Age = 55, City = "London"},
            new Person { Name = "Ali", Age = 20, City = "London"}
        };
        var youngPeopleCount = people.Count(IsYoung);

        int evenCount = nums.Count(delegate (int n) { return n % 2 == 0; });

        // Given this => return this
        int evenLambdaCount = nums.Count(n => n % 2 == 0);

        int peopleCount = people.Count();
        int youngPeopleCount2 = people.Count(p => p.Age < 30);
        int totalAge = people.Sum(p => p.Age);
        int oldPeopleTotalAge = people.Sum(p => p.Age >= 30 ? p.Age : 0);

        var peopleLondonQuery = people.Where(p => p.City == "London");
        foreach (var person in peopleLondonQuery)
            Console.WriteLine(person);

        var peopleOrderByAgeQuery = people.OrderBy(x => x.Age);
        foreach (var person in peopleOrderByAgeQuery)
            Console.WriteLine(person);

        var peopleOver20Query = people.Where(c => c.Age > 20).Select(p => p.Name);
        foreach (var p in peopleOver20Query)
            Console.WriteLine(p);

        var peopleOver20Array = peopleOver20Query.ToArray();

        //  Create list        Create query                         Execute Query
        var peopleLondonList = people.Where(p => p.City == "London").ToList();
    }

    public static int Square(int x) => x + x;

    public static bool IsYoung(Person person)
    {
        return person.Age < 30;
    }

    public static bool IsEven(int n)
    {
        return n % 2 == 0;
    }
    public class Person 
    {
        private int _age;
        public string Name { get; set; } 
        public int Age { 
            get => _age;
            set => _age = value < 0 ? throw new ArgumentException() : value;
        } 
        public string City { get; set; } 
        public override string ToString() 
        { 
            return $"{Name} - {City} - {Age}"; 
        }
    }
}