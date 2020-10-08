using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Simp
{
    internal class SimplePersistence
    {

        private bool ChoiceSelected;

        public SimplePersistence()
        {

        }

        public void run()
        {
            RecordsUI info = new RecordsUI();
            while (!ChoiceSelected)
            {
                Selection(info.MenuSelection());
            }

        }

        public bool Selection(int UserSelction)
        {

            switch (UserSelction)
            {
                case 0:
                    System.Console.WriteLine("Closing . . . . . .");
                    ChoiceSelected = true;
                    break;
                case 1:
                    PrintEmployee(@"C:\Users\Anibal Tinoco\source\repos\SimplePersistence\Simp\people\simple\");
                    System.Console.WriteLine("yes 1");
                    ChoiceSelected = true;
                    break;

                case 2:

                    PrintPeopleDetails($@"D:\temp\people\simple\");
                    System.Console.WriteLine("yes 2");
                    ChoiceSelected = true;
                    break;

                default:
                    System.Console.WriteLine("Please enter the number options of 1 or 2");
                    break;
            }

            return ChoiceSelected;


        }

        public void PrintEmployee(string path)
        {
            //take that path
            //grab the file split
            //create a user with that info
            //display it to the user

            
            

            for (int i = 1; i < 10; i++)
            {
                string pathpath = path + $"{i}.txt";

                List<string> lines = new List<string>();

               
                
                lines = File.ReadAllText(pathpath).ToList;
                
                System.Console.WriteLine();
            }

        }

        public void PrintPeopleDetails(string path)
        {

        }
    }
}