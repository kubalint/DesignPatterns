namespace DesignPatterns.Behavioral.Strategy;

// Define the interface for the strategy
public interface ISortingStrategy
{
    void Sort(int[] array);
}

// Define some concrete strategies that implement the interface
public class QuickSortStrategy : ISortingStrategy
{
    public void Sort(int[] array)
    {
        var sw = new Stopwatch();
        Console.WriteLine("Sorting array using quick sort.");

        sw.Start();
        QuickSort(array, 0, array.Length - 1);
        sw.Stop();

        Console.WriteLine($"Quick sort strategy sorted numbers in {sw.ElapsedMilliseconds} milisecs");
    }

    private void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] array, int left, int right)
    {
        int pivotValue = array[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (array[j] < pivotValue)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        int temp2 = array[i + 1];
        array[i + 1] = array[right];
        array[right] = temp2;
        return i + 1;
    }
}

public class BubbleSortStrategy : ISortingStrategy
{
    public void Sort(int[] array)
    {
        var sw = new Stopwatch();
        Console.WriteLine("Sorting array using bubble sort.");
        sw.Start();
        int n = array.Length;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (array[i - 1] > array[i])
                {
                    int temp = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = temp;
                    swapped = true;
                }
            }
            n--;
        } while (swapped);
        sw.Stop();
        Console.WriteLine($"Bubble sort strategy sorted numbers in {sw.ElapsedMilliseconds} milisecs");
    }
}

// Define a class that uses the strategy
public class Sorter
{
    private ISortingStrategy _strategy;

    public Sorter(ISortingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ISortingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Sort(int[] array)
    {
        _strategy.Sort(array);
    }
}

// Example usage

public static class StrategyClient
{
    public static void Run()
    {
        int[] unsortedArray = GetNumbers();
        int[] unsortedArray2 = unsortedArray.Select(x => x).ToArray();

        Sorter sorter = new Sorter(new BubbleSortStrategy());
        sorter.Sort(unsortedArray);

        sorter.SetStrategy(new QuickSortStrategy());
        sorter.Sort(unsortedArray2);
    }

    //Helper

    private static int[] GetNumbers()
    {
        var numbers = new List<int>();

        for (int i = 0; i < 1000; i++)
        {
            var random = new Random();
            var newNumber = random.Next(0, int.MaxValue);
            numbers.Add(newNumber);
        }

        return numbers.ToArray();
    }
}

/*
    The Strategy design pattern is a behavioral pattern that allows you to encapsulate a family of related algorithms and make them interchangeable. 
    The idea is to define a set of algorithms, encapsulate each one, and make them interchangeable. 
    This pattern lets the algorithm vary independently from clients that use it.

    In this example, we have an interface ISortingStrategy that defines a method Sort() for sorting an array of integers. 
    We then define two concrete strategies BubbleSortStrategy and QuickSortStrategy that implement the ISortingStrategy interface.

    We then have a Sorter class that takes an ISortingStrategy object in its constructor and has a method Sort() that calls the Sort() method on the strategy object.

    In our example usage, we create an unsorted array and a Sorter object with a BubbleSortStrategy object as its strategy. 
    We then call the Sort() method on the Sorter object, which sorts the array using the bubble sort algorithm. 
    We then set the strategy of the Sorter object to a QuickSortStrategy object and call the Sort() method again, 
    which now sorts the array using the quick sort algorithm.

    This demonstrates the flexibility of the Strategy pattern, as we can swap out different strategies at runtime without having to change 
    the code that uses the Sorter object.
*/