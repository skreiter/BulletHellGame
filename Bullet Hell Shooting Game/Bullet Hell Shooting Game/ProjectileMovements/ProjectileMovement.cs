using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.ProjectileMovements
{
    internal abstract class ProjectileMovement
    {
        protected Vector2 speed;

        public ProjectileMovement(Vector2 newSpeed)
        {
            this.speed = newSpeed;
        }

    }
}
