using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;

namespace Prog_120_S23_L19_Final_Review
{
    internal class Program
    {
        static int numberOfStudents = 15; // You can change this, has to be 5 or higher. Code should work no matter what size

        // Data
        static string[] studentFirstName = new string[numberOfStudents];
        static string[] studentLastName = new string[numberOfStudents];
        static double[] csiGrades = new double[numberOfStudents];
        static double[] genEdGrades = new double[numberOfStudents];


        static void Main(string[] args)
        {
            CodeForTest_DontChange(); // !! Needs to first method in main, don't delete
                                      //----------------------------------------------
                                      // Place code below here



            // Work with arrays
            // Linear Search

            // Shortcut for For loop
            // for tab tab

            Menu();


        } // Main

        
        public static void Menu()
        {

            bool isRunning = true;

            do
            {
                Console.WriteLine("\nProfessor Will");
                Console.WriteLine("1 - Display All Students");
                Console.WriteLine("5 - Display Average Grades");
                Console.WriteLine("e - Exit");

                Console.Write("Enter your choice: ");
                string userChoice = Console.ReadLine();

                switch(userChoice)
                {
                    case "1":
                        DisplayAllStudents();
                        break;
                    case "5":
                        ViewStudentWithGrades();
                        break;

                    case "e":
                        isRunning = false;
                        break;
                }

            } while (isRunning);


            Console.WriteLine("Thank you");

        }


        public static void DisplayAllStudents()
        {
            for (int i = 0; i < studentFirstName.Length; i++)
            {
                FormatStudent(i);
            }
        }

        //-	void FormatStudent(int index)
        //Take an index as an argument.Displays students information.
        public static void FormatStudent(int index)
        {
            //Name – Last Name – CSI: CSI Grade – GenEd: GenEdGrade – Average: Average Grade
            string first = studentFirstName[index];
            string last = studentLastName[index];
            double csi = csiGrades[index];
            double gen = genEdGrades[index];
            double average = GradeAverage(csi, gen);


            Console.WriteLine($"{index} : {first} {last} : CSI - {csi} : GenEd - {gen} - Average - {average}");
        }



        public static double GradeAverage(double csi, double gen)
        {
            return (csi + gen) / 2.0;
        }

        public static void DisplayStudentsWithGrades(double min, double max)
        {
   

            // ---------------------------------------- How we display values in a range

            // Look through all the students
            for (int i = 0; i < studentFirstName.Length; i++)
            {
                // Get their average grade
                double studentAvg = GradeAverage(csiGrades[i], genEdGrades[i]);

                // IF the grade is BETWEEN the MIN AND MAX VALUE, DISPLAY
                // If the student grade is GREATER than the min value
                // AND the student grade is LESS than the MAX VALUE
                // Display

                if(studentAvg >= min && studentAvg <= max)
                {
                    FormatStudent(i);
                }
            }
        }

        public static void ViewStudentWithGrades()
        {


            //for (int i = 0; i < studentFirstName.Length; i++)
            //{
            //    FormatStudent(i);
            //}
            double minValue, maxValue;


            Console.WriteLine("Enter a min and a max grade: ");

            Console.Write("Min Value: ");

            // int number;
            //.TryParse("9", number) - true

            // .TryParse("dog", number) - false

            // !true = false

            // while the user gives me an INVALID number  ask them for another number

            // Ask the user for a min value
            while (!double.TryParse(Console.ReadLine(), out minValue))
            {
                Console.WriteLine("Please enter a valid number");
            }

            // Ask the user for a max value
            Console.Write("Max Value: ");
            while (!double.TryParse(Console.ReadLine(), out maxValue))
            {
                Console.WriteLine("Please enter a valid number");
            }

            // Call method to display students with grades here

            DisplayStudentsWithGrades(minValue, maxValue);

        }



        // -------------------------------------------------------------
        // Code used to populate the arrays. Feel to look at them. But don't change them for the Final. 
        // Make a copy of this project and break that code as much as you want

        #region GenerateArrayCode
        public static void CodeForTest_DontChange()
        {
            PopulateArrays(numberOfStudents);
            CustomData();
        }

        public static void PopulateArrays(int count)
        {
            Random rand = new Random();

            string[] lastNames = {
                "Smith",
                "Johnson",
                "Williams",
                "Brown",
                "Jones",
                "Miller",
                "Davis",
                "Garcia",
                "Rodriguez",
                "Wilson",
                "Martinez",
                "Anderson",
                "Taylor",
                "Thomas",
                "Hernandez",
                "Moore",
                "Martin",
                "Jackson",
                "Thompson",
                "White"
            };

            string[] firstNames = {
                "James",
                "Mary",
                "Robert",
                "Patricia",
                "John",
                "Jennifer",
                "Michael",
                "Linda",
                "David",
                "Elizabeth",
                "William",
                "Elizabeth",
                "Barbara",
                "Richard",
                "Susan",
                "Joseph",
                "Jessica",
                "Thomas",
                "Sarah",
                "Charles",
                "Karen",
                "Christopher",
                "Lisa",
                "Daniel",
                "Nancy",
                "Matthew",
                "Betty",
                "Anthony",
                "Margaret",
                "Mark",
                "Sandra"
            };

            for (int i = 0; i < count; i++)
            {

                int fNameIndex = rand.Next(firstNames.Length);
                int lNameIndex = rand.Next(lastNames.Length);
                // System.Console.WriteLine("This ran");

                studentFirstName[i] = firstNames[fNameIndex];
                studentLastName[i] = lastNames[lNameIndex];
                csiGrades[i] = rand.Next(0, 101);
                genEdGrades[i] = rand.Next(0, 101);
            }


        } // PopulateArrays()

        public static void CustomData()
        {
            string[] stuFirst = { "Samuel", "Havelock", "Ford", "Authur" };
            string[] stuLast = { "Vimes", "Vetinari", "Prefect", "Dent" };
            int[] stuCSI = { 100, 102, 42, 20 };
            int[] stuGenEd = { 45, 102, 75, 56 };

            int[] indexes = new int[stuFirst.Length];

            Random rand = new Random();

            for (int i = 0; i < indexes.Length; i++)
            {

                int newIndex = rand.Next(studentFirstName.Length);

                while (MyContains(newIndex, indexes))
                {
                    newIndex = rand.Next(studentFirstName.Length);
                }

                indexes[i] = newIndex;

                studentFirstName[newIndex] = stuFirst[i];
                studentLastName[newIndex] = stuLast[i];
                csiGrades[newIndex] = stuCSI[i];
                genEdGrades[newIndex] = stuGenEd[i];
            }
        }
        // 45
        // 45 17 21 0

        public static bool MyContains(int search, int[] arr)
        {
            foreach (int value in arr)
            {
                if (search == value) return true;
            }
            return false;
        } // MyContains

        #endregion GenerateArrayCode

    } // class

} // namespace