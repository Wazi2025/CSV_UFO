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
        
        var lines = File.ReadAllLines(path);
        UFO[] ufo = new UFO[lines.Length];

        for (int j = 1; j < lines.Length; j++)
        {
            ufo[j] = new UFO();
        }

        for (int i = 1; i < lines.Length; i++)
        {

            string[] values = lines[i].Split(",");
            DateTime result;

            if (DateTime.TryParse(values[1], out result))
                ufo[i].Observed = result;

            ufo[i].City = values[1];
            ufo[i].State = values[2];
            ufo[i].Country = values[3];
            ufo[i].Shape = values[4];

        }
    }
}
