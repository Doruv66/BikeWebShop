using System;
namespace OODPractice
{
	public class Carnivore : Animal
	{
        public Carnivore(string name, Size size) : base(name, size)
        {
        }

        public bool CanEat(Animal animal)
        {
            if (animal.GetSize() <= base.GetSize())
            {
                return true;
            }
            else { return false; }
        }

        public override string ToString()
        {
            return base.ToString()+"Carnivore";
        }
    }
}

