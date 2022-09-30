    // Random Array
static void RandomArray()
{
    Random rand = new Random();
    int[] arrayvalue = new int[10];
    for (int i = 0; i < arrayvalue.Length; i++)
    {
        arrayvalue[i] = rand.Next(5,26);
    }
    Console.WriteLine(arrayvalue.Min());
    Console.WriteLine(arrayvalue.Max());
    Console.WriteLine(arrayvalue.Sum());
}


    // Coin Flip
static string TossCoin()
{
    Console.WriteLine("Tossing a Coin!");
    Random rand = new Random();
    int randomvalue = rand.Next(1,3);
    Console.WriteLine(randomvalue);
    if (randomvalue == 1)
    {
        Console.WriteLine("Heads");
        return "Heads";
    }
    else
    {
        Console.WriteLine("Tails");
        return "Tails";
    }
}


    // Names
static List<string> Names()
{
    List<string> ListofNames = new List<string>() {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
    for (int i = 0; i < ListofNames.Count; i++)
    {
        if (ListofNames[i].Length < 6)
        {
            ListofNames.Remove(ListofNames[i]);
        }
    }
    return ListofNames;
}

RandomArray();
TossCoin();
Names();