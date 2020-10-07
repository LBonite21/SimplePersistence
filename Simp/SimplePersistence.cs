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
            Selection(info.MenuSelection());
        }

        public void Selection(int UserSelction)
        {
            do
            {
                switch (UserSelction)
                {
                    case 1:
                        CreateEmployeeRecord();
                        System.Console.WriteLine("yes 1");
                        ChoiceSelected = true;
                        break;

                    case 2:

                        EmployeeSearch();
                        System.Console.WriteLine("yes 2");
                        ChoiceSelected = true;
                        break;

                    default:
                        System.Console.WriteLine("Please enter the number options of 1 or 2");
                       
                        return;
                }

            } while (!ChoiceSelected);


        }

        public void CreateEmployeeRecord()
        {

        }

        public void EmployeeSearch()
        {

        }
    }
}