using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Projectiles;

namespace Bullet_Hell_Shooting_Game.Projectiles
{
    /// <summary>
    /// Determines which units the projectile's damage
    /// </summary>
    public enum ProjectileTeam
    {
        PLAYER, //only hits enemies
        ENEMY, //only hits player
        NEUTRAL, //hits both player and enemy
    }
    abstract class Projectile
    {
        protected Vector2 speed;
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 size;
        protected int damage;
        protected ProjectileTeam team;
        public Texture2D Texture { get => texture; }
        public Vector2 Position { get => position; }
        public Vector2 Size { get => size; }

        public ProjectileTeam Team {get => team; }

        public int Damage { get => damage; }
        /// <summary>
        /// Moves the projectile the distance of speed with each update of main game.
        /// </summary>
        public void Move(double elapsedTime)
        {
            this.position += speed * (float)elapsedTime;
        }
        /// <summary>
        /// Kills particle. Plays particle death animation.
        /// </summary>

    }
}
