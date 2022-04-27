using Bullet_Hell_Shooting_Game.PowerUps;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Bullet_Hell_Shooting_Game.Managers
{
    internal class PowerUpManager
    {
        private List<PowerUp> powerUps;
        private Player player;
        private double prevUpdate = 0;
        private int nextSpawn;
        private PowerUpFactory factory;

        public PowerUpManager(Player play, List<PowerUp> powerUpList, ContentManager content)
        {
            player = play;
            powerUps = powerUpList;
            factory = new PowerUpFactory(content);

            GetRandomSpawn();
        }

        public void Update(double time)
        {
            foreach (PowerUp powerUp in powerUps)
            {
                powerUp.Update(time - prevUpdate);
                if (powerUp.Activate(player))
                    powerUps.Remove(powerUp);
            }

            if (nextSpawn < time)
            {
                powerUps.Add(factory.Create());
                GetRandomSpawn();
            }

            prevUpdate = time;
        }

        private void GetRandomSpawn()
        {
            Random rnd = new Random();
            nextSpawn = rnd.Next(20, 40);
        }

        public void Reset()
        {
            powerUps.Clear();
            prevUpdate = 0;
        }
    }
}
