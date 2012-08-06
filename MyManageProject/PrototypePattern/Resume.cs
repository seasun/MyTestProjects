using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrototypePattern
{
    class Resume : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public List<WorkExp> WorkExperiences { get; set; }
        public WorkExp WorkExperience { get; set; }

        public Resume() { }
        public Resume(string name, int age, string company = "")
        {
            this.Name = name;
            this.Age = age;
            this.Company = company;
        }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
