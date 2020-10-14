﻿using System;
using System.IO;

namespace Simp
{
    internal class SimplePersistence
    {

        private bool ChoiceSelected;
        RecordsUI info = new RecordsUI();

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

        //C:\Users\Lemuel Bonite\source\repos\SuperLemon21\SimplePersistence\Simp\people\simple

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
                    Console.WriteLine("Add a file path");
                    PrintEmployee(getPath(System.Console.ReadLine()) + @"\");
                    ChoiceSelected = true;
                    break;

                case 2:
                    Console.WriteLine("Add a file path");
                    PrintPeopleDetails(getPath(System.Console.ReadLine()) + @"\");
                    ChoiceSelected = true;
                    break;
                case 3:
                    Console.WriteLine("\nAdd Employee\n");
                    AddEmployee(
                        info.RequestInt("Enter New Employee ID: "), 
                        info.RequestString("Enter First Name: "),
                        info.RequestString("Enter Last Name: "),
                        info.RequestInt("Enter Hire Year: "));
                    ChoiceSelected = true;
                    break;
                case 4:
                    Console.WriteLine("Delete Employee");
                    ChoiceSelected = true;
                    break;
                case 5:
                    Console.WriteLine("Update Employee");
                    ChoiceSelected = true;
                    break;
                default:
                    System.Console.WriteLine("Please enter the number options of 1 or 2");
                    break;
            }

            return ChoiceSelected;


        }

        public string getPath(string usersPath)
        {
            //Console.WriteLine(usersPath + @"\");
            //PrintEmployee(usersPath + @"\");

            return usersPath;
        }

        public void PrintEmployee(string path)
        {


            System.Console.WriteLine("\n");

            string[] people = Directory.GetFiles(path, "*.txt");
            string[] persons = { };

            foreach (string person in people)
            {
                string getTextFile = System.IO.File.ReadAllText(person);
                persons = getTextFile.Split(",");

                //foreach (string data in persons)
                //{
                //    System.Console.Write(data);
                //}

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

        private void AddEmployee(int id, string firstName, string lastName, int HireYear)
        {
            String EmployeeRawData = id.ToString() + "," + firstName + "," + lastName + "," + HireYear.ToString();

            String path = getPath();

            System.IO.File.WriteAllText(+${id}.txt", EmployeeRawData);

            Employee newEmployee = new Employee(id, firstName, lastName, HireYear);

            Console.WriteLine(newEmployee);



            // Adds a new file to the ${path} directory with the new details
        }

        private void DeleteEmoployee(int id)
        {
            // Deletes the record that matches the given id if it exists
        }

        private void UpdateEmployee(int id,string  firstName,string lastName,int HireYear)
        {
            // Updates the correct file if it exists.
            // Should not be able to change the id of a user.
        }

        private void SerializeAllEmployees()
        {
            // Iterate through all the files in the ${path} directory
            // Create an Employee object for each file
            // Serialize each Employee object to the /${path}serialized/ directory in it's own file.

        }

        private void GetSerializedEmployee(int id)
        {
            // Takes an id as a parameter
            // Fetches the associated serialized employee file and de-serializes it to an Employee object
            // Returns the Employee object
            throw new NotImplementedException();
        }
    }
}