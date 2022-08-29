// See https://aka.ms/new-console-template for more information

using System.Data;
using AutoMapper;

namespace One;

public class Program
{
    public static async Task Main()
    {
        ApiHelper.InitializeClient();
        // List<string> list = new List<string>();
        // int magicNumber = GuessMagicNumber.MagicNumber();
        // Console.WriteLine(magicNumber);

        await LoadPerson();

        // await SunProcessor.LoadSun();

    }

    private static async Task LoadPerson()
    {
        
        var people = await ImportJson.Loader<Person>("https://jsonplaceholder.typicode.com/users");
        var posts = await ImportJson.Loader<Post>("https://jsonplaceholder.typicode.com/posts");

        
        // Combine people with posts
        foreach (var person in people) person.posts = posts.Where(post => post.userId == person.id).ToList();
        
        foreach (var person in people)
        {
            var company = person.company;
            Console.WriteLine($"Person #{person.id}'s name is {person.name} and lives on {person.address.street} in {person.address.city}");
            Console.WriteLine($"{person.name} works for {company.name} as they say {company.catchPhrase}");
            Console.WriteLine($"Call {person.phone}, send a mail to {person.email} or visit {person.website}");
            Console.WriteLine($"You can also read one of {person.posts.Count} blog posts from {person.name}, a recommend read is {person.posts[0].title.ToUpper()}");
            Console.WriteLine("   ");
        }

        
    }

    public static void RunLib()
    {
        string carListString = "";
        string[] carList = Lib.GetCars();
        for (int i = 0; i < carList.Length; i++)
        {
            string car = carList[i];
            carListString += car + ", ";
        }
        Console.WriteLine(carListString);
    }

    public static void CapitalizeArray(string[] array, out int[] stringLengthArray)
    {
        stringLengthArray = Array.ConvertAll(array, new Converter<string, int>((x) => x.Length));
         var integerList = (string[] stringArray) =>
        {
            List<string> list = new List<string>();
            // Array.ForEach(stringArray,Action<string> (item) =>
            // {
            //     Console.Write(item);
            //     return "test";
            // });
        };

    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        return new MapperConfiguration(cfg => cfg.CreateMap<Person, Post>());
    }

}

