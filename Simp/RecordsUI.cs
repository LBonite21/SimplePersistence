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
            System.Console.WriteLine("- Employee Info Stuff -\n  1: Create New Employee \n  2: Go Through Records");
            System.Console.Write("Enter Choice: ");
            int input = int.Parse(System.Console.ReadLine());
            return input;
        }


    }
}