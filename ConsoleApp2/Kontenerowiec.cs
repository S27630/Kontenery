using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    public class Kontenerowiec
    {
        public List<Kontener> Containers { get; private set; }
        public int MaxSpeed { get; private set; }
        public int MaxContainers { get; private set; }
        public double MaxTotalWeight { get; private set; }

        public Kontenerowiec(int maxSpeed, int maxContainers, double maxTotalWeight)
        {
            Containers = new List<Kontener>();
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxTotalWeight = maxTotalWeight;
        }

        public void AddContainer(Kontener container)
        {
            if (Containers.Count < MaxContainers)
            {
                Containers.Add(container);
            }
            else
            {
                Console.WriteLine("Maksymalna liczba kontenerów.");
            }
        }

        public void RemoveContainer(Kontener container)
        {
            Containers.Remove(container);
        }

        public double CalculateTotalWeight()
        {
            double totalWeight = 0;
            foreach (Kontener container in Containers)
            {
                totalWeight += container.GetLoadWeight();
            }
            return totalWeight;
        }

        public void UnloadContainer(Kontener container)
        {
            if (Containers.Contains(container))
            {
                Containers.Remove(container);
                Console.WriteLine("Kontener o numerze seryjnym {container.SerialNumber} został usunięty ze statku.");
            }
            else
            {
                Console.WriteLine("Podany kontener nie znajduje się na statku.");
            }
        }
        public bool IsReadyForVoyage()
        {
            if (CalculateTotalWeight() <= MaxTotalWeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Informacje o statku:");
            Console.WriteLine($"Maksymalna prędkość: {MaxSpeed} węzłów");
            Console.WriteLine($"Maksymalna liczba kontenerów: {MaxContainers}");
            Console.WriteLine($"Maksymalna waga ładunku: {MaxTotalWeight} ton\n");

            Console.WriteLine($"Ładunek na statku:");
            if (Containers.Count > 0)
            {
                foreach (Kontener container in Containers)
                {
                    Console.WriteLine($"Numer seryjny: {container.SerialNumber}");
                    Console.WriteLine($"Masa ładunku: {container.GetLoadWeight()} kg");
                    Console.WriteLine($"Wysokość: {container.Height} cm");
                    Console.WriteLine($"Waga własna: {container.OwnWeight} kg");
                    Console.WriteLine($"Głębokość: {container.Depth} cm");
                }
            }
            else
            {
                Console.WriteLine("Brak kontenerów na statku.");
            }
        }
    }
}