using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Movements;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    class GruntB : Entity
    {
        public GruntB(ContentManager content, Dictionary<string, string> entitySettings) : base(content, entitySettings)
        {
        }
        public override void Die()
        {
            //play death animation
        }
        /// <summary>
        /// I added this just to try spawning multiple enemies, not good implementation.
        /// </summary>
        //public GruntB(ContentManager content)
        //{
        //    this.position.X = 50;
        //    this.position.Y = -10;
        //    this.size.X = 16;
        //    this.size.Y = 16;
        //    //this.speed.X = 0;
        //    // this.speed.Y = 4;
        //    // this.stepCount = 0;
        //    this.movement = new GruntBMovement(4, position, size);
        //    this.prevShotTime = 0;
        //    this.texture = content.Load<Texture2D>("GruntB");
        //    projectileType = "Basic";
        //}

        //public override Projectile Shoot()
        //{
        //    Vector2 pos = this.position;
        //    pos.X += 4;
        //    pos.Y += 20;
        //    return this.projectileFactory.SpawnProjectile("Grunt", pos);
        //}
    }
}
