using System;
using System.IO;
using Zad2Serializer.ObjectModel;
using Zad2Serializer.Serialization;
using System.Runtime.Serialization;

namespace Zad2ConsoleApp
{
    class Program
    {
        static ABC changeType(A a, B b, C c)
        {
            Console.WriteLine("Choose type A / B / C" + "\n");
            char x = Convert.ToChar(Console.ReadLine());
            switch (x)
            {
                case 'A':
                    {
                        return a;
                    }
                case 'B':
                    {
                        return b;
                    }
                case 'C':
                    {
                        return c;
                    }
                case 'a':
                    {
                        return a;
                    }
                case 'b':
                    {
                        return b;
                    }
                case 'c':
                    {
                        return c;
                    }
                default:
                    {
                        return a;
                    }
            }

        }


        static void Main(string[] args)
        {
            A a;
            B b;
            C c;

            string[] names;
            string[] lastNames;
            int[] numbers;
            DateTime[] dates;
            a = new A("Dominik", "Karski", 2137, new DateTime(2019, 12, 1), null);
            b = new B("Sebastian", "Kujawski", 9669, new DateTime(2019, 10, 1), null);
            c = new C("Winston", "Churchill", 5321, new DateTime(2020, 1, 2), null);

            a.ObjB = b;
            b.ObjC = c;
            c.ObjA = a;
            int x = 10;
            ABC holder = a;


            while (x != 0)
            {
                Console.Clear();
                Console.WriteLine("JSON serialization (1)");
                Console.WriteLine("JSON deserialization (2)");
                Console.WriteLine("Custom serialization (3)");
                Console.WriteLine("Custom deserialization (4)");
                Console.WriteLine("Change type from A (5)");
                Console.WriteLine("Quit (0)");
                x = Convert.ToInt32(Console.ReadLine());
                switch(x){
                    case 1:
                        {
                            JSONSerialization<ABC> serialize = new JSONSerialization<ABC>("AConsoleResultJSON.json", holder);
                            serialize.serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " serialized to JSON format" + "\n");
                            break;
                        }                
                    case 2:
                        {
                            string fileName = "AConsoleJsonDesTmp.json";
                            JSONSerialization<ABC> serialize = new JSONSerialization<ABC>(fileName, holder);
                            serialize.serialize();
                            JSONSerialization<ABC> tmp = new JSONSerialization<ABC>(fileName, holder);
                            ABC desResult = tmp.deserialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " deserialized fromt JSON format" + "\n");
                            Console.WriteLine(desResult.ToString());
                            break;
                        }
                    case 3:
                        {
                            CustomSerialization<ABC> serialize = new CustomSerialization<ABC>("AConsoleSerializationResultCustom.txt", holder);
                            serialize.serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + "serialized to custom format" + "\n");
                            break;
                        }
                    case 4:
                        {
                            string fileName = "AConsoleCustomDesTmp.json";
                            CustomSerialization<ABC> serialize = new CustomSerialization<ABC>(fileName, holder);
                            serialize.serialize();
                            CustomSerialization<ABC> tmp = new CustomSerialization<ABC>(fileName, holder);
                            // ABC desResult = tmp.deserialize();
                            //  Console.WriteLine("Object " + holder.GetType().Name +" deserialized from Custom format" + "\n");
                            //   Console.WriteLine(desResult.ToString());

                            break;
                        }
                    case 5:
                        {
                            holder = changeType(a, b, c);
                            Console.WriteLine("Object type changed to " + holder.GetType().Name);
                            break;
                        }
     
                    }
                Console.WriteLine("\n" + "Press Key to Continue");
                Console.ReadKey();

            }
            
    }
    }

}