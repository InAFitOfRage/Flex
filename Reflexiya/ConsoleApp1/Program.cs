using System;
using System.Collections.Generic;
using System.Reflection;
using webapi1.Controllers;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mass = new List<Type> { 
                typeof(HomeController)
                // и т.д
            };

            foreach(var m in mass)
            {
                Assembly a = m.Assembly;
                var types = a.DefinedTypes.Where(t=> t.Name.ToLower().Contains("controller")).ToList();
                foreach(var t in types)
                {
                    var functions = t.GetMethods().Where(f => f.IsPublic).Where(f1 => f1.CustomAttributes.Any(cAttr => cAttr.AttributeType == typeof(ObsoleteAttribute))).ToList();
                    functions.ForEach(f =>
                    {
                        Console.WriteLine(f.DeclaringType.FullName);
                        Console.WriteLine(f.Name);
                    });
                    
                }
                Console.Read();
            }


            Console.ReadKey();
        }
    }
}
