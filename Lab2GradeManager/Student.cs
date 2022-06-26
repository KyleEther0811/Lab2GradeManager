using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2GradeManager
{
    public class Student
    {
        public List<Assignment> assignments = new List<Assignment>();
        public Student()
        {
            assignments = new List<Assignment>();
        }
        public string Name { get; set; }  
       
        public void StudentSummary(Student selectedStudent)
        {
            Console.Clear();
            int assignmentNumber = assignments.Count;
            bool CompletionStatus = Completed();
            Console.WriteLine(" Student Summary:");
            Console.WriteLine("------------------");
            Console.WriteLine("Student Name:" + Name);
            Console.WriteLine("Total Assignments: " + assignmentNumber);
            
            if (StudentAverage() == 0)
            {
                Console.WriteLine("Student Average : No Grades Available");
            }
            else
            {
                Console.WriteLine("Student Average:" + StudentAverage());   
            }
            Console.WriteLine("All Assignments Complete:" + CompletionStatus);
            Console.ReadLine();
          
            
        }
    public void NewAssignment()
    {
        bool loop;

        while (loop = true)
        {
            Assignment assignment = new Assignment();
            Console.Clear();
            ViewAssignment();
            Console.WriteLine("Input Assignment Name");
            string name = Console.ReadLine();
            assignment.AssignmentName = name;
            assignments.Add(assignment);
            Console.WriteLine("Added: " + assignment.AssignmentName + " to " + Name);
            Console.WriteLine("Would you like to add another assignment? (Y / N)");
            string userInput = Console.ReadLine();

            if (userInput == "Y")
            {
                loop = false;
            }
            else { return; }
        }

    }
        public void ViewAssignment()
        {
            foreach(Assignment assignment in assignments)
            {
                assignment.ShowGrade();
            }
        }
        public void RemoveAssignment()
        {
            Console.Clear();
            Console.WriteLine("Input an assignment name to remove...");
            string Input = Console.ReadLine();
            
            for (var i = 0; i < assignments.Count; i++)
            {
                if (assignments[i].AssignmentName.Equals(Input))
                {
                    assignments.RemoveAt(i);
                }
            }
        }
        public void SelectAssignment()
        {
            Console.Clear();
            ViewAssignment();
            Console.WriteLine("Input Assignment Name:");

            string Input = Console.ReadLine();
            bool loop = false;

            foreach (var assignment in assignments)
            {
                if (Input.Equals(assignment.AssignmentName))
                {
                    assignment.AddGrade();
                    loop = false;
                    return;
                }
                else { loop = true; }
            }
        }
        public bool Completed()
        {
            bool c = false;
            foreach (var assignment in assignments)
            {
                bool result = assignment.Graded();
                if (result) { c = true; }   
                else { return false; }
            }
            if (c)
            {
                return true;
            }
            return false;
        }
        public double StudentAverage()
        {
            List<double> allGrades = new List<double>();
            if (assignments.Count < 0)
            {
                Console.WriteLine(" No Grades Available... ");
                return 0;
            }
            foreach (var assignment in assignments)
            {
                allGrades.Add(assignment.ReturnGrade());
            }
            double sAverage = allGrades.Average();
            return sAverage;
        }
        public void PrintTopAssignment()
        {
            Console.Clear();
            double i = 0;
            string a = null;

            foreach (var assignment in assignments)
            {
                if(assignment.ReturnGrade() > i)
                {
                    i = assignment.ReturnGrade();
                    a = assignment.AssignmentName;
                }
            }
            Console.WriteLine("Highest Grade: " + a + " - " + i);
            Console.ReadLine();
            Console.Clear();
        }
        public double TopAssignment()
        {
            double i = 0;
            
            foreach (var assignment in assignments)
            {
                if(assignment.ReturnGrade() > i)
                {
                    i = assignment.ReturnGrade();
                }
            }
            return i;
        }
        public void PrintLowestAssignment()
        {
            Console.Clear();
            double i = 900;
            string a = null;

            foreach (var assignment in assignments)
            {
                if(assignment.ReturnGrade() < i)
                {
                    i = assignment.ReturnGrade();
                    a = assignment.AssignmentName;
                }
            }
            Console.WriteLine("Lowest Grade:" + a + " - " + i);
            Console.ReadLine();
        }
        public double LowestAssignment()
        {
            Console.Clear();
            double i = 900;

            foreach (var assignment in assignments)
            {
                if(assignment.ReturnGrade() < i)
                {
                    i = assignment.ReturnGrade();
                }
            }
            return i;
        }       
    }
}
