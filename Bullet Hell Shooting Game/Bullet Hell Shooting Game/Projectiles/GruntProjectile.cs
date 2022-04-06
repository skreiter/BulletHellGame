using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Projectiles
{
    class GruntProjectile : Projectile
    {
        public GruntProjectile(ContentManager content, Vector2 pos, Vector2 spd)
        {
            this.speed = spd;// new Vector2(0, 5);
            this.team = ProjectileTeam.ENEMY;
            this.texture = content.Load<Texture2D>("Grunt_Projectile");
            this.position = pos;
            this.damage = 10;
            this.size = new Vector2(8, 12);
        }
    }
}
