using System;

namespace ListProject
{
    class Program
    {
        static void Main(string[] args)
        {

            String[] arr = { "One", "Two", "Three", "Four", "Five" };

            DynamicList<string> list = new DynamicList<string>(arr);

            list[2] = "NotThree";

            Console.WriteLine(list.Count);

            int c = 0;
            foreach (string w in list)
            {
                if (c == 1) break;
                Console.WriteLine(w);
                c++;
            }

            Console.WriteLine();

            foreach (string w in list)
            {
                
                Console.WriteLine(w);
            }



        }
    }
}
