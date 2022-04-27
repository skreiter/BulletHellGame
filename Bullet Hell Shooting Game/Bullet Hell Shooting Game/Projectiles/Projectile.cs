using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Projectiles;
using Bullet_Hell_Shooting_Game.ProjectileMovements;
using Bullet_Hell_Shooting_Game.Movements;

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
    class Projectile
    {
        protected Vector2 speed;
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 size;
        protected int damage;
        protected ProjectileTeam team;
        protected Movement movement;
        public Texture2D Texture { get => texture; }
        public Vector2 Position { get => position; }
        public Vector2 Size { get => size; }

        public ProjectileTeam Team {get => team; }

        public Projectile(ProjectileTeam tm, Texture2D newTexture, Vector2 pos, MovementType movementType, Vector2 speed)
        {
            this.team = tm;
            this.texture = newTexture;
            this.position = pos;
            this.damage = 10;
            this.size = new Vector2(2, 10);
            this.movement = (new MovementFactory()).Create(movementType, pos, this.size, speed);
        }

        public int Damage { get => damage; }
        /// <summary>
        /// Moves the projectile the distance of speed with each update of main game.
        /// </summary>
        public void Move(double elapsedTime)
        {
            this.position = this.movement.Move(position, elapsedTime);
        }
        /// <summary>
        /// Kills particle. Plays particle death animation.
        /// </summary>

    }
}
