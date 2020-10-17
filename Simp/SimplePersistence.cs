using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Simp
{
    internal class SimplePersistence
    {

        private bool ChoiceSelected;
        RecordsUI info = new RecordsUI();
        private bool foundEmployee;

        public SimplePersistence()
        {

        }

        public void run()
        {


            //while (!ChoiceSelected)
            //{
            //    Selection(info.MenuSelection());
            //    ChoiceSelected = true;
            //}

            ChoiceSelected = false;

            do
            {

                Selection(info.MenuSelection());

            } while (ChoiceSelected);

        }



        public bool Selection(int UserSelction)
        {

            switch (UserSelction)
            {
                case 0:
                    System.Console.WriteLine("Closing . . . . . .");
                    ChoiceSelected = true;
                    Environment.Exit(0);
                    break;
                case 1:
                    PrintPeopleDetails(info.getPath("Add a file path"));
                    ChoiceSelected = true;
                    break;
                case 2:
                    PrintEmployee(info.getPath("Add a file path"));
                    ChoiceSelected = true;
                    break;
                case 3:
                    Console.WriteLine("\nAdd Employee\n");
                    AddEmployee(info.getPath("Add a file path"),
                        info.RequestInt("Enter New Employee ID: "),
                        info.RequestString("Enter First Name: "),
                        info.RequestString("Enter Last Name: "),
                        info.RequestInt("Enter Hire Year: "));
                    ChoiceSelected = true;
                    break;
                case 4:
                    Console.WriteLine("\nDelete Employee\n");
                    Console.WriteLine("What is the ID of the employee you are gonna delete?");

                    string idString = Console.ReadLine();
                    int id = Int32.Parse(idString);

                    DeleteEmployee(info.getPath("Add a file path"), id);
                    ChoiceSelected = true;
                    break;
                case 5:
                    Console.WriteLine("Update Employee");
                    string filePath = info.getPath("Add a file path");
                    int EmployeeID;
                    do
                    {
                        EmployeeID = FindEmployeeById(info.RequestInt("What is the ID of the employee you are gonna update? "), filePath).ID;

                    } while (!foundEmployee);

                    UpdateEmployee(filePath, EmployeeID,
                    info.RequestString("Update First Name: "),
                    info.RequestString("Update New Last Name: "),
                    info.RequestInt("Update Hire Year: "));
                    ChoiceSelected = true;

                    break;
                case 6:
                    Console.WriteLine("\nSerialize Employees");
                    SerializeAllEmployees(info.getPath("Add File Path"));
                    ChoiceSelected = true;
                    break;
                case 7:
                    Console.WriteLine("\nGet Employee");
                    GetSerializedEmployee(info.getPath("Add a file path"), info.RequestInt("Enter Employee ID: "));
                    ChoiceSelected = true;
                    break;
                case 8:

                    break;
                case 9:
                    Console.WriteLine("\nSearch Employee By Last Name");
                    FindEmployeeByLastName(info.getPath("Add a file path"), info.RequestString("Enter Employee Last Name: "));
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

            System.Console.WriteLine("\n");

            string[] people = Directory.GetFiles(path, "*.txt");
            string[] persons;

            foreach (string person in people)
            {
                string getTextFile = System.IO.File.ReadAllText(person);
                persons = getTextFile.Split(",");

                for (int i = 0; i < persons.Length / 4; i++)
                {
                    int id = Int32.Parse(persons[0]);
                    int hireYear = Int32.Parse(persons[3]);
                    Employee newEmployee = new Employee(id, persons[1], persons[2], hireYear);
                    System.Console.WriteLine(newEmployee);
                }
            }

        }

        public void PrintPeopleDetails(string path)
        {
            //take that path
            //grab the file split
            //create a user with that info
            //display it to the user
            System.Console.WriteLine("\n");

            string[] people = Directory.GetFiles(path, "*.txt");

            foreach (string person in people)
            {
                string getTextFile = System.IO.File.ReadAllText(person);
                System.Console.WriteLine(getTextFile);
            }


        }

        private void AddEmployee(string path, int id, string firstName, string lastName, int HireYear)
        {
            String EmployeeRawData = id.ToString() + ", " + firstName.ToUpper() + ", " + lastName.ToUpper() + ", " + HireYear.ToString();

            System.IO.File.WriteAllText(path + $"{id}.txt", EmployeeRawData);

            Employee newEmployee = new Employee(id, firstName, lastName, HireYear);

            Console.WriteLine(newEmployee);



            // Adds a new file to the ${path} directory with the new details
        }

        private void DeleteEmployee(string path, int id)
        {
            // Deletes the record that matches the given id if it exists
            System.Console.WriteLine("\n");

            string file = $"{id}.txt";
            string deleteFile = $@"{path}\{file}";
            File.Delete(deleteFile);
            Console.WriteLine($"Deleted {file}");

        }



        private void UpdateEmployee(string path, int id, string firstName, string lastName, int HireYear)
        {
            DeleteEmployee(path, id);
            AddEmployee(path, id, firstName, lastName, HireYear);


            // Updates the correct file if it exists.

            // Should not be able to change the id of a user. ----------
        }

        private void SerializeAllEmployees(string path)
        {
            // Iterate through all the files in the ${path} directory
            // Create an Employee object for each file
            // Serialize each Employee object to the /${path}serialized/ directory in it's own file.

            System.Console.WriteLine("\n");

            string[] people = Directory.GetFiles(path, "*.txt");
            string[] persons;

            foreach (string person in people)
            {
                string getTextFile = File.ReadAllText(person);
                persons = getTextFile.Split(",");

                for (int i = 0; i < persons.Length / 4; i++)
                {
                    int id = Int32.Parse(persons[0]);
                    int hireYear = Int32.Parse(persons[3]);
                    Employee newEmployee = new Employee(id, persons[1], persons[2], hireYear);
                    System.Console.WriteLine(newEmployee);

                    FileStream fs = new FileStream($@"{path} serialized\{id}.txt", FileMode.Create, FileAccess.Write);
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        formatter.Serialize(fs, newEmployee);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                        throw;
                    }
                    finally
                    {
                        fs.Close();
                    }
                    Console.WriteLine("Object Serialized");

                }
            }

        }

        private Employee GetSerializedEmployee(string path, int id)
        {

            // Takes an id as a parameter
            id = FindEmployeeById(id, path).ID;
            // Fetches the associated serialized employee file and de-serializes it to an Employee object
            Employee newEmployee = null;
            FileStream fs = new FileStream($@"{path}\{id}.txt", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                newEmployee = (Employee)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            // Returns the Employee object

            // Console.WriteLine(newEmployee);

            return newEmployee;
        }

        private Employee FindEmployeeById(int id, string path)
        {
            Employee SearchedPerson = new Employee();
            foundEmployee = true;
            try
            {
                string[] people = Directory.GetFiles(path, $"{id}.txt");
                string[] peopleFound;


                string getTextFile = File.ReadAllText(people[0]);
                peopleFound = getTextFile.Split(",");

                for (int i = 0; i < peopleFound.Length / 4; i++)
                {
                    int foundID = Int32.Parse(peopleFound[0]);
                    int hireYear = Int32.Parse(peopleFound[3]);
                    SearchedPerson = new Employee(foundID, peopleFound[1], peopleFound[2], hireYear);

                }
                Console.WriteLine(SearchedPerson.ToString());
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Employee ID not found");
                foundEmployee = false;

            }

            //string file = $"{id}.txt";


            return SearchedPerson;
        }

        

        private Employee FindEmployeeByLastName(string path, string lastName)
        {
            //Searches all employee records for the first record with the given lastName
            //Returns the first matching record as an employee object

            Employee SearchedPerson = new Employee();
            foundEmployee = true;
            try
            {
                string[] people = Directory.GetFiles(path, "*.txt");
                string[] persons;
                int count = 0;
                int foundOnce = 0;
                bool firstFind = false;

                foreach (string person in people)
                {
                    string getTextFile = File.ReadAllText(person);
                    persons = getTextFile.Split(", ");


                    for (int i = 0; i < persons.Length / 4; i++)
                    {
                        
                        count++;
                        if (lastName.ToLower() == persons[2].ToLower())
                        {
                            foundOnce++;
                            int id = Int32.Parse(persons[0]);
                            int hireYear = Int32.Parse(persons[3]);
                            SearchedPerson = new Employee(id, persons[1], persons[2], hireYear);
                            firstFind = true;
                        }
                        else if (count == people.Length && !firstFind)
                        {
                            Console.WriteLine("\nEmployee not found.");
                        }

                        if (foundOnce == 1)
                        {
                            Console.WriteLine("\n" + SearchedPerson.ToString());

                        }

                    }


                }

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Employee not found");
                foundEmployee = false;

            }

            return SearchedPerson;
        }

        //C:\Users\Lemuel Bonite\source\repos\SuperLemon21\SimplePersistence\Simp\people\simple

        private List<Employee> FindAllEmployeesByLastName(string lastName)
        {
            //Searches all employee records for all employees with the given lastName
            //Returns a list of matching Employee Records
            throw new NotImplementedException();
        }

        private void PrintSerializedDetails(string path)
        {
            //Takes a path parameter
            //Iterates over each serialized(.ser) file in the given path
            //Deseralize the Employee Object and prints it's toString details
            throw new NotImplementedException();
        }

        private Dictionary<int, Employee> GetAllEmployees(string path)
        {
            //Returns a Dictonary<int, Employee> C#
            //Takes a path parameter
            //Iterates over each serialized(.ser) file in the given path
            //Deserialize the Employee Object
            //Add the Employee object to a HashMap keyed by the employees Id
            //Return the HashMap with all Employees records
            throw new NotImplementedException();
        }

        private void PrintAllEmployees()
        {
            //Call GetAllEmployees above
            //Loop through the values in your HashMap and print each Employees Details
            throw new NotImplementedException();
        }

    }
}