// See https://aka.ms/new-console-template for more information

using System.Data;

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

    }

    private static async Task LoadPerson()
    {
        var json = await SunProcessor.LoadSun();
        
        // var json = await ImportJson.Loader("https://jsonplaceholder.typicode.com/users");
        Console.WriteLine(json);
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

}

