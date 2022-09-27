    // Arrays

int[] array = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};

bool[] trueorfalse = new bool[] {true, false, true, false, true, false, true, false, true, false};


    // List of Flavors

List<string> icecream = new List<string>() {"Chocolate", "Vanilla", "Strawberry", "Oreo", "Pineapple"}; 

Console.WriteLine(icecream.Count);

Console.WriteLine(icecream[2]);
icecream.Remove("Strawberry");

Console.WriteLine(icecream.Count);


    // User info Dictionary

Dictionary <string,string> user = new Dictionary <string, string> ();
Random rand = new Random();
user.Add("Tim", icecream[rand.Next(icecream.Count)]);
user.Add("Martin", icecream[rand.Next(icecream.Count)]);
user.Add("Nikki", icecream[rand.Next(icecream.Count)]);
user.Add("Sara", icecream[rand.Next(icecream.Count)]);
foreach (var i in user)
{
    Console.WriteLine(i);
}