using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 


    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D smiley;
        Vector2 smileyPosition = Vector2.Zero;
        Vector2 smileySpeed = new Vector2(80.0f, 80.0f);
        Rectangle smileyRec;

        Texture2D gsmiley;
        Vector2 gsmileyPosition = Vector2.Zero;
        Vector2 gsmileySpeed = new Vector2(50.0f,50.0f);
        Rectangle gsmileyRec;

        Texture2D psmiley;
        Vector2 psmileyPosition = Vector2.Zero;
        Vector2 psmileySpeed = new Vector2(100.0f, 100.0f);
        Rectangle psmileyRec;

        Texture2D cloud;
        Rectangle cloudRec;

        Texture2D thunder;
        Rectangle thunderRec;
        
        Random rdn = new Random();
        //int smileyIndex = 0;

        MouseState mouseNow = Mouse.GetState();
        MouseState mouseLater;

        bool drawsmiley = true;
        bool drawgsmiley = false;
        bool drawpsmiley = true;

        int score = 0;
       // double spawntime = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
          
            base.Initialize();
            // Set this to true to make the mouse cursor visible.
            // Use the default (false) if you are drawing your own
            // cursor or don't want a cursor.

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            thunder = Content.Load<Texture2D>("thunder");
            smiley = Content.Load<Texture2D>("yellowballoon");
            gsmiley = Content.Load<Texture2D>("greenballoon");
            psmiley = Content.Load<Texture2D>("pinkballoon");
            cloud = Content.Load<Texture2D>("cloud");
            thunderRec = new Rectangle(0, 0, thunder.Width, thunder.Height);
            smileyRec = new Rectangle(100, 100, smiley.Width, smiley.Height);
            gsmileyRec = new Rectangle(300, 300, gsmiley.Width, gsmiley.Height);
            psmileyRec = new Rectangle(470, 470, psmiley.Width, psmiley.Height);
            cloudRec = new Rectangle(250, 250, cloud.Width, cloud.Height);
            
           

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            int MaxX = graphics.GraphicsDevice.Viewport.Width - smiley.Width;
            int MinX = 0;
            int MaxY = graphics.GraphicsDevice.Viewport.Height - smiley.Height;
            int MinY = 0;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
           // spawntime += gameTime.ElapsedGameTime.TotalSeconds;
           
            thunderRec.X = Mouse.GetState().X;
            thunderRec.Y = Mouse.GetState().Y;

           
            smileyPosition += smileySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            gsmileyPosition += gsmileySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            psmileyPosition += psmileySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            smileyRec.X = (int)smileyPosition.X;
            smileyRec.Y = (int)smileyPosition.Y;
            gsmileyRec.X = (int)gsmileyPosition.X;
            gsmileyRec.Y = (int)gsmileyPosition.Y;
            psmileyRec.X = (int)psmileyPosition.X;
            psmileyRec.Y = (int)psmileyPosition.Y;

            
         /*   if (spawntime >= 1)
            {
                smileyIndex = rdn.Next(0, 1);
                spawntime = 0;

            }*/
               // Check for bounce.
           
                if (smileyRec.X > MaxX)
                {
                    smileySpeed.X *= -1;
                    smileyRec.X = MaxX;
                }

                else if (smileyRec.X < MinX)
                {
                    smileySpeed.X *= -1;
                    smileyRec.X = MinX;
                }

                if (smileyRec.Y > MaxY)
                {
                    smileySpeed.Y *= -1;
                    smileyRec.Y = MaxY;
                }

                else if (smileyRec.Y < MinY)
                {
                    smileySpeed.Y *= -1;
                    smileyRec.Y = MinY;
                }
            
                //*******************

            
                if (gsmileyRec.X > MaxX)
                {
                    gsmileySpeed.X *= -1;
                    gsmileyRec.X = MaxX +5;
                }

                else if (gsmileyRec.X < MinX)
                {
                    gsmileySpeed.X *= -1;
                    gsmileyRec.X = MinX -1;
                }

                if (gsmileyRec.Y > MaxY)
                {
                    gsmileySpeed.Y *= -1;
                    gsmileyRec.Y = MaxY +1;
                }

                else if (gsmileyRec.Y < MinY)
                {
                    gsmileySpeed.Y *= -2;
                    gsmileyRec.Y = MinY -1;
                }
            
            //*********************

                if (psmileyRec.X > MaxX)
                {
                    psmileySpeed.X *= -1;
                    psmileyRec.X = MaxX;
                }

                else if (psmileyRec.X < MinX)
                {
                    psmileySpeed.X *= -1;
                    psmileyRec.X = MinX;
                }

                if (psmileyRec.Y > MaxY)
                {
                    psmileySpeed.Y *= -1;
                    psmileyRec.Y = MaxY;
                }

                else if (psmileyRec.Y < MinY)
                {
                    psmileySpeed.Y *= -1;
                    psmileyRec.Y = MinY;
                }
            
             
             // TODO: Add your update logic here
            // Move the sprite by speed, scaled by elapsed time.

            // Check for bounce.
                
                mouseLater = mouseNow;
                mouseNow = Mouse.GetState();
            if (thunderRec.Intersects(smileyRec) && mouseNow.LeftButton == ButtonState.Pressed && mouseLater.LeftButton==ButtonState.Released )
            {
                score += 1;
                drawsmiley = false;  
            }
            if (thunderRec.Intersects(gsmileyRec) && mouseNow.LeftButton == ButtonState.Pressed && mouseLater.LeftButton == ButtonState.Released)
            {
                score += 2;
                drawgsmiley = false;
            }
            if (thunderRec.Intersects(psmileyRec) && mouseNow.LeftButton == ButtonState.Pressed && mouseLater.LeftButton == ButtonState.Released)
            {
                score -= 3;
                drawpsmiley = false;
            }
            if (score>0 && drawsmiley==false)
            {
                smileyPosition.X = rdn.Next(0, 1000);
                smileyPosition.Y = rdn.Next(0,1000);
                drawsmiley = true;
            }
            if (score > 0 && drawgsmiley == false)
            {
                gsmileyPosition.X = rdn.Next(0, 1000);
                gsmileyPosition.Y = rdn.Next(0, 1000);
                drawgsmiley = true;
            }
            if (score > 0 && drawpsmiley == false)
            {
                psmileyPosition.X = rdn.Next(0, 1000);
                psmileyPosition.Y = rdn.Next(0, 1000);
                drawpsmiley = true;
            }
            if (score >= 50)
            {
                //DialogResult dialog = 
                Exit();
            }
             
            this.Window.Title = score.ToString();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(thunder, thunderRec, Color.White);
            spriteBatch.Draw(smiley, smileyRec, Color.White);
            spriteBatch.Draw(gsmiley, gsmileyRec, Color.White);
            spriteBatch.Draw(psmiley, psmileyRec, Color.White);
            //spriteBatch.Draw(cloud, cloudRec, Color.WhiteSmoke);
            spriteBatch.End();

            base.Draw(gameTime);
        }

   
    }


}
