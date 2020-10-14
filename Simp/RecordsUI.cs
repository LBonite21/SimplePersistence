namespace Simp
{
    internal class RecordsUI
    {
        public RecordsUI()
        {
            
        }

        public int MenuSelection()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("- Employee Info Stuff -\n \n  1: Display Raw Employee Data \n  2: Go Through Records \n  3: Add Employee \n  4: Delete Employee \n  5: Update Employee \n  0: Exit");
            System.Console.Write("Enter Choice: ");
            int input = int.Parse(System.Console.ReadLine());
            return input;
        }

        public int RequestInt(string message)
        {
            System.Console.Write(message);
            int input = int.Parse(System.Console.ReadLine());
            return input;
        }

        public string RequestString(string message)
        {
            System.Console.Write(message);
            string input = System.Console.ReadLine();

            return input;
        }

    }
}