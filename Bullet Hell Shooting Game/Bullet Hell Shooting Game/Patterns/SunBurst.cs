using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Projectiles;


namespace Bullet_Hell_Shooting_Game.Patterns
{
    class SunBurst
    {
        private List<Projectile> firePattern;
        private ProjectileFactory sunFact;
        public SunBurst(ContentManager content, ProjectileType type, Vector2 pos)
        {
            firePattern = new List<Projectile>();
            sunFact = new ProjectileFactory(content);
            Vector2 speed = new Vector2(0, 5);
            pos.X += 50;
            pos.Y += 50;
            firePattern.Add(sunFact.Create(type, pos, speed));
            speed = new Vector2(5, 0);
            firePattern.Add(sunFact.Create(type, pos, speed));
            speed = new Vector2(-5, 0);
            firePattern.Add(sunFact.Create(type, pos, speed));
            speed = new Vector2(0,-5);
            firePattern.Add(sunFact.Create(type, pos, speed));
            speed = new Vector2(5, 5);
            firePattern.Add(sunFact.Create(type, pos, speed));
            speed = new Vector2(-5, -5);
            firePattern.Add(sunFact.Create(type, pos, speed));
            speed = new Vector2(5, -5);
            firePattern.Add(sunFact.Create(type, pos, speed));
            speed = new Vector2(-5, 5);
            firePattern.Add(sunFact.Create(type, pos, speed));
        }

        public List<Projectile> returnList()
        {
            return firePattern;
        }
    }
}
