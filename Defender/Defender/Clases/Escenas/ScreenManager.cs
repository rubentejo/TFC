using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defender.Clases.Escenas
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public Vector2 Dimensiones { private set; get; }
        public ContentManager Content { private set; get; }
        public SpriteFont Fuente { private set; get; }
        public bool Cambiando { private set; get; }
        Escena escenaActual, escenaSiguiente;

        public ScreenManager()
        {
            Dimensiones = new Vector2(640, 480);
            escenaActual = new Titulo();
        }

        public void ChangeScreens(string nombreEscena)
        {
            escenaSiguiente = (Escena)Activator.CreateInstance(Type.GetType("Defender.Clases.Escenas." + nombreEscena));
            Cambiando = true;
        }

        void Transition()
        {
            if (Cambiando)
            {
                escenaActual.UnloadContent();
                escenaActual = escenaSiguiente;
                escenaActual.LoadContent();
                Cambiando = false;
            }
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            Fuente = Content.Load<SpriteFont>("Fuentes/Default");
            escenaActual.LoadContent();
        }

        public void UnloadContent()
        {
            escenaActual.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            escenaActual.Update(gameTime);
            Transition();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            escenaActual.Draw(spriteBatch);
        }

        //public static GraphicsDeviceManager GraphicsDeviceMgr;
        //public static SpriteBatch Sprites;
        //public static Dictionary<string, Texture2D> Textures2D;
        //public static Dictionary<string, SpriteFont> Fonts;
        //public static List<Escena> Escenas;
        //public static ContentManager ContentMgr;

        //public static void Main()
        //{
        //    using (ScreenManager manager = new ScreenManager())
        //    {
        //        manager.Run();
        //    }
        //}

        //public ScreenManager()
        //{
        //    GraphicsDeviceMgr = new GraphicsDeviceManager(this);

        //    GraphicsDeviceMgr.PreferredBackBufferWidth = 800;
        //    GraphicsDeviceMgr.PreferredBackBufferHeight = 600;

        //    GraphicsDeviceMgr.IsFullScreen = false;

        //    Content.RootDirectory = "Content";
        //}

        //protected override void Initialize()
        //{
        //    Textures2D = new Dictionary<string, Texture2D>();
        //    Fonts = new Dictionary<string, SpriteFont>();
        //    IsMouseVisible = true;
        //    base.Initialize();
        //}

        //protected override void LoadContent()
        //{
        //    ContentMgr = Content;
        //    Sprites = new SpriteBatch(GraphicsDevice);

        //    Load any full game assets here

        //    AddScreen(new Titulo());
        //}

        //protected override void UnloadContent()
        //{
        //    foreach (var escena in Escenas)
        //    {
        //        escena.UnloadAssets();
        //    }
        //    Textures2D.Clear();
        //    Fonts.Clear();
        //    Escenas.Clear();
        //    Content.Unload();
        //}

        //protected override void Update(GameTime gameTime)
        //{
        //    try
        //    {
        //        TODO Remove temp code
        //        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        //        {
        //            Exit();

        //            var startIndex = Escenas.Count - 1;
        //            while (Escenas[startIndex].IsPopup && Escenas[startIndex].IsActive)
        //            {
        //                startIndex--;
        //            }
        //            for (var i = startIndex; i < Escenas.Count; i++)
        //            {
        //                Escenas[i].Update(gameTime);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.AddError(ex);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        base.Update(gameTime);
        //    }
        //}

        //protected override void Draw(GameTime gameTime)
        //{
        //    var startIndex = Escenas.Count - 1;
        //    while (Escenas[startIndex].IsPopup)
        //    {
        //        startIndex--;
        //    }

        //    GraphicsDevice.Clear(Escenas[startIndex].BackgroundColor);
        //    GraphicsDeviceMgr.GraphicsDevice.Clear(Escenas[startIndex].BackgroundColor);

        //    for (var i = startIndex; i < Escenas.Count; i++)
        //    {
        //        Escenas[i].Draw(gameTime);
        //    }

        //    base.Draw(gameTime);
        //}

        //public static void AddFont(string fontName)
        //{
        //    if (Fonts == null)
        //    {
        //        Fonts = new Dictionary<string, SpriteFont>();
        //    }
        //    if (!Fonts.ContainsKey(fontName))
        //    {
        //        Fonts.Add(fontName, ContentMgr.Load<SpriteFont>(fontName));
        //    }
        //}

        //public static void RemoveFont(string fontName)
        //{
        //    if (Fonts.ContainsKey(fontName))
        //    {
        //        Fonts.Remove(fontName);
        //    }
        //}

        //public static void AddTexture2D(string textureName)
        //{
        //    if (Textures2D == null)
        //    {
        //        Textures2D = new Dictionary<string, Texture2D>();
        //    }
        //    if (!Textures2D.ContainsKey(textureName))
        //    {
        //        Textures2D.Add(textureName, ContentMgr.Load<Texture2D>(textureName));
        //    }
        //}

        //public static void RemoveTexture2D(string textureName)
        //{
        //    if (Textures2D.ContainsKey(textureName))
        //    {
        //        Textures2D.Remove(textureName);
        //    }
        //}

        //public static void AddScreen(Escena gameScreen)
        //{
        //    if (Escenas == null)
        //    {
        //        Escenas = new List<Escena>();
        //    }
        //    Escenas.Add(gameScreen);
        //    gameScreen.LoadAssets();
        //}

        //public static void RemoveScreen(Escena gameScreen)
        //{
        //    gameScreen.UnloadAssets();
        //    Escenas.Remove(gameScreen);
        //    if (Escenas.Count < 1)
        //        AddScreen(new Titulo());
        //}

        //public static void ChangeScreens(Escena currentScreen, Escena targetScreen)
        //{
        //    RemoveScreen(currentScreen);
        //    AddScreen(targetScreen);
        //}

    }
}
