using System;


var countUpTo = Console.ReadLine();
int res = Convert.ToInt32(countUpTo);
            

int i = 0;
string divBy3 = "Fizz";
string divBy5 = "Buzz";
string divByBoth = "Fizz Buzz";
            
while (i <= res)
{   
    if (i == 0)
    {
        Console.WriteLine(i);
    }
        else if (i % 3 == 0 && i % 5 ==0)
    {
        Console.WriteLine(divByBoth);
    }
        else if (i % 3 == 0)
    {
        Console.WriteLine(divBy3);
    }
        else if (i % 5 == 0)
    {
        Console.WriteLine(divBy5);
    }
        else
    {
        Console.WriteLine(i);
    }
        i ++;
