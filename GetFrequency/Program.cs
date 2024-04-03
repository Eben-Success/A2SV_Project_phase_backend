using System;
using System.Collections.Generic;

class Program {
    static void Main(){

        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        Console.WriteLine("___Frequency of Characters___");
        foreach (var item in GetFrequency(s))
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }


        Dictionary<string, int> GetFrequency(string s){
            Dictionary<string,int> dictionary = new Dictionary<string,int>();

            foreach (char ch in s){
                if (char.IsLetter(ch)){
                    string key = ch.ToString(); // Convert char to string
                    if (dictionary.ContainsKey(key)) {
                        dictionary[key]++;
                    }
                    else{
                        dictionary[key] = 1;
                    }
                }
            }

            return dictionary;
        }
    }
}