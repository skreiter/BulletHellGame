using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Projectiles;

using Bullet_Hell_Shooting_Game.Patterns;
using Bullet_Hell_Shooting_Game.PowerUps;
using Bullet_Hell_Shooting_Game.Content.Engine.Interpreters;
using Bullet_Hell_Shooting_Game.Managers;
using Bullet_Hell_Shooting_Game.Menus;

namespace Bullet_Hell_Shooting_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player player;
        private Settings settings;
        private Keybinds keybinds;

        private SpriteFont font;

        private double previousUpdate = 0;
        private double lastReset = 0;

        private List<Entity> enemies;
        private List<Projectile> projectiles;
        private List<PowerUp> powerUps;


        private float spawn = 0;
        private bool menuOpen = true;
        private MainMenu menu;

        private EnemyManager enemyManager;
        private ProjectileManager projectileManager;
        private PowerUpManager powerUpManager;

        //private Wave currentWave;
        public readonly Vector2[] GameLimits = new Vector2[] { new Vector2(730, 810), new Vector2(-30,-30)  };

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        public Settings LoadJson()
        {
            this.keybinds = new Keybinds();
            Input._Keybinds = keybinds;

            PlayerInterpreter playerInterpreter = JsonSerializer.Deserialize<PlayerInterpreter>(File.ReadAllText("../../../Content/Engine/Player.json"));
            player = new Player(playerInterpreter.player, Content);

            _graphics.PreferredBackBufferWidth = 700;// GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = 800;// GraphicsDevice.DisplayMode.Height;
            _graphics.ApplyChanges();

            return settings;
        }

        protected override void LoadContent()
        {
            this.settings = LoadJson();
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            enemies = new List<Entity>();
            projectiles = new List<Projectile>();
            powerUps = new List<PowerUp>();

            enemyManager = new EnemyManager(Content, enemies);
            projectileManager = new ProjectileManager(projectiles, enemies, player, Content);
            powerUpManager = new PowerUpManager(player, powerUps, Content);

            font = Content.Load<SpriteFont>("Time");
            menu = new MainMenu(Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (menuOpen)
            {
                if (menu.Update(gameTime))
                {
                    menuOpen = false;
                    Restart(gameTime);
                }
                base.Update(gameTime);
            }

            double time = gameTime.TotalGameTime.TotalSeconds - lastReset;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Updates player
            player.Update(time - previousUpdate);

            enemyManager.Update(time);
            projectileManager.Update(time);
            powerUpManager.Update(time);

            CollisionCheck(gameTime);
            Deleter();
            this.previousUpdate = time;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {


            // TODO: Add your drawing code here.

            _spriteBatch.Begin();
            if (menuOpen)
            {
                GraphicsDevice.Clear(Color.Black);
                menu.Draw(_spriteBatch);
                _spriteBatch.End();
                base.Draw(gameTime);
                return;
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Draw(player.Texture, player.Position, player.Invulnerable ? Color.Red : Color.White); // Draws the player.
            _spriteBatch.Draw(player.HealthTexture, player.HealthRectangle, Color.White); // Draws the health bar.
            _spriteBatch.Draw(player.HealthTexture, player.InnerHealthRectangle, Color.Red); 
            // Draws all enemies in enemy list.
            for (int i = 0; i < enemies.Count; i++)
            {
                _spriteBatch.Draw(enemies[i].Texture, enemies[i].Position, Color.White);
            }

            // Draws all projectiles in projectile list.
            for (int i = 0; i < projectiles.Count; i++)
            {
                _spriteBatch.Draw(projectiles[i].Texture, projectiles[i].Position, Color.White);
            }

            for (int i = 0; i < powerUps.Count; i++)
                _spriteBatch.Draw(powerUps[i].Texture, powerUps[i].Position, Color.White);

            _spriteBatch.DrawString(font, "time: " + Math.Round((gameTime.TotalGameTime.TotalSeconds-lastReset),2) + " | " + projectiles.Count + " | " + spawn, new Vector2(350, 10), Color.Black);
            _spriteBatch.DrawString(font, "lives: " + (player.Lives + 1), new Vector2(350, 25), Color.Black);


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        //Checks if projectiles hit enemies or player.
        private void CollisionCheck(GameTime gameTime)
        {

            for (int i = 0; i < this.projectiles.Count; i++)
            {
                if(projectiles[i].Team!=ProjectileTeam.PLAYER)
                {

                    bool playerCollisionX = player.Position.X + player.Size.X >= projectiles[i].Position.X && projectiles[i].Position.X + projectiles[i].Size.X >= player.Position.X;
                    bool playerCollisionY = player.Position.Y + player.Size.Y >= projectiles[i].Position.Y && projectiles[i].Position.Y + projectiles[i].Size.Y >= player.Position.Y;
                    if (playerCollisionX && playerCollisionY)
                    {
                        player.DealDamage(projectiles [i].Damage);

                        if (player.IsDead())
                        {
                            player.Die();
                            projectiles.Clear();
                            if (player.IsGameOver())
                            {
                                menuOpen = true;
                                
                            }
                            break;
                        }
                            
                        projectiles.RemoveAt(i);
                    }
                    
                }
                else
                {
                    for (int j = 0 ; j < enemies.Count ; j++)
                    {

                        bool collisionX = enemies[j].Position.X + enemies[j].Size.X >= projectiles[i].Position.X && projectiles[i].Position.X + projectiles[i].Size.X >= enemies[j].Position.X;
                        bool collisionY = enemies[j].Position.Y + enemies[j].Size.Y >= projectiles[i].Position.Y && projectiles[i].Position.Y + projectiles[i].Size.Y >= enemies[j].Position.Y;
                        
                        if (collisionX && collisionY)
                        {
                            
                            enemies [j].DealDamage(projectiles [i].Damage);
                            if (enemies [j].IsDead())
                            {
                                enemies.RemoveAt(j);
                            }

                            projectiles.RemoveAt(i);
                        }
                        
                    }
                }

            }
        }

        private void Deleter()
        {
            for (int i = 0;i < this.projectiles.Count; i++)
            {
                if (this.projectiles[i].Position.X > GameLimits[0].X || this.projectiles[i].Position.X < GameLimits[1].X || this.projectiles[i].Position.Y > GameLimits[0].Y || this.projectiles[i].Position.Y < GameLimits[1].Y)
                {
                    this.projectiles.RemoveAt(i);
                }
            }
            for (int i = 0; i < this.enemies.Count; i++)
            {
                if (this.enemies[i].Deleter())
                    this.enemies.RemoveAt(i);
            }
        }
        private void Restart(GameTime gameTime)
        {
            player.Reset();
            enemyManager.Reset();
            projectileManager.Reset();
            powerUpManager.Reset();

            lastReset = gameTime.TotalGameTime.TotalSeconds;
            previousUpdate = 0;
            Random rnd = new Random();
        }
    }
}
