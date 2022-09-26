    // Loop from 1-255

for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}


    // Lookup from 1-100 for values divisinle by 3 or 5 but not both

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 || i % 5 == 0)
    {
        if (i % 3 != 0 || i % 5 != 0)
        {
            Console.WriteLine(i);
        }
    }
}


    // Modify the Previous Loop

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 || i % 5 == 0)
    {
        if (i % 3 == 0 && i % 5 != 0)
        {
            Console.WriteLine("Fizz");
        }
        if (i % 3 != 0 && i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
    }
}