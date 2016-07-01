namespace _06.FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, params int[] stats)
        {
            this.Name = name;
            this.Endurance = stats[0];
            this.Sprint = stats[1];
            this.Dribble = stats[2];
            this.Passing = stats[3];
            this.Shooting = stats[4];
            this.OverallSkill = this.GetOverallSkill();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get { return this.endurance; }
            set
            {
                ValidateStat(value, "Endurance");
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            set
            {
                ValidateStat(value, "Sprint");
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            set
            {
                ValidateStat(value, "Dribble");
                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }
            set
            {
                ValidateStat(value, "Passing");
                this.passing = value;
            }
        }

        public int Shooting
        {
            get { return this.shooting; }
            set
            {
                ValidateStat(value, "Shooting");
                this.shooting = value;
            }
        }

        public double OverallSkill { get; }

        private double GetOverallSkill()
        {
            double result = Math.Round(
                (this.Endurance +
                this.Sprint +
                this.Dribble +
                this.Passing +
                this.Shooting)
                / 5.0);

            return result;
       }

        private static void ValidateStat(int value, string statName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }
    }
}