using System;
using System.Collections.Generic;

class Calculator{
    public static void Main(){

        //Instantiate UtilityClass Here
        UtiltyClass utiltyClass = new UtiltyClass();

        Dictionary<string, int> dictionary = new Dictionary<string, int>();
    
        // Accept user input
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello {name}!");
        Console.WriteLine("Enter the total subjects you have taken");
        int num = Convert.ToInt32(Console.ReadLine());

        int k = num;

        while (k > 0){
            Console.WriteLine("Grade must be greater than 0");
            Console.Write("Enter each subject and respective grade Example: English, 10: ");

            string? input = Console.ReadLine();
            string [] parts = input.Split(',');
            
            string subject = parts[0];
            int grade = Convert.ToInt32(parts[1]);

            if (!utiltyClass.ValidateInput(grade))
            {
                Console.WriteLine($"Grade must be greater than 0!. You entered {grade}");
            }
            else{
                dictionary.Add(subject, grade);
                k --;
            }
        }
        
        Console.WriteLine($"Hello {name}, ");
        Console.WriteLine($"Here are your respective subject and grade");
        Console.WriteLine("SUBJECT: GRADE");
        foreach (var KeyValuePair in dictionary)
        {
            Console.WriteLine($"{KeyValuePair.Key.ToUpper()}: {KeyValuePair.Value}");
        }

        int average = utiltyClass.GetAverageGrade(dictionary);
        Console.WriteLine($"Here is the average of your grade: {average}");

    }
}

class UtiltyClass{
    public int GetAverageGrade(Dictionary<string, int> dict)
    {
        int average = 0;
        foreach (int val in dict.Values)
        {
            average += val;
        }

        return average / dict.Count;
    }

    public bool ValidateInput(int grade){
        return grade > 0 && grade <= 100;
    }
}