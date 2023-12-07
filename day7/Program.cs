using day7;

string line;
int sum = 0;
List<Hand> hands = new();
try
{
    StreamReader sr = new StreamReader("D:\\Programowanie\\dotNET\\Solution1\\day7\\input.txt");
    line = sr.ReadLine();
    while (line != null)
    {
        var split = line.Split(' ');
        hands.Add(new Hand(split[0], Int32.Parse(split[1])));
        line = sr.ReadLine();
    }
    hands.Sort();
    for (int i = 0; i < hands.Count; i++)
        sum += hands[i].Bid * (i+1);
    // foreach (var h in hands)
    // {
    //     Console.Write(h.Cards);
    //     Console.Write(" ");
    //     Console.Write(h.Bid);
    //     // Console.WriteLine();
    //     Console.Write(" ");
    //    Console.WriteLine(h.HandType.ToString());
    // }
    Console.WriteLine(sum);
}
catch(Exception e)
{
    
}