namespace _06.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokemonTrainer
    {
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }

                var pokemonInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = pokemonInfo[0];
                string pokemonName = pokemonInfo[1];
                string pokemonElement = pokemonInfo[2];
                int pokemonHealth = int.Parse(pokemonInfo[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].Pokemon.Add(
                    new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }
            
            string command = Console.ReadLine().Trim();
            while (command != "End")
            {
                switch (command)
                {
                    case "Fire":
                        foreach (var trainer in trainers)
                        {
                            if (trainer.Value.Pokemon.Any(p => p.Element == "Fire"))
                            {
                                trainer.Value.Badges++;
                            }
                            else
                            {
                                trainer.Value.Pokemon.ForEach(p => p.Health -= 10);
                                trainer.Value.RemoveDeadPokemon();
                            }
                        }
                        break;
                    case "Water":
                        foreach (var trainer in trainers)
                        {
                            if (trainer.Value.Pokemon.Any(p => p.Element == "Water"))
                            {
                                trainer.Value.Badges++;
                            }
                            else
                            {
                                trainer.Value.Pokemon.ForEach(p => p.Health -= 10);
                                trainer.Value.RemoveDeadPokemon();
                            }
                        }
                        break;
                    case "Electricity":
                        foreach (var trainer in trainers)
                        {
                            if (trainer.Value.Pokemon.Any(p => p.Element == "Electricity"))
                            {
                                trainer.Value.Badges++;
                            }
                            else
                            {
                                trainer.Value.Pokemon.ForEach(p => p.Health -= 10);
                                trainer.Value.RemoveDeadPokemon();
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            trainers
                .OrderByDescending(t => t.Value.Badges)
                .Select(t => new
                {
                    Name = t.Value.Name,
                    Badges = t.Value.Badges,
                    Pokemon = t.Value.Pokemon.Count

                })
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.Name} {t.Badges} {t.Pokemon}"));
        }
    }

    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }
    }

    public class Trainer
    {
        private const int InitialBadges = 0;

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = InitialBadges;
            this.Pokemon = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemon { get; set; }

        public void RemoveDeadPokemon()
        {
            this.Pokemon = this.Pokemon
                .Where(p => p.Health > 0)
                .ToList();
        }
    }
}
