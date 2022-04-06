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
    internal class Grunt : Entity
    {
        public Grunt(ContentManager content, Dictionary<string, string> entitySettings) : base(content, entitySettings)
        {

        }
        public override void Die()
        {
            //play death animation
        }
        /// <summary>
        /// I added this just to try spawning multiple enemies, not good implementation.
        /// </summary>
        //public Grunt(ContentManager content)
        //{
        //    this.position.X = 350;
        //    this.position.Y = -10;
        //    this.size.X = 16;
        //    this.size.Y = 16;
        //    this.movement = new GruntAMovement(2, position, size); //new GruntAMovement(2, position);
        //    this.prevShotTime = 0;
        //    this.texture = content.Load<Texture2D>("Grunt");
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
