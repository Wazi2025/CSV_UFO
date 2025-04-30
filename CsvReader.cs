public class CsvFileReader
{
    static public string path = @"C:\Users\Instruktor\Desktop\CSharp\CSV_UFO\scrubbed.csv";

    static public DateTime ConvertToDateTime(string stringDate)
    {
        DateTime result;

        //Parse string into DateTime type            
        if (DateTime.TryParse(stringDate, out result))
        {

        }

        return result;
    }

    static public void ReadFile()
    {
        //Read all lines from file into variable
        var lines = File.ReadAllLines(path);

        //Instantiate ufo object array
        UFO[] ufo = new UFO[lines.Length];

        //Instantiate each ufo object in the ufo array. Each file line corresponds to a ufo object
        //Line 0 in lines are the headers
        for (int j = 1; j < lines.Length; j++)
        {
            ufo[j] = new UFO();
        }

        //Line 0 in lines are the headers
        for (int i = 1; i < lines.Length; i++)
        {
            //Split each value pr/line based on field separator in file (in this case, a semicolon)
            string[] values = lines[i].Split(",");

            //Parse string into DateTime type            
            // if (DateTime.TryParse(values[0], out dateValue))
            // {
            //     ufo[i].Observed = dateValue;
            //     Console.WriteLine($"{ufo[i].Observed}");
            // }

            ufo[i].Observed = ConvertToDateTime(values[0]);
            //Console.WriteLine($"{ufo[i].Observed}");

            //Add each value into the corresponding object property            
            ufo[i].City = values[1];
            ufo[i].State = values[2];
            ufo[i].Country = values[3];
            ufo[i].Shape = values[4];

            //Note: Only Observed, Duration_Seconds and DatePosted is actually a Date/Time value in the file
            ufo[i].Duration_Seconds = ConvertToDateTime(values[5]);
            //Console.WriteLine($"{ufo[i].Duration_Seconds}");

            //ufo[i].Duration_Seconds = values[5];
            ufo[i].DurationHoursMinutes = values[6];

            //Console.WriteLine($"{ufo[i].DurationHoursMinutes}");

            ufo[i].Comments = values[7];
            //ufo[i].DatePosted = values[8];

            ufo[i].DatePosted = ConvertToDateTime(values[8]);
            //Console.WriteLine($"{ufo[i].DatePosted}");

            ufo[i].Latitude = values[9];
            ufo[i].Longitude = values[10];

            //Test output
            Console.WriteLine($"Observed: {ufo[i].Observed} Duration (seconds): {ufo[i].Duration_Seconds} Duration (hours): {ufo[i].DurationHoursMinutes} Date posted: {ufo[i].DatePosted}");
            //Console.WriteLine($"Time observed: {ufo[i].Observed} City: {ufo[i].City}");
        }
    }
}