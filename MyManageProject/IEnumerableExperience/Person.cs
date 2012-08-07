using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IEnumerableExperience
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Classes
    {
        public Classes()
        {

        }

        public static IEnumerable GetClasses()
        {
            yield return new Person { Name = "seasun", Age = 26 };
            yield return new Person { Name = "candy", Age = 25 };
            yield return new Person { Name = "dong", Age = 25 };
        }
    }

    public class People : IEnumerable, IEnumerator
    {
        private int position = -1;
        private Person[] _persons;

        public People(Person[] persons)
        {
            Console.WriteLine("position : {0}", position);
            _persons = persons;
        }

        /// <summary>
        /// 增加一个索引器
        /// </summary>
        /// <returns></returns>
        public Person this[int index]
        {
            get
            {
                if (index < 0 || index >= _persons.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return _persons[index];
            }
        }

        #region IEnumerable 成员

        public IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException();
            return this;//返回的是实现了IEnumerator的类，这里就是自己
        }

        #endregion

        #region IEnumerator 成员

        public object Current
        {
            get
            {
                try
                {
                    return _persons[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public bool MoveNext()
        {
            //throw new NotImplementedException();
            return ++position < _persons.Length;
        }

        public void Reset()
        {
            //throw new NotImplementedException();
            position = -1;
        }

        #endregion
    }
}
