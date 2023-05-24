using System;
using OODPractice;
namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainService service = new TrainService();
            service.MockAnimals();
            service.DivideAnimalsInTrainCars();
            for(int i =0; i < service.wagons.Count; i++) {
                Console.WriteLine($"Wagon {i+1}");
                foreach (Animal a in service.wagons[i].animals)
                {
                    Console.WriteLine(a.ToString() +" "+ a.GetSize());
                }
            }
            Console.Read();
        }


        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap arr[j+1] and arr[j]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static int BinarySearch(int[] arr, int key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == key)
                    return mid;
                if (arr[mid] < key)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        public static int LinearSearch(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length - 1; i++) {
                if (arr[i] == key) {
                    return i;
                }
            }
            return -1;
        }

        public static int Factorial(int n) {
            if (n == 0) {
                return 1;
            }
            else {
                return n * Factorial(n - 1);
            }
        }
    }


}



