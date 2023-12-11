using System.Runtime.InteropServices.JavaScript;

string line;
int sum = 0;
List<string> engine = new();
try
{
    StreamReader sr = new StreamReader("D:\\Programowanie\\dotNET\\Solution1\\day3\\input.txt");
    line = sr.ReadLine();
    engine.Add(line);
    while (line != null)
    {
        line = sr.ReadLine();
        if (line is not null)
            engine.Add(line);
    }

    for (int i = 0; i < engine.Count; i++)
    {
        for (int j = 0; j < engine[i].Length; j++)
        {
            char c = engine[i][j];
            if (!(c == '.' || (c >= '0' && c <= '9')))
            {
                sum += SumNumbers(engine, i, j);
            }
        }
    }

    foreach (var VARIABLE in engine)
    {
        Console.WriteLine(VARIABLE);   
    }
    Console.WriteLine(sum);
}
catch(Exception e)
{
    Console.WriteLine(e);
}
return;


int FindAndReplaceNumber(IList<string> engine, int i, int j)
{
    var line = engine[i];
    var leftBound = j;
    var rightBound = j; 
    while (leftBound >= 0 && (line[leftBound] >= '0' && line[leftBound] <= '9'))
    {
        leftBound--;
    }
    while (rightBound < line.Length 
           && (line[rightBound] >= '0' && line[rightBound] <= '9'))
    {
        rightBound++;
    }
    // Console.WriteLine(
    //     "i: {0}" + " j: {1}\n" +
    //     "L: {2} R: {3}",
    //     i, j, leftBound, rightBound
    //                   );
    var replacement = line.ToCharArray();
    var number = "";
    for (var k = leftBound + 1; k < rightBound; k++)
    {
        number += line[k];
        replacement[k] = '.';
    }
    //Console.WriteLine(number);

    engine[i] = new string(replacement);
    //Console.WriteLine(engine[i]);
    return Int32.Parse(number);
}

int SumNumbers(List<string> engine, int i, int j)
{
    var sum = 0;
    for (var x = i-1; x <= i+1; x++)
    {
        for (var y = j-1; y <= j+1; y++)
        {
            try
            {
                if (engine[x][y] >= '0' && engine[x][y] <= '9')
                    sum += FindAndReplaceNumber(engine, x, y);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }
        }
    }

    return sum;
}
