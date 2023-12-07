// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

string line;
int sum = 0;
char temp = '0';
bool first = false;
bool second = false;
try
{
    StreamReader sr = new StreamReader("D:\\Programowanie\\dotNET\\Solution1\\day1\\input.txt");
    line = sr.ReadLine();
    while (line != null)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (Char.IsNumber(line[i]))
            {
                temp = line[i];
                if (!first)
                {
                    sum += 10*(line[i] - '0');
                    first = !first;
                }
            }
        }
    }
    Console.WriteLine(sum);
}
catch(Exception e)
{
    
}