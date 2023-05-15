public class Program
{
    public static void Main()
    {
        int[] input1 = { 1, 2, 3, 4, 5 };
        int[] input2 = { 15, 25, 35 };
        int[] input3 = { 8, 8 };

        Console.WriteLine("Output: " + CalculateScore(input1));
        Console.WriteLine("Output: " + CalculateScore(input2));
        Console.WriteLine("Output: " + CalculateScore(input3));
    }

    public static int CalculateScore(int[] array)
    {
        int score = 0;

        foreach (int item in array)
        {
            if (item % 2 == 0)
                score += 1;
            else
                score += 3;

            if (item == 8)
                score += 5;
        }

        return score;
    }
}