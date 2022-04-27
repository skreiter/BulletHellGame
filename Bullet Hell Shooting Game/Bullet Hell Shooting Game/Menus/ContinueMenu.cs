using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bullet_Hell_Shooting_Game
{
    

    internal class ContinueMenu
    {
        private Input input = new Input();
        private bool option = true;
        private bool delay = false;
        private int delayValue = 500;
        public SpriteFont font;
        private Texture2D texture;
        public ContinueMenu(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Time");

        }
        public bool Update(GameTime gameTime)
        {
            

            if (input.GetMoveInput().Y != 0 && !delay)
            {
                
                Timer timer = new Timer(delayValue);
                timer.Elapsed += setDelay;
                delay = true;
                timer.Start();
                option = !option;
            }
            if(input.GetShotInput() && !delay)
            {
                if (!option)
                {
                    Environment.Exit(0);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.DrawString(font, "CONTINUE?", new Vector2(200, 100), Color.White, 0, Vector2.One, 3, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Yes", new Vector2(200, 200), option ? Color.Red : Color.White, 0, Vector2.One, 2, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "No", new Vector2(200, 300), option ? Color.White : Color.Red, 0, Vector2.One, 2, SpriteEffects.None, 1);
        }

        private void setDelay(object sender, ElapsedEventArgs e)
        {
            this.delay = false;
        }
    }

}
