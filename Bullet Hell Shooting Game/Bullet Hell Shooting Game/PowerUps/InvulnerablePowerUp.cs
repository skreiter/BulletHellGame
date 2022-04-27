using Bullet_Hell_Shooting_Game.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.PowerUps
{
    internal class InvulnerablePowerUp : PowerUp
    {
        public InvulnerablePowerUp(ContentManager content)
        {
            Random random = new Random();
            position = new Vector2(random.Next(50, 650), -10);
            texture = content.Load<Texture2D>("InvulnerablePowerUp");
            size = new Vector2(20, 20);
            movement = new MovementFactory().Create(MovementType.CustomMovement, position, size, new Vector2(0, 200));
        }

        public override bool Activate(Player player)
        {
            Vector2 playerPos = player.Position;
            Vector2 playerSize = player.Size;
            if (playerPos.X + playerSize.X > position.X && position.X + size.X > playerPos.X && playerPos.Y + playerSize.Y > position.Y && position.Y + size.Y > playerPos.Y)
            {
                player.MakeInvulnerable();
                return true;
            }

            return false;
        }
    }
}
