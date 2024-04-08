// using NUnit.Framework;
// using System.Collections.Generic;
// using GetFrequency;
//
// namespace GetFrequency.Tests
// {
//     public class Tests
//     {
//         [SetUp]
//         public void Setup()
//         {
//         }
//
//         [Test]
//         public void TestGetFrequency()
//         {
//             // Arrange
//             string str = "hello";
//
//             // Act
//             Dictionary<string, int> result = Program.GetFrequency(str);
//
//             // Assert
//             Assert.AreEqual(4, result.Count);
//             Assert.IsTrue(result.ContainsKey("h"));
//             Assert.IsTrue(result.ContainsKey("e"));
//             Assert.IsTrue(result.ContainsKey("l"));
//             Assert.IsTrue(result.ContainsKey("o"));
//             Assert.AreEqual(1, result["h"]);
//             Assert.AreEqual(1, result["e"]);
//             Assert.AreEqual(2, result["l"]);
//             Assert.AreEqual(1, result["o"]);
//         }
//     }
// }