// namespace Practise;
//
// public class ObjectInitializers
// {
//     public class Cat
//     {
//         public int Age { get; set; }
//         public string? Name { get; set; }
//         
//         public Cat(){ }
//
//         public Cat(string name)
//         {
//             Name = name;
//         }
//     }
//
//     public static void Main()
//     {
//         Cat cat = new Cat { Age = 10, Name = "ESux" };
//         Cat sameCat = new Cat("ESux1") { Age = 10 };
//
//         List<Cat> cats = new List<Cat>
//         {
//             new Cat{ Name="Felix", Age=12},
//             new Cat{ Name="Haqq", Age=10},
//             new Cat{ Name="Sasha", Age=34}
//         };
//
//         List<Cat?> moreCats = new List<Cat?>
//         {
//             new Cat{ Name ="Mich", Age=3},
//             null
//         };
//         
//         // Display result
//         Console.WriteLine(cat.Name);
//
//         foreach (Cat c in cats)
//         {
//             Console.WriteLine(c.Name);
//         }
//
//         foreach (Cat? c in moreCats)
//         {
//             if (c != null)
//             {
//                 Console.WriteLine(c.Name);
//             }
//             else
//                 Console.WriteLine("List element has null value");
//         }
//     }
// }