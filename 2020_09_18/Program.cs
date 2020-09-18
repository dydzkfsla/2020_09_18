using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace _2020_09_18
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string ToString()
        {
            string str =
$@"==================== person ====================
성: {FirstName}                 이름: {LastName}
================================================";
            return str;
        }

        public override bool Equals(object obj)
        {
            return obj is Person temp && FirstName == temp.FirstName && LastName == temp.LastName;
        }

        public static bool operator ==(Person This, object b)
        {
            return b is Person temp && This.FirstName == temp.FirstName && This.LastName == temp.LastName;
        }
        public static bool operator !=(Person This, object b)
        {
            return b is Person temp && This.FirstName == temp.FirstName && This.LastName == temp.LastName;
        }

        public override int GetHashCode()
        {
            int result = EqualityComparer<string>.Default.GetHashCode(FirstName);
            result += EqualityComparer<string>.Default.GetHashCode(LastName);

            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person per = new Person("류", "현진");
            Console.WriteLine(per.ToString());
            
            //Type t1 =  per.GetType();
            //Type t2 = typeof(Person);
            
            Person per2 = new Person("류", "현진");

            if (per == per2)
                Console.WriteLine("동일한 이름입니다.");
            else
                Console.WriteLine("다른 이름립니다.");

            string str = "류현진";
            string str2 = "류현진";

            List<List<string>> a = new List<List<string>>();
            a[0] = new List<string>();
            a[0][0] = " ";
            if (str.Equals(str2))
                Console.WriteLine("동일한 이름입니다.");
            else
                Console.WriteLine("다른 이름립니다.");

            Console.WriteLine(per.GetHashCode());
            Console.WriteLine(per2.GetHashCode());

        }
    }
}
