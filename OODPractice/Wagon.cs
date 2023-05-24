using System;
namespace OODPractice
{
	public class Wagon
	{
        public List<Animal> animals;
        public int maxweight;

        public Wagon()
        {
            animals = new List<Animal>();
            maxweight = 10;
        }

        public void AddAnimal(Animal animal)
        {
            if (AnimalCanBeAdded(animal))
            {
                animals.Add(animal);
            }
            else return;

        }

        public bool AnimalCanBeAdded(Animal animal)
        {
            foreach (Animal a in animals)
            {
                if (a is Carnivore)
                {
                    if (((Carnivore)a).CanEat(animal))
                    {
                        return false;
                    }
                }
                if (animal is Carnivore)
                {
                    if (((Carnivore)animal).CanEat(a))
                    {
                        return false;
                    }
                }
            }
            if (animals.Sum(a => a.GetSize()) + animal.GetSize() > maxweight)
            {
                return false;
            }
            else return true;
        }
    }
}

