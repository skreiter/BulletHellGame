using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game
{
    internal class Keybinds
    {
        private Keys userUp;
        private Keys userDown;
        private Keys userLeft;
        private Keys userRight;
        private Keys userShoot;
        public Keys UserUp { get { return userUp; } }
        public Keys UserDown { get { return userDown; } }
        public Keys UserLeft { get { return userLeft; } }
        public Keys UserRight { get { return userRight; } }
        public Keys UserShoot { get { return userShoot; } }

        public Keybinds(Dictionary<string, string> binds)
        {
            Enum.TryParse(binds["Up"], out userUp);
            Enum.TryParse(binds["Down"], out userDown);
            Enum.TryParse(binds["Left"], out userLeft);
            Enum.TryParse(binds["Right"], out userRight);
            Enum.TryParse(binds["Shoot"], out userShoot);
        }
    }
}
