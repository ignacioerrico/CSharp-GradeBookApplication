using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWheighted) : base(name, isWheighted)
        {
            Type = GradeBookType.Standard;
        }
    }
}
