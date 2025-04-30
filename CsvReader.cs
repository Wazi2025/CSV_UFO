using System.Globalization;

public class CsvFileReader
{
    //static public string filePath = @"D:\VSCode\CSharp\CSV_UFO\Data\scrubbed.csv";


    static public DateTime ConvertToDateTime(string stringDate)
    {
        DateTime result;

        const string dateSeparator = "/";
        string month;
        string day;
        string year;
        string temp;

        temp = stringDate;

        //Split the date based on dateSeparator
        //The date in the file uses the US date style, mm/dd/yyyy
        var split = temp.Split(dateSeparator);
        day = split[1];
        month = split[0];
        year = split[2];

        stringDate = day + dateSeparator + month + dateSeparator + year;

        //Parse string into DateTime type           
        if (DateTime.TryParse(stringDate, out result))
        {

        }
        return result;
    }

    static public DateOnly ConvertToDate(string stringDate)
    {
        DateOnly result;
        //CultureInfo uk = new CultureInfo("en-GB");

        const string dateSeparator = "/";
        string month;
        string day;
        string year;
        string temp;

        temp = stringDate;

        //Split the date based on dateSeparator
        //The date in the file uses the US date style, mm/dd/yyyy
        var split = temp.Split(dateSeparator);
        day = split[1];
        month = split[0];
        year = split[2];

        stringDate = day + dateSeparator + month + dateSeparator + year;

        //Parse string into Date type            
        //if (DateOnly.TryParse(stringDate, uk, 0, out result))
        if (DateOnly.TryParse(stringDate, out result))
        {

        }
        return result;
    }

    public void ReadFile()
    {
        #region
        //Something isn't right here. It works fine when debugging but crashes when running the compiled exe by itself
        //Update: the compiler seems to be looking for the Data dir in D:\VSCode\CSharp\CSV_UFO\bin\Release and not D:\VSCode\CSharp\CSV_UFO\bin\Release\net9.0\win-x64\publish (where the published
        // .exe actually is. ????)

        //Set the application path
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;

        //Combine application path with where the csv file is (\Data\scrubbed.csv)
        //Should eliminate hardcoding of file path as long as it's in the \Data dir with the compiled .exe a level above
        string filePath = Path.Combine(projectRoot, "Data", "scrubbed.csv");
        #endregion

        //Read all lines from file into variable        
        var lines = File.ReadAllLines(filePath);

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
            //
            //ufo[i].Duration_Seconds = ConvertToDateTime(values[5]);

            //Just use a string to store seconds
            ufo[i].Duration_Seconds = values[5];
            //Console.WriteLine($"{ufo[i].Duration_Seconds}");

            //ufo[i].Duration_Seconds = values[5];
            ufo[i].DurationHoursMinutes = values[6];

            //Console.WriteLine($"{ufo[i].DurationHoursMinutes}");

            ufo[i].Comments = values[7];
            //ufo[i].DatePosted = values[8];

            ufo[i].DatePosted = ConvertToDate(values[8]);
            //Console.WriteLine($"{ufo[i].DatePosted}");

            ufo[i].Latitude = values[9];
            ufo[i].Longitude = values[10];

            //Test output
            Console.WriteLine($"Observed: {ufo[i].Observed} Duration (seconds): {ufo[i].Duration_Seconds} Duration (hours): {ufo[i].DurationHoursMinutes} Date posted: {ufo[i].DatePosted}");
            //Console.WriteLine($"Time observed: {ufo[i].Observed} City: {ufo[i].City}");
        }
    }
}