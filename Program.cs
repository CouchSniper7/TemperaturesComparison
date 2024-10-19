using System; 

class TemperaturesComparison
{
    static void Main()
    {
        const int MinTemp = -30;
        const int MaxTemp = 130;
        const int NumberOfTemps = 5;
        double[] temperatures = new double[NumberOfTemps];
        double total = 0;

        Console.WriteLine("Enter 5 daily Fahrenheit temperatures between -30 and 130.");

        for (int i = 0; i < NumberOfTemps; i++)
        {
            bool validTemp = false;
            while (!validTemp)
            {
                Console.Write($"Enter the temperature for day #{i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out double temp) && temp >= MinTemp && temp <= MaxTemp)
                {
                    temperatures[i] = temp;
                    total += temp;
                    validTemp = true;
                }
                else
                {
                    Console.WriteLine($"Invalid entry try again.");
                }
            }
        }

        bool gettingWarmer = true;
        bool gettingColder = true;
        for (int i = 1; i < NumberOfTemps; i++)
        {
            if (temperatures[i] <= temperatures[i - 1])
            {
                gettingWarmer = false;
            }
            if (temperatures[i] >= temperatures[i - 1])
            {
                gettingColder=false;
            }
        }

        if (gettingWarmer)
        {
            Console.WriteLine("It's getting warmer.");
        }
        else if (gettingColder)
        {
            Console.WriteLine("It's getting colder.");
        }
        else
        {
            Console.WriteLine("It's a mixed bag");
        }
        Console.WriteLine("Temperatures over last 5 days:");
        foreach (double temp in temperatures)
        {
            Console.WriteLine(temp);
        }

        double average = total / NumberOfTemps;
        Console.WriteLine($"The average temeprature is : {average:F2}°F");
    }
}
