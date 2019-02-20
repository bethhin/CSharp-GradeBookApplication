using GradeBook.Enums;
using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
             if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students");
            var gradeLevel = (int)Math.Ceiling(Students.Count * 0.20);
            var grades = Students.OrderByDescending( e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if  (averageGrade >= grades[gradeLevel  - 1])
                return 'A';
            if (averageGrade >= grades[(gradeLevel  * 2) - 1])
                return 'B';
            if (averageGrade >= grades[(gradeLevel  * 3) - 1])
                return 'C';
            if (averageGrade >= grades[(gradeLevel  * 4) - 1])
                return 'D';
            return 'F';
        }
    }
}