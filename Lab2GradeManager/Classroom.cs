using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2GradeManager
{
     public class Classroom
    {
        public string ClassName { get; set; } 
        public List<Student> students = new List<Student>();
        
        public Classroom()
        {
            students = new List<Student>();
        }

        public void AddStudent()
        {
            bool loop;
            while (loop = true)
            {
                Student student = new Student();
                Console.Clear();
                ViewStudents();
                Console.Write("Input Student Name; ");                
                string name = Console.ReadLine();
                student.Name = name;
                students.Add(student);
                Console.WriteLine(student.Name + " added to " + ClassName);
                Console.WriteLine(" Add another student?... (Y/N) ");
                string Input = Console.ReadLine();

                if (Input == "Y")
                {
                    loop = false;
                }
                else {return;}
            }
        }              
        public void ViewStudents()
        {
            Console.Clear();

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name);
            }
        }
        public void DeleteStudent()
        {
            Console.Clear();
            Console.WriteLine("Input a Student Name to remove...");
            Console.WriteLine("----------------------------------");
            string studentName = Console.ReadLine();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name.Equals(studentName))
                {
                    students.RemoveAt(i);
                }
            }
            Console.WriteLine(studentName + " Removed from class...");
        }
        public void SelectStudent()
        {
            Console.Clear();
            ViewStudents();
            Console.WriteLine(" Input Student Name:");
            Console.WriteLine("--------------------");
            string Input = Console.ReadLine();
            bool loop = false;
            Student selectedStudent = new Student();

            foreach (var student in students)
            {
                if (Input.Equals(student.Name))
                {
                    selectedStudent = student;
                    loop = false;
                    StudentMenu(selectedStudent);
                    return;
                }
                else { loop = true; }
            }
            if (loop == true)
            {
                Console.WriteLine("Selected Student does not exist...");
            }
        }
        public void StudentMenu(Student selectedStudent)
        {
            Console.Clear();
            bool loop = true;
            while (loop = true)
            {
                Console.WriteLine("*===== Student Details Menu ======*");
                Console.WriteLine("1. Student Summary");
                Console.WriteLine("2. Add New Assignment to Student");
                Console.WriteLine("3. Remove Assignments");
                Console.WriteLine("4. View Assignments");
                Console.WriteLine("5. Add Grade to Assignments");
                Console.WriteLine("6. Show Students Highest Grade");
                Console.WriteLine("7. Show Students Lowest Grade");
                Console.WriteLine("0. Press '0' to Exit Menu");

                int studentSelection = int.Parse(Console.ReadLine());
                switch (studentSelection)
                {
                    case 1:
                        selectedStudent.StudentSummary(selectedStudent);                        
                        break;
                        
                    case 2:
                        selectedStudent.NewAssignment();                      
                        break;
                        
                    case 3:
                        selectedStudent.RemoveAssignment();                       
                        break;
                        
                    case 4:
                        selectedStudent.ViewAssignment();                      
                        break;
                        
                    case 5:
                        selectedStudent.SelectAssignment();               
                        break;
                        
                    case 6:
                        selectedStudent.PrintTopAssignment();                        
                        break;
                        
                    case 7:
                        selectedStudent.PrintLowestAssignment();                       
                        break;
                                
                    case 0:
                        //ExitStudentMenu();                        
                        loop = false;
                        return;
                        
                }
            }          
        }
        public void ClassAverage()
        {
            Console.Clear();
            List<double> classaverage = new List<double>();
            foreach (var student in students)
            {
                classaverage.Add(student.StudentAverage());
            }
            double sAverage = classaverage.Average();
            Console.WriteLine("Class Average:" + sAverage);
            Console.ReadLine();
        }
        public void TopGrade()
        {
            Console.Clear();
            double i = 0;
            string a = null;

            foreach(var student in students)
            {
                if(student.StudentAverage() > i)
                {
                    i = student.StudentAverage();
                    a = student.Name;
                }
            }
            Console.WriteLine("Highest Grade Average: " + a + "-" + i);
            Console.ReadLine(); 
        }
        public void LowestGrade()
        {
            Console.Clear();
            double i = 900;
            double ii = 900;
            string a = null;
            string aa = null;

            foreach (var student in students)
            {
                if(student.LowestAssignment() < i)
                {
                    i = student.LowestAssignment();
                    a= student.Name;
                }
            }
            Console.WriteLine("Lowest Assignment Grade: " + a + "-" + i);

            foreach (var student in students)
            {
                if(student.StudentAverage() < i)
                {
                    ii = student.StudentAverage();
                    aa = student.Name;
                }
            }
            Console.WriteLine("Lowest Grade Average:" + aa + "-" + ii);
            Console.ReadLine();
            Console.Clear();
        }
        public void StudentComparison()
        {
            Console.Clear();
            ViewStudents();

            double st1 = 0;
            double st2 = 0;
            string st11 = null;
            string st22 = null;

            Console.WriteLine(" *Student Comparison Tool* ");
            Console.WriteLine(" -------------------------- ");
            Console.WriteLine("Input the name of the first student...");
            string Input1 = Console.ReadLine();
            Console.WriteLine("Input the name of the second student...");
            string Input2 = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.Name.Equals(Input1))
                {
                    st1 = student.StudentAverage();
                    st11 = student.Name;
                }
                if (student.Name.Equals(Input2))
                {
                    st2 = student.StudentAverage();
                    st22 = student.Name;
                }
            }
           if (st1 > st2)
            {
                Console.WriteLine(st11 + "has the higher grade average.");
                Console.WriteLine(st11 + "-" + st1);
                Console.WriteLine(st22 + "-" + st2);
            }
            else 
            {
                Console.WriteLine(st22 + "has the higher grade average.");
                Console.WriteLine(st22 + "-" + st2);
                Console.WriteLine(st11 + "-" + st1);
            }
        }
    }
}

