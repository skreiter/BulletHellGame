using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Projectiles;
using Bullet_Hell_Shooting_Game.Movements;

namespace Bullet_Hell_Shooting_Game.Patterns
{
    class SingleShot
    {
        private List<Projectile> firePattern;
        private ProjectileFactory singFact;
        public SingleShot(ContentManager content, ProjectileType type, Vector2 pos)
        {
            firePattern = new List<Projectile>();
            singFact = new ProjectileFactory(content);
            Vector2 speed = new Vector2(0, 400);
            if(type == ProjectileType.BASIC)
            {
                speed = new Vector2(0, -400);
            }
            firePattern.Add(singFact.Create(type, pos, MovementType.CustomMovement, speed));
        }

        public List<Projectile>returnList()
        {
            return firePattern;
        }
    }
}
