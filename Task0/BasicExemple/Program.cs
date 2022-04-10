using BasicExemple;

Console.WriteLine("Hello, World! \n");
Console.WriteLine("Choose if you want to add or substract 2 numbers \n");
Console.WriteLine("Write 1 for addition or 2 for substract \n");


int choice = 0;

while(choice == 0)
{
    string v = Console.ReadLine();
    if (v == "1")
    {
        choice = 1;
    }
    else if(v == "2")
    {
        choice = 2;
    }
    else
    {
        Console.WriteLine("Please make a valid choice\n");
    }
        
}

Console.WriteLine("Number A :");
int numberA = 0;
int.TryParse(Console.ReadLine(), out numberA);
Console.WriteLine("\nNumber B : ");
int numberB = 0;
int.TryParse(Console.ReadLine(), out numberB);

if(choice == 1)
{
    Console.WriteLine(numberA + " + " + numberB + " = " + Operation.Add(numberA, numberB));
}
if(choice == 2)
{
    Console.WriteLine(numberA + " - " + numberB + " = " + Operation.Minus(numberA, numberB));
}

