using System.IO;

namespace CSV_UFO;

class Program
{
    static void Main(string[] args)
    {
        //CsvFileReader.ReadFile();

        //Instantiate CsvFileReader object
        CsvFileReader Reader = new CsvFileReader();
        Reader.ReadFile();
    }//End Main
}//End Program
