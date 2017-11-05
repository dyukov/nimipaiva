using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDay
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var csvFileName = ConfigurationManager.AppSettings["defaultnamefile"];
                var currentDir = Path.GetDirectoryName(System.Diagnostics.Process.G‌​etCurrentProcess().M‌​ainModule.FileName);

                List<string> nameDaysList = File.ReadAllLines(currentDir + "/" + csvFileName).ToList(); // Using List<T> here, so that íts easier to query
                var initialInput = (args.Length == 0) ? "" : args[0];
                evaluateUserInput(nameDaysList, initialInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception while fetching your Name Day. Exception {0}; Inner Exception: {1}", ex.ToString(), ex.InnerException));
            }
        }

        // REPL 
        private static void evaluateUserInput(List<string> csvNames, string userInput)
        {
            if (userInput == "q" || userInput == "Q")
            {
                Console.WriteLine("bye bye... ");
                return;
            }

            DateTime date;
            if (DateTime.TryParse(userInput, out date))
            {
                Console.WriteLine(string.Format("{0} : {1}", userInput, getNameByDate(csvNames, date)));
            }
            else
            {
                Console.WriteLine("Input could not be parsed as a valid date");
            }

            Console.WriteLine("Please, provide Date to get Names, or press 'q' + 'ENTER' to exit");
            var consoleInput = Console.ReadLine();
            evaluateUserInput(csvNames, consoleInput);
        }

        public static string getNameByDate(List<string> csvNames, DateTime date)
        {
            var dateNameLine = csvNames.Where(d => (d.StartsWith(date.Day + "." + date.Month))).FirstOrDefault();
            return string.IsNullOrEmpty(dateNameLine) ? "no name for this date." : dateNameLine.Split(';')[1];
        }
    }
}
