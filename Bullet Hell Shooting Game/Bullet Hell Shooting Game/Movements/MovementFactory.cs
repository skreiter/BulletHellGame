using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class MovementFactory
    {
        public Movement Create(MovementType type, Vector2 pos, Vector2 size, Vector2 speed)
        {
            switch (type)
            {
                case MovementType.USER:
                    return new UserControlMovement(speed, pos, size);
                case MovementType.GRUNTA:
                    return new GruntAMovement(speed, pos, size);
                case MovementType.GRUNTB:
                    return new GruntBMovement(speed, pos, size);
                case MovementType.MIDBOSS:
                    return new MidBossMovement(speed, pos, size);
                case MovementType.FINALBOSS:
                    return new FinalBossMovement(speed, pos, size);
                case MovementType.CustomMovement:
                        return new CustomMovement(speed, pos, size);
                default:
                    return null;
            }
        }

        public Movement Create(MovementType type, Vector2 pos, Vector2 size, float fspeed)
        {
            Vector2 speed = new Vector2(fspeed, fspeed);
            switch (type)
            {
                case MovementType.USER:
                    return new UserControlMovement(speed, pos, size);
                case MovementType.GRUNTA:
                    return new GruntAMovement(speed, pos, size);
                case MovementType.GRUNTB:
                    return new GruntBMovement(speed, pos, size);
                case MovementType.MIDBOSS:
                    return new MidBossMovement(speed, pos, size);
                case MovementType.FINALBOSS:
                    return new FinalBossMovement(speed, pos, size);
                default:
                    return null;
            }
        }

    }
}
