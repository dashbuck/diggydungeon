using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace DiggyDungeonProject
{
    public class Game1 : Game
    {
        Color colorCave;
        
        SpriteFont fontRubik;
        SpriteFont fontThis;

        Texture2D cursorShovelWhite;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Set window size
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set up colors
            colorCave = new Color(33, 2, 3, 1);

            // Set up fonts
            fontRubik = Content.Load<SpriteFont>("fontRubik");
            fontThis = Content.Load<SpriteFont>("fontThis");

            // Set up cursor
            cursorShovelWhite = Content.Load<Texture2D>("img/cursors/cursorShovelWhite");
            Mouse.SetCursor(MouseCursor.FromTexture2D(cursorShovelWhite, 0, 0));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            int windowWidth = _graphics.PreferredBackBufferWidth;
            int windowHeight = _graphics.PreferredBackBufferHeight;

            int posTopY = 2; //not 0 because we need a lil buffer
            int posCenterX = windowWidth / 2; //I'd use a float for accuracy but I think V2s only accept ints
            int posCenterY = windowHeight / 2;

            GraphicsDevice.Clear(colorCave);

            
            _spriteBatch.Begin();

            //== Title ==

            string titleText = "Diggy Dungeon";
            Vector2 titleTextMeas = fontRubik.MeasureString(titleText);
            Vector2 titleTextMidPoint = titleTextMeas / 2;
            _spriteBatch.DrawString(
                fontRubik, //SpriteFont spriteFont
                titleText, //StringBuilder text
                new Vector2(posCenterX, titleTextMidPoint.Y / 2), //Vector2 position - at top but not outside frame
                Color.White, //Color color
                0, //float rotation
                titleTextMidPoint, //Vector2 origin
                0.6f, //Vector2 scale
                SpriteEffects.None, //SpriteEffects effects
                0 //float layerDepth
                );

            //== Subtitle ==

            string titleTextSub = "Concentration";
            Vector2 titleTextSubMeas = fontRubik.MeasureString(titleTextSub);
            Vector2 titleTextSubMidPoint = titleTextSubMeas / 2;
            _spriteBatch.DrawString(
                fontRubik, //SpriteFont spriteFont
                titleTextSub, //StringBuilder text
                new Vector2(posCenterX, posTopY + titleTextMeas.Y ), //Vector2 position - below the title text.
                Color.White, //Color color
                0, //float rotation
                titleTextMidPoint, //Vector2 origin
                1.15f, //Vector2 scale 
                SpriteEffects.None, //SpriteEffects effects
                0 //float layerDepth
                );

            //== Start Button ==




            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
