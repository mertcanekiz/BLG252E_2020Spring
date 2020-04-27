using System;

namespace _1_event
{
    public class Player
    {
        public event Action playerDeath;

        public void Die()
        {
            Console.WriteLine("Player: Died");
            playerDeath?.Invoke();
        }
    }

    public class Achievements
    {
        public void OnPlayerDeath()
        {
            Console.WriteLine("Achievements: Player died");
        }
    }

    public class UserInterface
    {
        public void OnPlayerDeath()
        {
            Console.WriteLine("User Interface: Player died");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Player();
            var achievements = new Achievements();
            var ui = new UserInterface();
            p1.playerDeath += achievements.OnPlayerDeath;
            p1.playerDeath += ui.OnPlayerDeath;
            p1.Die();
        }
    }
}
