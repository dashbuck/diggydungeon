using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace DiggyDungeonProject
{
    public class Game1 : Game
    {
        SpriteFont fontRubik;
        SpriteFont fontDidthis;

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
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fontRubik = Content.Load<SpriteFont>("RubikDoodleShadow");
            // TODO: use this.Content to load your game content here
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

            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            _spriteBatch.Begin();

            //== Title ==

            string titleText = "Diggy Dungeon";
            Vector2 titleTextMeas = fontRubik.MeasureString(titleText);
            Vector2 titleTextMidPoint = titleTextMeas / 2;
            _spriteBatch.DrawString(
                fontRubik, //SpriteFont spriteFont
                titleText, //StringBuilder text
                new Vector2(posCenterX, titleTextMidPoint.Y / 2), //Vector2 position - at top but not outside frame
                Color.Black, //Color color
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
                Color.Black, //Color color
                0, //float rotation
                titleTextMidPoint, //Vector2 origin
                1.15f, //Vector2 scale 
                SpriteEffects.None, //SpriteEffects effects
                0 //float layerDepth
                );


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
