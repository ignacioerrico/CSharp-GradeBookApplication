using GradeBook.Enums;
using System.Linq;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWheighted) : base(name, isWheighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            // Get the list of the average grade of each student, in descending order.
            var orderedAverageGrades = Students.Select(s => s.AverageGrade).OrderByDescending(g => g);

            // Where is the input grade placed among the existing grades?
            int index = 0;
            foreach (var grade in orderedAverageGrades)
            {
                if (averageGrade >= grade)
                {
                    break;
                }

                ++index;
            }

            var rank = (double)index / Students.Count;

            if (rank < .2) return 'A';
            else if(rank < .4) return 'B';
            else if(rank < .6) return 'C';
            else if(rank < .8) return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
