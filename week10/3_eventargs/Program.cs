using System;

namespace _3_eventargs
{
    public class PlayerInfo : EventArgs
    {
        public string Name { get; set; }
        public int Health { get; set; }
    }
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public event EventHandler<PlayerInfo> deathEvent;

        public void Die()
        {
            var info = new PlayerInfo { Name = Name, Health = Health };
            deathEvent?.Invoke(this, info);
        }
    }

    public class Achievements
    {
        public void OnPlayerDeath(object sender, PlayerInfo info)
        {
            Console.WriteLine($"Achievements: Player {info.Name} died.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player { Name = "Osman", Health = 100 };
            var achievements = new Achievements();
            player.deathEvent += achievements.OnPlayerDeath;
            player.Die();
        }
    }
}
