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
    class TriShot
    {
        private List<Projectile> firePattern;
        private ProjectileFactory triFact;
        public TriShot(ContentManager content, ProjectileType type, Vector2 pos)
        {
            firePattern = new List<Projectile>();
            triFact = new ProjectileFactory(content);
            Vector2 speed = new Vector2(0, 5);
            Vector2 tempPos = pos;
            tempPos.X = pos.X + 50;
            tempPos.Y = pos.Y + 15 + 50;
            firePattern.Add(triFact.Create(type, tempPos, new Vector2(0, 400)));//center
            tempPos.X = pos.X - 15 + 50;
            tempPos.Y = pos.Y + 50;
            firePattern.Add(triFact.Create(type, tempPos, new Vector2(-100, 400)));//left
            tempPos.X = pos.X + 15 + 50;
            tempPos.Y = pos.Y + 50;
            firePattern.Add(triFact.Create(type, tempPos, new Vector2(100, 400)));//right
        }

        public List<Projectile> returnList()
        {
            return firePattern;
        }
    }
}

