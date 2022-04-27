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
    class Scatter
    {
        private List<Projectile> firePattern;
        private ProjectileFactory scatFact;
        public Scatter(ContentManager content, ProjectileType type, Vector2 pos)
        {
            firePattern = new List<Projectile>();
            scatFact = new ProjectileFactory(content);
            Vector2 speed = new Vector2(0, 300);
            pos.X += 50;
            pos.Y += 50;
            firePattern.Add(scatFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(-125, 300);
            firePattern.Add(scatFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(-250, 300);
            firePattern.Add(scatFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(125, 300);
            firePattern.Add(scatFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(250, 300);
            firePattern.Add(scatFact.Create(type, pos, MovementType.CustomMovement, speed));
            
        }

        public List<Projectile> returnList()
        {
            return firePattern;
        }
    }
}
