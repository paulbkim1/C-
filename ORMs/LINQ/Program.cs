// See https://aka.ms/new-console-template for more information
List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");


var firstEruptioninChile = eruptions.Where(l => l.Location == "Chile").FirstOrDefault();
Console.WriteLine("First eruption in Chile" + firstEruptioninChile);


var firstEruptioninHawaii = eruptions.Where(l => l.Location == "Hawaiian Is").FirstOrDefault();
if (firstEruptioninHawaii == null)
{
    Console.WriteLine("No Hawaiian Is Eruption found");
}
else
{
    Console.WriteLine("First eruption in Hawaii" + firstEruptioninHawaii);
}


var NewZealandEruption = eruptions.Where(l => l.Location == "New Zealand" & l.Year > 1900).FirstOrDefault();
Console.WriteLine("First eruption in New Zealand after 1900" + NewZealandEruption);


List<Eruption> Elevation = eruptions.Where(l => l.ElevationInMeters > 2000).ToList();
Console.WriteLine("Eruptions with volcano elevation over 2000m");
PrintEach(Elevation);


List<Eruption> NameswithL = eruptions.Where(l => l.Volcano.StartsWith("L") ).ToList();
var num = NameswithL.Count();
Console.WriteLine($"{num} Volcanoes that start with L");
PrintEach(NameswithL);


var HighestElevation = eruptions.Where(e => e.ElevationInMeters == eruptions.Max(max => max.ElevationInMeters)).FirstOrDefault();
Console.WriteLine("Highest Elevation : " + HighestElevation.ElevationInMeters);


Console.WriteLine("Highest Elevation name : " + HighestElevation.Volcano);


var AllVolcanoes = eruptions.OrderBy(e => e.Volcano).Select(i => i.Volcano);
Console.WriteLine("Volcanoes in Alphabetical order:");
PrintEach(AllVolcanoes);


var AllVolcanoesbefore1000 = eruptions.Where( i => i.Year < 1000).OrderBy(e => e.Volcano).Select(i => i.Volcano);
Console.WriteLine("Volcanoes before 1000 CE in Alphabetical order:");
PrintEach(AllVolcanoesbefore1000);



// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
