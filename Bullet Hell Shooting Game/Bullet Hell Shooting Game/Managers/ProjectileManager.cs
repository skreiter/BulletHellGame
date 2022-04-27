using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Patterns;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Managers
{
    internal class ProjectileManager
    {
        private List<Projectile> projectiles;
        private List<Entity> enemies;
        private Player player;
        private PatternFactory patternFactory;
        private double prevUpdate = 0;

        public ProjectileManager(List<Projectile> projList, List<Entity> enemyList, Player play, ContentManager content)
        {
            projectiles = projList;
            enemies = enemyList;
            player = play;
            patternFactory = new PatternFactory(content);
        }

        public void Update(double time)
        {
            foreach (Projectile proj in projectiles)
            {
                proj.Move(time - prevUpdate);
            }

            Spawn(time);
            prevUpdate = time;
        }

        private void Spawn(double time)
        {
            if (player.ShootCheck(time))
                projectiles.AddRange(patternFactory.Create(player.PatternType, player.ProjectileType, player.Position));

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].ShootCheck(time))
                {
                    //projectiles.Add(projectileFactory.Create(enemies[i].ProjectileType, enemies[i].Position));
                    if (enemies[i].PatternType == PatternType.TRI && enemies[i].StepCount > 12 && enemies[i].StepCount <= 27)
                    {
                        projectiles.AddRange(patternFactory.Create(PatternType.SCATTER, enemies[i].ProjectileType, enemies[i].Position));
                    }
                    else if (enemies[i].StepCount > 27 && enemies[i].StepCount <= 39)
                    {
                        projectiles.AddRange(patternFactory.Create(PatternType.SUNBURST, enemies[i].ProjectileType, enemies[i].Position));
                    }
                    else if (enemies[i].StepCount > 39 && enemies[i].StepCount <= 55)
                    {
                        projectiles.AddRange(patternFactory.Create(PatternType.BOWTIE, enemies[i].ProjectileType, enemies[i].Position));
                    }
                    else
                    {
                        projectiles.AddRange(patternFactory.Create(enemies[i].PatternType, enemies[i].ProjectileType, enemies[i].Position));
                    }

                }
            }
        }

        public void Reset()
        {
            projectiles.Clear();
            prevUpdate = 0;
        }
    }
}
