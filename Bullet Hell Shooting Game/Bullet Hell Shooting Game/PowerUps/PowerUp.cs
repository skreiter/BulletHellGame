using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.PowerUps
{
    internal abstract class PowerUp
    {
        protected Movement movement;
        protected Texture2D texture;
        protected Vector2 size;
        protected Vector2 position;

        public Vector2 Position { get { return position; } }
        public Texture2D Texture { get { return texture; } }

        public abstract bool Activate(Player player);
        public void Update(double elapsedTime)
        {
            this.position = this.movement.Move(this.position, elapsedTime);
        }
    }
}
