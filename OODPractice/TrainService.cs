using System;
namespace OODPractice
{
    public class TrainService
    {
        public List<Wagon> wagons;
        public List<Animal> animals;

        public TrainService()
        {
            wagons = new List<Wagon>();
            animals = new List<Animal>();
        }

        public void MockAnimals()
        {
            animals.Add(new Carnivore("Lion", Size.Small));
            animals.Add(new Carnivore("parrot", Size.Small));
            animals.Add(new Carnivore("Bear", Size.Small));
            animals.Add(new Carnivore("husky", Size.Small));
            animals.Add(new Carnivore("hiena", Size.Small));
            animals.Add(new Carnivore("duca", Size.Large));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Small));
            animals.Add(new Herbivore("Gabi", Size.Medium));
            animals.Add(new Herbivore("Gabi", Size.Medium));
            animals.Add(new Herbivore("Gabi", Size.Medium));
            animals.Add(new Herbivore("Gabi", Size.Medium));
            animals.Add(new Herbivore("Gabi", Size.Medium));
            animals.Add(new Herbivore("Gabi", Size.Large));
        }

        public void DivideAnimalsInTrainCars()
        {
            SortAnimalsDescending();
            foreach (Animal a in animals)
            {
                Wagon wagon = FindSuitableWagon(a);
                if (wagon == null)
                {
                    wagon = new Wagon();
                    wagons.Add(wagon);
                }
                wagon.AddAnimal(a);
            }
        }

        public Wagon FindSuitableWagon(Animal animal)
        {
            foreach (Wagon w in wagons)
            {
                if (w.AnimalCanBeAdded(animal))
                {
                    return w;
                }
            }
            return null;
        }

        public void SortAnimalsDescending()
        {
            for (int i = 0; i < animals.Count - 1; i++)
            {
                for (int j = 0; j < animals.Count - i - 1; j++)
                {
                    if (animals[j].GetSize() < animals[j + 1].GetSize())
                    {
                        Animal temp = animals[j];
                        animals[j] = animals[j + 1];
                        animals[j + 1] = temp;
                    }
                }
            }
        }
    }
}

