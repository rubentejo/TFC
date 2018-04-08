using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defender.Clases.Escenas
{
    public class Escena
    {
        protected ContentManager content;

        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        //public bool IsActive = true;
        //public bool IsPopup = false;
        //public Color BackgroundColor = Color.CornflowerBlue;

        //public virtual void LoadAssets() { }

        //public virtual void Update(GameTime gameTime) { }

        //public virtual void Draw(GameTime gameTime) { }

        //public virtual void UnloadAssets() { }
    }
}
