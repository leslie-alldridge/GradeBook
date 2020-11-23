using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    class DiskBook: IBook
    {
        public void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public string Name { get; }
        public event GradeAddedDelegate GradeAdded;

        public DiskBook(string title)
        {
            Name = title;
        }
    }
}
