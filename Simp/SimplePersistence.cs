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
                    PrintEmployee($@"D:\temp\people\simple\");
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

        }

        public void PrintPeopleDetails(string path)
        {
            //take that path
            //grab the file split
            //create a user with that info
            //display it to the user
        }
    }
}