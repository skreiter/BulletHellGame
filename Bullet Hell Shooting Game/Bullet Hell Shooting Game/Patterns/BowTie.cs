﻿using System;
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
    class BowTie
    {
        private List<Projectile> firePattern;
        private ProjectileFactory bowFact;
        public BowTie(ContentManager content, ProjectileType type, Vector2 pos)
        {
            firePattern = new List<Projectile>();
            bowFact = new ProjectileFactory(content);
            Vector2 speed = new Vector2(0, 300);
            pos.X += 50;
            pos.Y += 50;
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(300, 0);
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(-300, 0);
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(0, -300);
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(300, 150);
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(-300, -150);
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(300, -150);
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
            speed = new Vector2(-300, 150);
            firePattern.Add(bowFact.Create(type, pos, MovementType.CustomMovement, speed));
        }

        public List<Projectile> returnList()
        {
            return firePattern;
        }
    }
}
