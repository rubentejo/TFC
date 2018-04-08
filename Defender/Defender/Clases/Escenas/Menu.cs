using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defender.Clases.Escenas
{
    public class Menu : Escena
    {
        string titulo;

        public override void LoadContent()
        {
            base.LoadContent();
            titulo = "MENU";
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !ScreenManager.Instance.Cambiando)
            {
                ScreenManager.Instance.ChangeScreens("Titulo");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(imagen, new Vector2(ScreenManager.Instance.Dimensiones.X/2 - imagen.Width/2, ScreenManager.Instance.Dimensiones.Y / 2 - imagen.Height/2), Color.White);
            Vector2 textSize = ScreenManager.Instance.Fuente.MeasureString(titulo);
            spriteBatch.DrawString(ScreenManager.Instance.Fuente, titulo, new Vector2(ScreenManager.Instance.Dimensiones.X / 2 - textSize.X / 2, ScreenManager.Instance.Dimensiones.Y / 2 - textSize.Y / 2), Color.Black);
        }
    }
}
