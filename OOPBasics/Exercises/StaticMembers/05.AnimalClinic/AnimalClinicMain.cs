namespace _05.AnimalClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AnimalClinicMain
    {
        public static void Main()
        {
            int id = 1;
            string input = Console.ReadLine();
            while (input != "End")
            {
                var patientInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = patientInfo[0];
                string breed = patientInfo[1];
                string operation = patientInfo[2];

                var animal = new Animal(name, breed, operation);
                if (operation == "rehabilitate")
                {
                    AnimalClinic.Rehabilitate(animal);
                    Console.WriteLine
                        ($"Patient {AnimalClinic.PatientId}: [{animal.Name} ({animal.Breed})] has been rehabilitated!");
                }
                else if (operation == "heal")
                {
                    AnimalClinic.Heal(animal);
                    Console.WriteLine
                        ($"Patient {AnimalClinic.PatientId}: [{animal.Name} ({animal.Breed})] has been healed!");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total healed animals: {AnimalClinic.HealedAnimals}");
            Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.RehabilitatedAnimals}");

            var patients = AnimalClinic.GetAllPatients();
            string criteria = Console.ReadLine();

            patients
                .Where(p => p.State == criteria)
                .Select(x => new
                {
                    Name = x.Name,
                    Breed = x.Breed
                })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Breed}"));

        }
    }

    public static class AnimalClinic
    {
        private static int patientId;
        private static int healedAnimalsCount;
        private static int rehabilitedAnimalsCount;
        private static readonly List<Animal> patients = new List<Animal>();

        public static int PatientId => patientId;

        public static int HealedAnimals => healedAnimalsCount;

        public static int RehabilitatedAnimals => rehabilitedAnimalsCount;

        public static void Heal(Animal animal)
        {
            healedAnimalsCount++;
            patientId++;
            patients.Add(animal);
        }

        public static void Rehabilitate(Animal animal)
        {
            rehabilitedAnimalsCount++;
            patientId++;
            patients.Add(animal);
        }

        public static List<Animal> GetAllPatients()
        {
            return patients;
        }
    }

    public class Animal
    {
        public Animal(string name, string breed, string state)
        {
            this.Name = name;
            this.Breed = breed;
            this.State = state;
        }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string State { get; set; }
    }
}
