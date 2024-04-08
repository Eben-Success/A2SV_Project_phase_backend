// namespace Practise;
//
// public class Lambda
// {
//
//     static void Main()
//     {
//         string[] words = { "bot", "apple", "apricot" };
//
//         int minimalLength = words
//             .Where(w => w.StartsWith(("a")))
//             .Min(w => w.Length);
//         
//         Console.WriteLine(minimalLength);
//
//         int[] numbers = { 4, 7, 10 };
//         int product = numbers.Aggregate(1, (interim, next) => interim * next);
//         Console.WriteLine(product);
//
//         Func<string> greet = () => "Hello World";
//         Console.WriteLine(greet());
//
//         Func<int, int> square = x => x * x;
//         Console.WriteLine(square(5));
//
//         var myNumbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
//         var numbersOver5r5 = new List<int>();
//         //
//         // foreach (var num in myNumbers)
//         // {
//         //     if (num > 5)
//         //     {
//         //         numbersOver5.Add(num);
//         //     }
//         // }
//         //
//
//         var numbersOver5 = myNumbers.Where(n => n > 5);
//         Console.WriteLine(string.Join(", ", numbersOver5));
//
//     }
//     
//     
// }