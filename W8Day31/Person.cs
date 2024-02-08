using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace W8Day31
{
    [Serializable]
    internal class Person
    {
        public Person(string fullname, int age)
        {
            Fullname = fullname;
            Age = age;
        }

        public string Fullname { get; set; }
        public int Age { get; set; }

    }
}
