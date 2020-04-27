using System;

namespace _2_eventhandler
{
    public class Player
    {
        public event EventHandler playerDeath;

        public string Name { get; set; }
        public int Health { get; set; }

        public void Die()
        {
            playerDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Achievements
    {
        public void OnPlayerDeath(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Achievements: {(sender as Player).Name} has died.");
        }
    }

    public class UserInterface
    {
        public void OnPlayerDeath(object sender, EventArgs eventArgs)
        {
            Player player = (Player)sender;
            Console.WriteLine($"UI: RIP {player.Name} has died.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player { Name = "Osman", Health = 100 };
            var ui = new UserInterface();
            var achievements = new Achievements();
            player.playerDeath += ui.OnPlayerDeath;
            player.playerDeath += achievements.OnPlayerDeath;
            player.Die();
        }
    }
}
