using CYX.Interface;
using System;

namespace CYX.Class2
{
    public class StudentService : IStudentService
    {
        public void Add()
        {
            Console.WriteLine("a student added");
        }
    }
}
