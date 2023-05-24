using System;
namespace OODPractice
{
	public class Animal
	{
        public string name;
        public Size size;

        public Animal(string name, Size size)
        {
            this.name = name;
            this.size = size;
        }

        public int GetSize()
        {
            switch (size)
            {
                case Size.Small:
                    return 1;
                case Size.Medium:
                    return 3;
                case Size.Large:
                    return 5;
            }
            return -1;
        }

        public override string ToString()
        {
            return $"{name}-{size}";
        }
    }
}

