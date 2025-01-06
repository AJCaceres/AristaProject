using System;


namespace ProjectArista 
{
    class Initial
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Arista!");

            // comentario
            string myString = "cadena";
            int myInt = 7;
            double myDouble = 6.5;
            float myFloat = 6.5f;
            Console.WriteLine(myString);
            Console.WriteLine(myInt);
            Console.WriteLine(myDouble);
            Console.WriteLine(myFloat);

            var myArray = new string[] {"hola", "como", "estas"};
            Console.WriteLine(myArray[0]);

            var myDictionary = new Dictionary<string, int>
            {
                {"alvaro", 27},
                {"manuel", 30},
                {"lucky",62}
            };
            Console.WriteLine(myDictionary["alvaro"]);

            var mySet = new HashSet<string> {"hola", "como", "estas"};

            for(int index = 0; index < 10; index ++)
            {
                Console.WriteLine(index);
            }
            foreach( var myItem in myArray)
            {
                Console.WriteLine(myItem);
            }
            foreach( var myItem in myDictionary)
            {
                Console.WriteLine(myItem);
            }
            foreach( var myItem in mySet)
            {
                Console.WriteLine(myItem);
            }

            MyFunction();
            Console.WriteLine(MyFunction2(5));

        }
        static void MyFunction()
        {
            Console.WriteLine("mi funcion");
        }
        static int MyFunction2(int param)
        {
            return 10 + param;
        }
    }
    
}

