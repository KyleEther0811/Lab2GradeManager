using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2GradeManager
{
    public class Menu
    {
        public List<Classroom> classrooms { get; set; }

        public Menu()
        {
            classrooms = new List<Classroom>();
        }
        public void StudentMenu(Classroom selectedClass)
        {
            Console.Clear();
            bool loop = true;
            while (loop = true)
            {                            
                Console.WriteLine("1. View Students");
                Console.WriteLine("2. Add Students");
                Console.WriteLine("3. Remove Students");
                Console.WriteLine("4. View Class Average");
                Console.WriteLine("5. View Top Student");
                Console.WriteLine("6. View Lowest Student");
                Console.WriteLine("7. Student Comparison Tool");
                Console.WriteLine("8. Student Details Menu");
                Console.WriteLine("0. Return to Main Menu");

                int classroomSelection = int.Parse(Console.ReadLine());

                switch (classroomSelection)
                {
                    case 1:
                        selectedClass.ViewStudents();                        
                        break;
                        
                    case 2:
                        selectedClass.AddStudent();
                        break;
                        
                    case 3:
                        selectedClass.DeleteStudent();
                        break;
                        
                    case 4:
                        selectedClass.ClassAverage();
                        break;
                        
                    case 5:
                        selectedClass.TopGrade();
                        break;                                                 
                    
                    case 6:
                        selectedClass.LowestGrade();
                        break;
                   
                    case 7:
                        selectedClass.StudentComparison();
                        break;
                           
                        
                    case 8:
                        selectedClass.SelectStudent();
                        break;
                    
                    case 0:
                        loop = false;
                        return;
                        break;                                                                        
               }
            }
        }
        public void MainMenu()
        {
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("*===== Grade Manager Program =====*");
                Console.WriteLine("1. View Classrooms");
                Console.WriteLine("2. Add Classrooms");
                Console.WriteLine("3. Remove Classrooms");
                Console.WriteLine("4. Classroom Details Menu");
                Console.WriteLine("5. Exit");

                string MenuSelection = Console.ReadLine();
                bool selection = int.TryParse(MenuSelection, out int uSelection);

                if (selection == false)
                {
                    Console.WriteLine("Please Enter A Valid Selection");
                }
                else if(uSelection == 5)
                {
                    loop = false;
                    return;
                }
                else
                {
                    CheckMenuSelection(uSelection);
                }
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();                                   
            }
        }
        public void ClassroomMenu()
        {
            Console.Clear();
            ViewClassroom();
            Console.WriteLine("Input A Classroom Name:");

            string uSelection = Console.ReadLine();
            var selectedClass = new Classroom();
            bool loop = false;

            foreach (var classroom in classrooms)
            {
                if (uSelection.Equals(classroom.ClassName))
                {
                    selectedClass = classroom;
                    StudentMenu(selectedClass);
                    loop = false;
                    return;
                }
                else { loop = true; }
            }
            if ( loop == true)
            {
                Console.WriteLine("ERROR. Please try again...");
            }
        } 
        public void CheckMenuSelection(int uSelection)
        {
            switch (uSelection)
            {
                case 1:
                    ViewClassroom();
                    break;

                case 2:
                    AddClassroom();
                    break;
                
                case 3:
                    DeleteClassroom();
                    break;
                
                case 4:
                    ClassroomMenu();
                    break;

            }
        }
        public void ViewClassroom()
        {
            Console.Clear();

            for (int i = 0; i < classrooms.Count; i++)
            {
                Console.WriteLine("Classroom: " + classrooms[i].ClassName);
            }
        }
        public void AddClassroom()
        {
            Console.Clear();
            Console.WriteLine("Input Class Name:");
            string Input = Console.ReadLine();
           
            Classroom classroom = new Classroom();
            classroom.ClassName = Input;
            classrooms.Add(classroom);         
        }
        public void DeleteClassroom()
        {
            Console.Clear();
            ViewClassroom();
            Console.WriteLine("Input ther name of the classroom you wish to remove...");
            string Input = Console.ReadLine();

            for (var i = 0; i < classrooms.Count; i++)
            {
                if (classrooms[i].Equals(Input))
                {
                    classrooms.RemoveAt(i);
                }
            }
            Console.WriteLine("Remove Classroom:" + Input);
        }
    }
}
