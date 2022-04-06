using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using Bullet_Hell_Shooting_Game.Enemies;
using Bullet_Hell_Shooting_Game.Projectiles;
using Bullet_Hell_Shooting_Game.Bosses;
using Bullet_Hell_Shooting_Game.Patterns;
using Bullet_Hell_Shooting_Game.Movements;


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
        private double previousEnemySpawn = 0;
        private double lastReset = 0;

        private List<Entity> enemies;
        private List<Projectile> projectiles;

        private EnemyFactory enemyFactory;
        private ProjectileFactory projectileFactory;
        private PatternFactory patternFactory;

        private BossFactory bossFactory;
        private List<Boss> bosses;

        private float spawn = 0;
        private bool menuOpen = false;
        private ContinueMenu menu;
        public EnemyManager enemyManager;


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
            string fileName = "../../../Content/Settings.json";
            string data = File.ReadAllText(fileName);

            this.settings = JsonSerializer.Deserialize<Settings>(data);

            this.keybinds = new Keybinds(settings.keybinds);
            Input._Keybinds = keybinds;
            player = new Player(this.settings.player, Content);

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
            previousEnemySpawn = 0;
            enemyFactory = new EnemyFactory(Content);
            projectileFactory = new ProjectileFactory(Content);
            patternFactory = new PatternFactory(Content);
            bosses = new List<Boss>();
            bossFactory = new BossFactory(Content);
            //currentWave = new Wave("", 0, 0);
            enemyManager = new EnemyManager(settings, Content);

            font = Content.Load<SpriteFont>("Time");
            menu = new ContinueMenu(Content);
            // TODO: use this.Content to load your game content here

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

            // TODO: Add your update logic here

            // Moves all current projectiles at their speed.
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Move(time - previousUpdate);
            }

            //Update Bosses
            for (int i = 0; i < bosses.Count; i++)
            {
                bosses[i].Move();
            }

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Update(time - previousUpdate);

            // Updates player
            player.Update(time - previousUpdate);
            if (player.ShootCheck(time))
                //projectiles.Add(projectileFactory.Create(player.ProjectileType, player.Position));
                projectiles.AddRange(patternFactory.Create(player.PatternType, player.ProjectileType, player.Position));

            if (enemyManager.getInterval(time) == true && enemyManager.LastWave() == true)
            {
                enemies.Add(enemyManager.Update(gameTime));
            }


            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].ShootCheck(time))
                {
                    //projectiles.Add(projectileFactory.Create(enemies[i].ProjectileType, enemies[i].Position));
                    if(enemies[i].PatternType == PatternType.TRI && enemies[i].StepCount > 12 && enemies[i].StepCount <= 27)
                    {
                        projectiles.AddRange(patternFactory.Create(PatternType.SCATTER, enemies[i].ProjectileType, enemies[i].Position));
                    }
                    else if(enemies[i].StepCount > 27 && enemies[i].StepCount <= 39)
                    {
                        projectiles.AddRange(patternFactory.Create(PatternType.SUNBURST, enemies[i].ProjectileType, enemies[i].Position));
                    }
                    else if(enemies[i].StepCount > 39 && enemies[i].StepCount <= 55)
                    {
                        projectiles.AddRange(patternFactory.Create(PatternType.BOWTIE, enemies[i].ProjectileType, enemies[i].Position));
                    }
                    else
                    {
                        projectiles.AddRange(patternFactory.Create(enemies[i].PatternType, enemies[i].ProjectileType, enemies[i].Position));
                    }
                    
                }
            }


            CollisionCheck(gameTime);
            Deleter();
            this.previousUpdate = time;

            base.Update(gameTime);
        }

        /// <summary>
        /// function to load the wave containing GrunB types
        /// </summary>
        /// <param name="gameTime"></param>
        public void LoadWave2(GameTime gameTime)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Projectile enemyShot = null;// enemies[i].Update(gameTime.TotalGameTime.TotalSeconds);
                if (enemyShot != null)
                    projectiles.Add(enemyShot);
            }


            if (gameTime.TotalGameTime.TotalSeconds-lastReset > this.previousEnemySpawn + 1)
            {
                enemies.Add(enemyFactory.SpawnEnemy("GruntB", settings.Enemies));
                this.previousEnemySpawn = gameTime.TotalGameTime.TotalSeconds-lastReset;
            }

            //count += 1;

        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here.

            _spriteBatch.Begin();
            if (menuOpen)
            {
                menu.Draw(_spriteBatch);
                _spriteBatch.End();
                base.Draw(gameTime);
                return;
            }
            _spriteBatch.Draw(player.Texture, player.Position, player.Invulnerable ? Color.Red : Color.White); // Draws the player.
            _spriteBatch.Draw(player.HealthTexture, player.HealthRectangle, Color.White); // Draws the player.
            _spriteBatch.Draw(player.HealthTexture, player.InnerHealthRectangle, Color.Red); // Draws the player.
            // Draws all enemies in enemy list.
            for (int i = 0; i < enemies.Count; i++)
            {
                _spriteBatch.Draw(enemies[i].Texture, enemies[i].Position, Color.White);
            }

            // Draws Bosses
            for (int i = 0; i < bosses.Count; i++)
            {
                _spriteBatch.Draw(bosses[i].Texture, bosses[i].Position, Color.White);
            }

            // Draws all projectiles in projectile list.
            for (int i = 0; i < projectiles.Count; i++)
            {
                _spriteBatch.Draw(projectiles[i].Texture, projectiles[i].Position, Color.White);
            }

            _spriteBatch.DrawString(font, "time: " + Math.Round((gameTime.TotalGameTime.TotalSeconds-lastReset),2) + " | " + projectiles.Count + " | " + spawn, new Vector2(350, 10), Color.Black);
            _spriteBatch.DrawString(font, "lives: " + player.Lives, new Vector2(350, 25), Color.Black);


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
                                enemies[j].Die();
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
            enemies.Clear();
            projectiles.Clear();
            previousEnemySpawn = 0;
            enemyManager.Reset();
            player.Reset();
            lastReset = gameTime.TotalGameTime.TotalSeconds;
            previousUpdate = 0;
        }
    }
}
