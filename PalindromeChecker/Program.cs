using System;

class PalindromeChecker
{
    static void Main()
    {

        // Accept user input
        Console.WriteLine("____Palindrome Checker____");
        Console.WriteLine("Enter a string to check if it is a palindrome: ");
        string str = Console.ReadLine();

        if (isPalindrome(str))
        {
            Console.WriteLine("The string is a palindrome");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome");
        }
        
        // Check if the string is a palindrome
        static bool isPalindrome(string str)
        {
            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }
    }
}