using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;



public class CsvFileReader
{
    //static public string filePath = @"D:\VSCode\CSharp\CSV_UFO\Data\scrubbed.csv";
    public const string dateSeparator = "/";
    public const string fileName = "scrubbed.csv";
    public const string fileDataDir = "Data";
    public const string fileFieldSeparator = ",";





    static public DateObject ConvertToDateTime(string stringDate, DateObject dateObject)
    {
        DateTime resultDateTime;
        DateOnly resultDateOnly;

        string month;
        string day;
        string year;
        //string time;
        string temp;

        temp = stringDate;

        //Split the date based on dateSeparator
        //The date in the file uses the US date style, mm/dd/yyyy
        string[] split = temp.Split(dateSeparator);
        day = split[1];
        month = split[0];
        year = split[2];

        // if (year.Length > 4)
        // {
        //     string[] yearSplit = year.Split(" ");
        //     year = yearSplit[0];
        //     time = yearSplit[1];

        //     stringDate = day + dateSeparator + month + dateSeparator + year + " " + time;
        // }
        // else
        stringDate = day + dateSeparator + month + dateSeparator + year;

        //Parse string into DateTime type           
        if (DateTime.TryParse(stringDate, out resultDateTime))
        {
            dateObject.DateTimeValue = resultDateTime;
        }

        //If year.Length is less than 5 we know it's a DateOnly value
        if (year.Length < 5)
        {
            if (DateOnly.TryParse(stringDate, out resultDateOnly))
            {
                dateObject.DateOnlyValue = resultDateOnly;
            }
        }

        return dateObject;
    }


    public void ReadFile()
    {
        #region
        //Something isn't right here. It works fine when debugging but crashes when running the compiled exe by itself
        //Update: the compiler seems to be looking for the Data dir in D:\VSCode\CSharp\CSV_UFO\bin\Release and not 
        // D:\VSCode\CSharp\CSV_UFO\bin\Release\net9.0\win-x64\publish (where the published
        // .exe actually is. ????)

        //Set the application path
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;

        //Combine application path with where the csv file is (\Data\scrubbed.csv)
        //Should eliminate hardcoding of file path as long as it's in the \Data dir with the compiled .exe a level above
        string filePath = Path.Combine(projectRoot, fileDataDir, fileName);
        #endregion

        //Read all lines from file into variable  
        //Note: This is not advisable when using extremely large files since it loads the entire file
        //into memory
        //In those cases File.ReadLines is a better solution
        string[] lines = File.ReadAllLines(filePath);

        //Instantiate combined DateOnly and DateTime object
        //We will use this to effectively have two return values in ConvertToDateTime, thereby allowing us to get rid of
        //the un-sightly '00:00:00' values in the ufo.DatePosted field
        //We could, of course simply have a ConvertToDateOnly method but where's the fun in that ;-)
        DateObject dateObject = new DateObject();

        //Instantiate ufo object array
        UFO[] ufo = new UFO[lines.Length];

        //Instantiate each ufo object in the ufo array. Each file line corresponds to an instantiated ufo object
        //Line 0 in lines are the headers
        for (int j = 1; j < lines.Length; j++)
        {
            ufo[j] = new UFO();
        }

        //Line 0 in lines are the headers
        for (int i = 1; i < lines.Length; i++)
        {
            //Split each value pr/line based on field separator in file (in this case, a semicolon)
            string[] values = lines[i].Split(fileFieldSeparator);

            dateObject = ConvertToDateTime(values[0], dateObject);

            ufo[i].Observed = dateObject.DateTimeValue;

            //ufo[i].Observed = ConvertToDateTime(values[0]);

            //Add each value into the corresponding object property            
            ufo[i].City = values[1];
            ufo[i].State = values[2];
            ufo[i].Country = values[3];
            ufo[i].Shape = values[4];

            //Note: Only Observed, Duration_Seconds and DatePosted is actually a Date/Time value in the file

            //Just use a string to store seconds for now. I need a break.
            ufo[i].Duration_Seconds = values[5];

            ufo[i].DurationHoursMinutes = values[6];
            ufo[i].Comments = values[7];

            dateObject = ConvertToDateTime(values[8], dateObject);
            ufo[i].DatePosted = dateObject.DateOnlyValue;

            ufo[i].Latitude = values[9];
            ufo[i].Longitude = values[10];

            //Test output
            Console.WriteLine($"Observed: {ufo[i].Observed} | Duration (seconds): {ufo[i].Duration_Seconds} | Duration (hours): {ufo[i].DurationHoursMinutes} | Date posted: {ufo[i].DatePosted}");
        }
    }//End ReadFile
}