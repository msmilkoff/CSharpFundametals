namespace _07.ImmutableList
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    public class ImmutableListMain
    {
        public static void Main()
        {
            Type immutableList = typeof(ImmutableList);
            FieldInfo[] fields = immutableList.GetFields();
            if (fields.Length < 1)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(fields.Length);
            }

            MethodInfo[] methods = immutableList.GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
            if (!containsMethod)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(methods[0].ReturnType.Name);
            }

        }
    }

    public class ImmutableList
    {
        public IEnumerable<int> collection;

        public ImmutableList()
        {

        }
        public ImmutableList(IEnumerable<int> collection)
        {
            this.collection = collection;
        }

        public ImmutableList GetClone()
        {
            var clone = new ImmutableList();
            foreach (var item in this.collection)
            {
                clone.collection = Enumerable.Range(item, this.collection.Count());
                break;
            }
            
            return clone;
        }
    }
}
