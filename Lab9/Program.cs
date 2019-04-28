using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            var classList = new List<Student>();
            Seed(classList);

            MainMenu(classList);

            Console.WriteLine("\n\n-----------------------------------");
            Console.WriteLine("End of Demo. Press any key to exit.");
            Console.ReadKey();
        }
        private static void MainMenu(List<Student> classList)
        {
            Console.WriteLine($"Welcome to our C# class.");
            while (true)
            {
                if (classList.Count == 0)
                {
                    Console.WriteLine("No students are enrolled.");
                    Console.WriteLine($"\nWhat would you like to do?\n\nMain Menu:\n\n  1 - Enroll a new Student\n  2 - Exit\n");
                    Console.Write("\nSelection: ");
                    var userAction = GetIntInRange(1, 2, "selection");
                    switch (userAction)
                    {
                        case 1:
                            EnrollNewStudent(classList);
                            break;
                        default:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine($"\n\nMain Menu:\n---------\n\nWhat would you like to do?\n  1 - Review Class List\n  2 - Review a Student Profile\n  3 - Enroll a new Student\n  4 - Exit\n");
                    Console.Write("\nSelection: ");
                    var userAction = GetIntInRange(1, 4, "selection");
                    switch (userAction)
                    {
                        case 1:
                            ReviewClassList(classList);
                            break;
                        case 2:
                            ReviewAllProfiles(classList);
                            break;
                        case 3:
                            EnrollNewStudent(classList);
                            break;
                        default:
                            return;
                    }
                }
                Console.Clear();
            }
        }
        private static void ReviewClassList(List<Student> classList)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n\nReviewing Class List:\n--------------------\n\nWhat would you like to do?\n  1 - Review Class List by name ordered by {Student.orderedBy}\n  2 - Reorder by name\n  3 - Reorder by wins\n  4 - Reorder by draws\n  5 - Reorder by defeats\n  6 - Reorder by hometown\n  7 - Reorder by height\n  8 - Reorder by weight\n  9 - Return to Main Menu\n");
                Console.Write("\nSelection: ");

                var userAction = GetIntInRange(1, 9, "selection");

                switch (userAction)
                {
                    case 1:
                        Console.Clear();
                        PrintList(classList);
                        break;
                    case 2:
                        Student.orderedBy = "name";
                        break;
                    case 3:
                        Student.orderedBy = "wins";
                        break;
                    case 4:
                        Student.orderedBy = "draws";
                        break;
                    case 5:
                        Student.orderedBy = "defeats";
                        break;
                    case 6:
                        Student.orderedBy = "hometown";
                        break;
                    case 7:
                        Student.orderedBy = "height";
                        break;
                    case 8:
                        Student.orderedBy = "weight";
                        break;
                    default:
                        return;
                }
                SortList(classList);
                Console.Write("\n\nPress any key to continue: ");
                Console.ReadKey();
            }
        }
        private static void ReviewAllProfiles(List<Student> classList)
        {
            do
            {
                Console.Clear();
                var focusedStudent = FindStudent(classList);
                ReviewStudentProfile(focusedStudent, classList);
            } while (KeepGoing("Would you like to review another student record?"));
        }
        private static void ReviewStudentProfile(Student focusedStudent, List<Student> classList)
        {
            while (true)
            {
                Console.Write($"\nWhat would you to do?\n\nInformation:\n  1 - Billed From\n  2 - Height and Weight\n  3 - Win/Loss Record\n\nStats:\n  4 - Add a new win\n  5 - Add a new draw\n  6 - Add a new loss\n\nAdmin:\n  7 - Update this student's name\n  8 - Remove this record\n  9 - Exit Student Record\n");
                Console.Write("\nSelection: ");

                var userAction = GetIntInRange(1, 9, "data");

                switch (userAction)
                {
                    case 1:
                        Console.WriteLine($"\n{focusedStudent.GetName()} is billed from {focusedStudent.GetHometown()}");
                        break;
                    case 2:
                        Console.WriteLine($"\n{focusedStudent.GetName()} is {focusedStudent.GetHeight()} and weighs {focusedStudent.GetWeight()}");
                        break;
                    case 3:
                        Console.WriteLine($"\n{focusedStudent.GetName()} has a record of {focusedStudent.GetWins()} wins ({Math.Round(focusedStudent.GetWinRate(), 2)}%), {focusedStudent.GetDefeats()} defeats ({Math.Round(focusedStudent.GetDefeatRate(), 2)}%), and {focusedStudent.GetDraws()} draws ({Math.Round(focusedStudent.GetDrawRate(), 2)}%).");
                        break;
                    case 4:
                        focusedStudent.AddWin();
                        Console.WriteLine($"\n Win added.\n{focusedStudent.GetName()} now has a win total of {focusedStudent.GetWins()} wins.");
                        break;
                    case 5:
                        focusedStudent.AddDraw();
                        Console.WriteLine($"\n Win added.\n{focusedStudent.GetName()} now has a draw total of {focusedStudent.GetDraws()} draws.");
                        break;
                    case 6:
                        focusedStudent.AddDefeat();
                        Console.WriteLine($"\n Win added.\n{focusedStudent.GetName()} now has a defeat total of {focusedStudent.GetDefeats()} defeats.");
                        break;
                    case 7:
                        RenameStudent(focusedStudent);
                        break;
                    case 8:
                        var removedName = focusedStudent.GetName();
                        classList.Remove(focusedStudent);
                        Console.WriteLine($"...Done\nThe record for {removedName} has been removed from the Class List.");
                        Console.Write("\n\nPress any key to return to the main menu: ");
                        Console.ReadKey();
                        return;
                    default:
                        return;
                }
                Console.Write("\n\nPress any key to continue: ");
                Console.ReadKey();
                Console.Clear();
                Console.Write($"\nReviewing record for {focusedStudent.GetName()}:");
            }
        }
        private static Student FindStudent(List<Student> classList)
        {
            while (true)
            {
                Console.Write($"Which student would you like to learn more about? (enter a number 1-{classList.Count} or enter 0 to search by name): ");
                var input = GetIntInRange(0, classList.Count, "student") - 1;
                if (input == -1)
                {
                    var focusedStudent = FindStudentByName(classList);
                    if (focusedStudent != null)
                    {
                        return focusedStudent;
                    }
                }
                else
                {
                    Console.Write($"\nStudent {input + 1} is {classList[input].GetName()}.");
                    return classList[input];
                }
            }

        }
        private static Student FindStudentByName(List<Student> classList)
        {
            do
            {
                Console.Write("Please enter the name of the student: ");
                var searchName = Console.ReadLine();
                foreach (var student in classList)
                {
                    if (student.GetName() == searchName)
                    {
                        Console.WriteLine($"Found student: {student.GetName()}");
                        return student;
                    }
                }
            } while (KeepGoing("Could not find student with that name. Would you like to try again?"));
            return null;
        }
        private static void EnrollNewStudent(List<Student> classList)
        {
            Console.Write("Please enter the new student's name: ");
            string name = Console.ReadLine();
            Console.Write($"What is {name}'s hometown? ");
            string hometown = Console.ReadLine();
            Console.Write($"What is {name}'s height in inches? ");
            int height = GetIntInRange(1, 120, "height");
            Console.Write($"What is {name}'s weight? ");
            int weight = GetIntInRange(1, 2000, "weight");

            classList.Add(new Student(name, hometown, height, weight));

            //classList.Sort();

            Console.Write($"....Done\nWelcome {name} of {hometown}.\n\nPress any key to continue: ");
            Console.ReadKey();
            SortList(classList);


        }
        private static void RenameStudent(Student focusedStudent)
        {
            var oldName = focusedStudent.GetName();
            Console.Write($"What is {oldName}'s new name? ");
            focusedStudent.Rename(Console.ReadLine());
            Console.WriteLine($"\n ...Done\n{oldName} will now be called {focusedStudent.GetName()}.");
        }
        private static int GetIntInRange(int min, int max, string dataType)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input) && input >= min && input <= max)
                {
                    return input;
                }
                Console.WriteLine($"That {dataType} does not exist. Please enter an integer value between {min} and {max}");
            }
        }
        private static void Seed(List<Student> classList)
        {
            var seedNames = new string[] { "The Undertaker", "John Cena", "Bret Hart", "Kane", "Tito Santana", "Bruno Sammartino", "Shawn Michaels", "Big Show", "Randy Orton", "Hulk Hogan", "Bob Backlund", "Tony Garea", "Pedro Morales", "Kofi Kingston", "Ivan Putski", "Chief Jay Strongbow", "Triple H", "Davey Boy Smith", "Andre the Giant", "Randy Savage" };
            var seedHometowns = new string[] { "Death Valley", "West Newburry, Mass", "Calgary, Alberta", "Decatur, Ill", "Mexico City, Mexico", "Pittsburgh, Penn", "Houston, Tex", "Tampa, Florida", "St Louis, Missouri", "Venice Beach, California", "Princeton, Minnesota", "Auckland, New Zealand", "Culebra, Puerto Rico", "Ghana, West Africa", "Kraków, Poland", "Pawhuska, Oklahoma", "Greenwich, Connecticut", "Manchester, England", "Grenoble in the French Alps", "Sarasota, Florida" };
            var seedWins = new int[] { 1774, 1752, 1640, 1470, 1407, 1321, 1292, 1215, 1177, 1152, 1113, 1091, 1087, 1033, 1022, 1009, 1008, 972, 967, 915 };
            var seedDraws = new int[] { 91, 62, 223, 116, 184, 203, 82, 92, 67, 27, 99, 238, 149, 20, 151, 217, 76, 70, 74, 48 };
            var seedDefeats = new int[] { 432, 407, 562, 1219, 599, 193, 519, 901, 965, 191, 289, 820, 203, 767, 392, 506, 859, 552, 179, 571 };
            var seedHeights = new int[] { 83, 73, 72, 83, 74, 70, 72, 84, 76, 79, 73, 73, 70, 73, 68, 72, 76, 71, 88, 74 };
            var seedWeights = new int[] { 328, 251, 235, 345, 234, 265, 235, 383, 242, 303, 240, 245, 240, 215, 243, 247, 255, 260, 520, 245 };

            for (var i = 0; i < seedNames.Length; i++)
            {
                classList.Add(new Student(seedNames[i], seedHometowns[i], seedWins[i], seedDraws[i], seedDefeats[i], seedHeights[i], seedWeights[i]));
            }
            SortList(classList);
        }
        private static bool KeepGoing(string question)
        {
            while (true)
            {
                Console.Write($"\n{question} (y/n): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    return true;
                }
                if (input.ToLower() == "n")
                {
                    return false;
                }
                Console.Write("Please enter y or n: ");
            }
        }
        private static void PrintList(List<Student> classList)
        {
            Console.WriteLine($"The full class list ordered by {Student.orderedBy} is:");
            for (var i = 0; i < classList.Count; i++)
            {
                if (Student.orderedBy == "name")
                {
                    Console.WriteLine($"{i + 1} - {classList[i].GetName()}");
                }
                else
                {
                    Console.WriteLine($"{i + 1} - {classList[i].GetName()}, {Student.orderedBy}: {classList[i].GetSortValue()}");
                }
            }
        }
        private static void SortList(List<Student> classList)
        {
            switch (Student.orderedBy)
            {
                case "name":
                    classList.Sort(delegate (Student x, Student y)
                    {
                        return x.GetName().CompareTo(y.GetName());
                    });
                    break;
                case "wins":
                    classList.Sort(delegate (Student x, Student y)
                    {
                        return y.GetWins().CompareTo(x.GetWins());
                    });
                    break;
                case "draws":
                    classList.Sort(delegate (Student x, Student y)
                    {
                        return y.GetDraws().CompareTo(x.GetDraws());
                    });
                    break;
                case "defeats":
                    classList.Sort(delegate (Student x, Student y)
                    {
                        return y.GetDefeats().CompareTo(x.GetDefeats());
                    });
                    break;
                case "hometown":
                    classList.Sort(delegate (Student x, Student y)
                    {
                        return x.GetHometown().CompareTo(y.GetHometown());
                    });
                    break;
                case "height":
                    classList.Sort(delegate (Student x, Student y)
                    {
                        return y.GetHeightValue().CompareTo(x.GetHeightValue());
                    });
                    break;
                case "weight":
                    classList.Sort(delegate (Student x, Student y)
                    {
                        return y.GetWeightValue().CompareTo(x.GetWeightValue());
                    });
                    break;
                default:
                    Console.WriteLine("Error - unknown sort criteria.");
                    break;
            }
        }
    }
}
