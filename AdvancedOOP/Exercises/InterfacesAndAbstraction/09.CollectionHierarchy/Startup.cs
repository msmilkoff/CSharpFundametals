namespace _09.CollectionHierarchy
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var addOnlyCollection = new AddOnlyCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var addOperations1 = new List<int>();
            var addOperations2 = new List<int>();
            var addOperations3 = new List<int>();

            string[] itemsToAdd = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in itemsToAdd)
            {
                int addIndex1 = addOnlyCollection.Add(item);
                addOperations1.Add(addIndex1);

                int addIndex2 = addRemoveCollection.Add(item);
                addOperations2.Add(addIndex2);

                int addIndex3 = myList.Add(item);
                addOperations3.Add(addIndex3);
            }

            var removeOperations1 = new List<string>();
            var removeOperations2 = new List<string>();

            int amoutOfitemsToRemove = int.Parse(Console.ReadLine());
            for (int i = 0; i < amoutOfitemsToRemove; i++)
            {
                string removedItem1 = addRemoveCollection.Remove();
                removeOperations1.Add(removedItem1);

                string removedItem2 = myList.Remove();
                removeOperations2.Add(removedItem2);
            }

            Console.WriteLine(string.Join(" ", addOperations1));
            Console.WriteLine(string.Join(" ", addOperations2));
            Console.WriteLine(string.Join(" ", addOperations3));

            Console.WriteLine(string.Join(" ", removeOperations1));
            Console.WriteLine(string.Join(" ", removeOperations2));
        }
    }

    public class MyList : IMyList
    {
        private List<string> data;

        public MyList()
        {
            this.data = new List<string>();
        }

        public int Add(string item)
        {
            this.data.Insert(0, item);

            return 0; // 0th index should be return every time.
        }

        public string Remove()
        {
            if (this.data.Count == 0)
            {
                return null;
            }

            string itemToRemove = this.data[0];
            this.data.Remove(itemToRemove);

            return itemToRemove;
        }

        public int Used => this.data.Count;
    }

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> data;

        public AddRemoveCollection()
        {
            this.data = new List<string>();
        }

        public string Remove()
        {
            if (this.data.Count == 0)
            {
                return null;
            }

            string itemToRemove = this.data[this.data.Count - 1];
            this.data.Remove(itemToRemove);
            return itemToRemove;
        }

        public int Add(string item)
        {
            this.data.Insert(0, item);

            return 0; // 0th index should be return every time.
        }
    }

    public class AddOnlyCollection : IAddOnlyCollection
    {
        private List<string> data;

        public AddOnlyCollection()
        {
            this.data = new List<string>();
        }

        public int Add(string item)
        {
            this.data.Add(item);
            return this.data.Count - 1;
        }
    }

    public interface IAddOnlyCollection
    {
        int Add(string item);
    }

    public interface IAddRemoveCollection : IAddOnlyCollection
    {
        string Remove();
    }

    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}
