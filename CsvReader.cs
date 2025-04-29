public class CsvFileReader
{
    static public string path = @"C:\Users\Instruktor\Desktop\CSharp\CSV_UFO\scrubbed.csv";

    // static public DateTime ConvertToDateTime(UFO ufo[i],string stringDate)
    // {
    //     DateTime result;
    //     //Parse string into DateTime type            
    //     if (DateTime.TryParse(stringDate, out result))
    //     {
    //         ufo[i].Observed = result;
    //         Console.WriteLine($"{ufo[i].Observed}");
    //     }

    //     return result;
    // }
    static public void ReadFile()
    {
        //string path = @"C:\Users\Instruktor\Desktop\CSharp\CSV_UFO\scrubbed.csv";

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
            DateTime dateValue;

            //Split each value pr/line based on field separator in file (in this case, a semicolon)
            string[] values = lines[i].Split(",");

            //Parse string into DateTime type            
            if (DateTime.TryParse(values[0], out dateValue))
            {
                ufo[i].Observed = dateValue;
                Console.WriteLine($"{ufo[i].Observed}");
            }

            //ConvertToDateTime(ufo[i].Observed,values[0]);

            //Add each value into the corresponding object property
            //ufo[i].Observed = values[0];
            ufo[i].City = values[1];
            ufo[i].State = values[2];
            ufo[i].Country = values[3];
            ufo[i].Shape = values[4];

            //Parse string into DateTime type            
            if (DateTime.TryParse(values[5], out dateValue))
            {
                ufo[i].Duration_Seconds = dateValue;
                Console.WriteLine($"{ufo[i].Duration_Seconds}");
            }

            //ufo[i].Duration_Seconds = values[5];
            //ufo[i].DurationHoursMinutes = values[6];

            if (DateTime.TryParse(values[6], out dateValue))
            {
                ufo[i].DurationHoursMinutes = dateValue;
                Console.WriteLine($"{ufo[i].DurationHoursMinutes}");
            }

            ufo[i].Comments = values[7];
            //ufo[i].DatePosted = values[8];

            if (DateTime.TryParse(values[8], out dateValue))
            {
                ufo[i].DatePosted = dateValue;
                Console.WriteLine($"{ufo[i].DatePosted}");
            }

            ufo[i].Latitude = values[9];
            ufo[i].Longitude = values[10];

            //Test output
            Console.WriteLine($"Time observed: {ufo[i].Observed} City: {ufo[i].City}");
        }
    }
}