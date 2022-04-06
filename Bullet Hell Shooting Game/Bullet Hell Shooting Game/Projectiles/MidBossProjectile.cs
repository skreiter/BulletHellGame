using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bullet_Hell_Shooting_Game.Projectiles
{
    class MidBossProjectile : Projectile
    {
        public MidBossProjectile(ContentManager content, Vector2 pos, Vector2 spd)
        {
            this.speed = spd;// new Vector2(0, 5);
            this.team = ProjectileTeam.ENEMY;
            this.texture = content.Load<Texture2D>("Basic_Projectile"); //need to add png
            this.position = pos;
            this.damage = 10;

            this.size = new Vector2(2, 10);
        }
    }
}

