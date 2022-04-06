using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Projectiles;

namespace Bullet_Hell_Shooting_Game.Bosses
{
    abstract class Boss
    {
        protected int health;
        protected Vector2 position;
        protected Texture2D texture;
        protected Vector2 size;
        protected Vector2 speed;
        protected int stepCount;

        public Vector2 Position { get => position; }
        public Vector2 Size { get => size; }
        public Texture2D Texture { get => texture; }

        /// <summary>
        /// Subtracts a damage amount from the health of an enemy.
        /// Collision detection not currently implemented so this is unused.
        /// </summary>
        /// <param name="damage">Amount of health to be taken away.</param>
        public void DealDamage(int damage)
        {
            this.health -= damage;
        }

        /// <summary>
        /// Moves the enemy. Should work the same for all types of enemies.
        /// </summary>
        public void Move()
        {
            UpdateDirection();
            this.position.X += this.speed.X;
            this.position.Y += this.speed.Y;
        }

        public abstract void UpdateDirection();
        public abstract bool Deleter();

        public abstract List<Projectile> Attack();
    }
}

