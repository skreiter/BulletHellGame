using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework.Content;
using Bullet_Hell_Shooting_Game.Patterns;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    public class Entity
    {

        protected int maxHP;
        protected int health;
        protected Vector2 position;
        protected Texture2D texture;
        protected Vector2 size;
        protected Movement movement;
        protected double prevShotTime;
        protected double shotInterval;
        protected ProjectileType projectileType;
        protected PatternType patternType;

        protected int stepCount;
        protected Vector2 initialPosition;
        protected bool invulnerable = false;
        public bool Invulnerable { get => invulnerable; }
        public Vector2 Position { get => position; }
        public Vector2 Size { get => size; }
        public Texture2D Texture { get => texture; }
        public ProjectileType ProjectileType { get => projectileType; }
        public PatternType PatternType { get => patternType; }
        public int StepCount { get; internal set; }

        public Entity(ContentManager content, Dictionary<string, string> entitySettings)
        {
            this.texture = content.Load<Texture2D>(entitySettings["Texture"]);
            this.initialPosition = new Vector2(Int32.Parse(entitySettings["positionX"]), Int32.Parse(entitySettings["positionY"]));
            ResetPosition();
            this.movement = (new MovementFactory()).Create((MovementType) Enum.Parse(typeof(MovementType), entitySettings ["MovementType"], true), this.position, this.size, Int32.Parse(entitySettings["speed"]));
            this.prevShotTime = float.Parse(entitySettings ["ShotInterval"]);
            this.size = new Vector2(Int32.Parse(entitySettings ["sizeX"]), Int32.Parse(entitySettings ["sizeY"]));
            this.projectileType = (ProjectileType) Enum.Parse(typeof(ProjectileType), entitySettings ["ProjectileType"], true);
            this.patternType = (PatternType)Enum.Parse(typeof(PatternType), entitySettings["PatternType"], true);
            this.shotInterval = Double.Parse(entitySettings["ShotInterval"]);
            this.health = int.Parse(entitySettings ["Health"]);
            this.maxHP = this.health;
        }

        public bool ShootCheck(double gametime)
        {
            if (this.prevShotTime + this.shotInterval < gametime)
            {
                this.prevShotTime = gametime;
                return true;
            }

            return false;
        }

        public void ResetPosition()
        {
            this.position = new Vector2(this.initialPosition.X, this.initialPosition.Y);
        }

        /// <summary>
        /// Subtracts a damage amount from the health of an enemy.
        /// Collision detection not currently implemented so this is unused.
        /// </summary>
        /// <param name="damage">Amount of health to be taken away.</param>
        public void DealDamage(int damage)
        {
            if (invulnerable)
                return;
            this.health -= damage;
        }
        
        public bool IsDead()
        {
            return health <= 0;
        }
        public void Update(double elapsedTime)
        {
            this.position = this.movement.Move(this.position, elapsedTime);
            this.stepCount = this.movement.getStepCount();

        }

        //public abstract Projectile Shoot();
        public bool Deleter()
        {
            if (this.position.X > 710 || this.position.X < -10 || this.position.Y > 820 || this.position.Y < -20)
                return true;
            return false;
        }

    }
}
