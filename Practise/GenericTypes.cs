namespace Practise;

public class Program
{
    public static void Main()
    {
        int[] arrInts = [1, 23, 4, 5, 6];
        double[] arrDoubles = [3.2, 4.6, 2.3, 6.7];
        string[] arraystring = ["1", "a", "helloworld"];
        
        DisplayData(arrInts);
        DisplayData(arraystring);
        DisplayData(arrDoubles);
    }

    public static void DisplayData<T>(T[] items)
    {
        foreach (T item in items)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}