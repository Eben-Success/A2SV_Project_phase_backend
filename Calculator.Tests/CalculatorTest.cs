using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void GetAverageGrade_ShouldReturnCorrectAverage()
        {
            // Arrange
            var utilityClass = new UtilityClass();
            var grades = new Dictionary<string, int>
            {
                { "Math", 80 },
                { "English", 90 },
                { "Science", 85 }
            };

            // Act
            int average = utilityClass.GetAverageGrade(grades);

            // Assert
            Assert.AreEqual(85, average, "The average grade should be 85.");
        }

        [TestMethod]
        public void ValidateInput_ShouldReturnTrueForValidGrade()
        {
            // Arrange
            var utilityClass = new UtilityClass();
            int grade = 85;

            // Act
            bool isValid = utilityClass.ValidateInput(grade);

            // Assert
            Assert.IsTrue(isValid, "The grade should be considered valid.");
        }

        [TestMethod]
        public void ValidateInput_ShouldReturnFalseForInvalidGrade()
        {
            // Arrange
            var utilityClass = new UtilityClass();
            int grade = -10;

            // Act
            bool isValid = utilityClass.ValidateInput(grade);

            // Assert
            Assert.IsFalse(isValid, "The grade should be considered invalid.");
        }
    }
}