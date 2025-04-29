using System.IO;

namespace CSV_UFO;

class Program
{
    // //Define UFO class. This will contain all info per UFO sighting
    // public class UFO
    // {
    //     public DateTime Observed { get; set; }
    //     public string? City { get; set; }
    //     public string? State { get; set; }
    //     public string? Country { get; set; }
    //     public string? Shape { get; set; }
    //     public DateTime Duration_Seconds { get; set; }
    //     public DateTime DurationHoursMinutes { get; set; }
    //     public string? Comments { get; set; }
    //     public DateOnly DatePosted { get; set; }
    //     public string? Latitude { get; set; }
    //     public string? Longitude { get; set; }
    // }

    static void Main(string[] args)
    {
        string path = @"C:\Users\Instruktor\Desktop\CSharp\CSV_UFO\scrubbed.csv";

        //Read all lines from file into variable
        var lines = File.ReadAllLines(path);

        //Declare ufo object array
        UFO[] ufo = new UFO[lines.Length];

        //Instantiate each ufo object. Each file line corresponds to a ufo object
        //Line 0 in lines are the headers
        for (int j = 1; j < lines.Length; j++)
        {
            ufo[j] = new UFO();
        }

        //Line 0 in lines are the headers
        for (int i = 1; i < lines.Length; i++)
        {
            //DateTime dateValue;

            //Split each value pr/line based on field separator in file (in this case, a semicolon)
            string[] values = lines[i].Split(",");

            //Parse string into DateTime type
            //Something wrong happens here, using strings for the time being
            // if (DateTime.TryParse(values[1], out dateValue))
            //     ufo[i].Observed = dateValue;

            //Add each value into the corresponding object property
            ufo[i].Observed = values[0];
            ufo[i].City = values[1];
            ufo[i].State = values[2];
            ufo[i].Country = values[3];
            ufo[i].Shape = values[4];
            ufo[i].Duration_Seconds = values[5];
            ufo[i].DurationHoursMinutes = values[6];
            ufo[i].Comments = values[7];
            ufo[i].DatePosted = values[8];
            ufo[i].Latitude = values[9];
            ufo[i].Longitude = values[10];

            //Test output
            Console.WriteLine($"Time observed: {ufo[i].Observed} City: {ufo[i].City}");
        }
    }
}
