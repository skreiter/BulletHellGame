using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Projectiles
{
    class ProjectileFactory
    {
        protected ContentManager content;

        public ProjectileFactory(ContentManager content)
        {
            this.content = content;
        }

        public Projectile Create(ProjectileType type, Vector2 pos, Vector2 speed)
        {
            switch (type)
            {
                case ProjectileType.BASIC:
                    return new BasicProjectile(content, pos, speed);
                case ProjectileType.GRUNT:
                    return new GruntProjectile(content, pos, speed);
                case ProjectileType.MIDBOSS:
                    return new MidBossProjectile(content, pos, speed);
                case ProjectileType.FINALBOSS:
                    return new FinalBossProjectile(content, pos, speed);
                default:
                    return null;
            }   
        }
    }
}
