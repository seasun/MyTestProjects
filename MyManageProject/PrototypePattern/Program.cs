using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume one = new Resume("seasun", 26, "memego");
            List<WorkExp> workExps = new List<WorkExp>();
            workExps.Add(new WorkExp { CompanyName = "memego", TimeArea = "2010-05-31 至今" });
            workExps.Add(new WorkExp { CompanyName = "memego22222", TimeArea = "2010-05-31 22222222222 至今" });
            one.WorkExperiences = workExps;
            one.WorkExperience = new WorkExp { CompanyName = "生力", TimeArea = "2008-2009" };
            Resume two = (Resume)one.Clone();
            two.Name = "seasun222";
            two.WorkExperiences.Add(new WorkExp { CompanyName = "memego3333333333", TimeArea = "333333333333333 至今" });
            //two.WorkExperience = new WorkExp { CompanyName = "生力22", TimeArea = "2008-2009" };
            two.WorkExperience.CompanyName = "生力22222";
            ShowResume(one);
            ShowResume(two);
            Console.Read();
        }

        private static void ShowResume(Resume resume)
        {
            var properties = typeof(Resume).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(WorkExp))
                {
                    Console.WriteLine("{0} is {1}", property.Name, (property.GetValue(resume, null) as WorkExp).CompanyName);
                }
                else if (property.PropertyType == typeof(List<WorkExp>))
                {
                    List<WorkExp> workExperiences = property.GetValue(resume, null) as List<WorkExp>;
                    if (workExperiences != null)
                    {
                        Console.WriteLine("{0} : -------------------------------------", property.Name);
                        workExperiences.ForEach((m) =>
                        {
                            Console.WriteLine("{0} is {1}", "TimeArea", m.TimeArea);
                            Console.WriteLine("{0} is {1}", "CompanyName", m.CompanyName);
                        });
                    }

                }
                else
                    Console.WriteLine("{0} is {1}", property.Name, property.GetValue(resume, null));
            }
            Console.WriteLine("**************************************************************");
        }
    }
}
