namespace Practise;

public class LINQ
{
    public void Main()
    {
        List<int> scores = [22, 13, 45, 16, 47, 80];

        IEnumerable<int> queryScore =
            from score in scores
            where score > 20
            select score;

        foreach (var score in queryScore)
        {
            Console.WriteLine(score + " ");
        }
    }
}