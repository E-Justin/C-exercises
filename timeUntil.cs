DateTime now = DateTime.Today;
DateTime thenDate = DateTime.Today;
string then = String.Empty;

while (then != "exit")
{
    then = String.Empty;  // make sure variable is empty
    bool correctFormat = false;  // set variable to false

    Console.WriteLine("Enter the date (or exit)");
    then = Console.ReadLine();  // get user input

    if(then == "exit") // exit loop if user enters 'exit'
    {
        break;
    }

    try  // try to parse date entered
    {
        thenDate = DateTime.Parse(then).Date;
        correctFormat = true;  // format is correct
    }
    catch  // if user enters invalid date format
    {
        Console.WriteLine($"'{then}' is not a proper date format");
    }

    if (correctFormat is true)  // if user entered correct date format
    {
        if (now > thenDate)  // if today happened after date entered
        {
            TimeSpan timeUntil = now - thenDate;  // get how many days since entered date happend
            Console.WriteLine($"That date happend {timeUntil.TotalDays} days ago");
        }
        else if (now < thenDate)  // if date entered has not happend yet
        {
            TimeSpan timeUntil = thenDate - now;  // get how many days until date entered
            Console.WriteLine($"That date is in {timeUntil.TotalDays} days");
        }
        else  // if today == date entered
        {
            Console.WriteLine("That date is today");
        }
    }
}
