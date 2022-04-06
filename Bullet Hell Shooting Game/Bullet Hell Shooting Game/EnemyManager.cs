using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Movements;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    public class EnemyManager
    {
        private Settings settings;
        private EnemyFactory enemyFactory;
        private int interval;

        private List<int> spawnintervals = new List<int>();
        private List<int> spawnstarttimes = new List<int>();
        private List<string> types = new List<string>();
        private List<int> currentAmounts = new List<int>();
        private List<int> startingAmounts = new List<int>();
        private int wave;
        private int maxwave;
        public EnemyManager(Settings settings, ContentManager Content)
        {
            this.settings = settings;
            this.wave = 1;
            this.enemyFactory = new EnemyFactory(Content);

            for (int i = 1; i <= settings.Stage1.Count; i++)
            {
                foreach (KeyValuePair<string, string> kvp in this.settings.Stage1[i.ToString()])
                {
                    if (kvp.Key == "interval")
                    {
                        this.spawnintervals.Add(Int32.Parse(kvp.Value));

                    }
                    if (kvp.Key == "enemyType")
                    {
                        this.types.Add((kvp.Value));

                    }
                    if (kvp.Key == "enemyAmount")
                    {
                        this.startingAmounts.Add(Int32.Parse(kvp.Value));
                        this.currentAmounts = new List<int>(startingAmounts);

                    }
                    if (kvp.Key == "time")
                    {
                        this.spawnstarttimes.Add(Int32.Parse(kvp.Value));

                    }

                }
            }
            this.interval = spawnintervals[0];
            this.maxwave = spawnintervals.Count;
        }
        public Entity GetEnemy()
        {
            return enemyFactory.SpawnEnemy(types[wave - 1], settings.Enemies);
        }

        public bool getInterval(double gameTime)
        {

            if (gameTime >= this.interval && gameTime >= spawnstarttimes[wave - 1])
            {
                this.interval += this.spawnintervals[wave - 1];
                return true;
            }

            return false;
        }

        public Entity Update(GameTime gameTime)
        {

            if (currentAmounts[wave - 1] == 0 && wave < maxwave)
            {
                wave += 1;
            }
            currentAmounts[wave - 1] -= 1;
            return GetEnemy();


        }

        public void Reset()
        {
            wave = 1;
            this.currentAmounts = new List<int>(startingAmounts);
            this.interval = 0;
        }

        public bool LastWave()
        {
            if (currentAmounts.Last() == 0)
            {
                return false;
            }
            return true;
        }
    }
}

