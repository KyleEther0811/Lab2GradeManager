using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2GradeManager
{
    public class Assignment
    {
        public string AssignmentName { get; set; }

        public List<AssignmentGrade> assignmentGrades = new List<AssignmentGrade>();

        public Assignment()
        {
            assignmentGrades = new List<AssignmentGrade>();
        }
        
        public void AddGrade()
        {
            AssignmentGrade gradeNumber = new AssignmentGrade();

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine($"Enter Assignment Grade:");

            double value = double.Parse(Console.ReadLine());

            gradeNumber.Grade = value;

            assignmentGrades.Add(gradeNumber);

            Console.WriteLine();

            Console.WriteLine($"Added: {gradeNumber.Grade}% to {AssignmentName}");

            Console.WriteLine();
        }
        public void ShowGrade()
        {
            if (assignmentGrades.Count == 0)
            {
                Console.WriteLine(AssignmentName);
            }
            else
            {
                foreach (AssignmentGrade grade in assignmentGrades)
                {
                    Console.WriteLine($"{AssignmentName} : {grade.Grade}%");
                }
            }
        }
        
        public bool Graded()
        {
            foreach (AssignmentGrade grade in assignmentGrades)
            {
                if (grade != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public double ReturnGrade()
        {
            foreach (AssignmentGrade grade in assignmentGrades)
            {
                return grade.Grade;
            }
            return 0;
        }
    }
    public class AssignmentGrade
    {
        public double Grade { get; set; }
    }
}