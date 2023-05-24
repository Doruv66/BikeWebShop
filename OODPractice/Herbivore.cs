using System;
namespace OODPractice
{
	public class Herbivore : Animal
	{
        public Herbivore(string name, Size size) : base(name, size)
        {
        }

        public override string ToString()
        {
            return base.ToString()+"-Herbivore";
        }
    }
}

