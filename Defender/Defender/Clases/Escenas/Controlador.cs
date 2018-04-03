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
    public class Controlador
    {
        private static Controlador control;
        public static Controlador Control
        {
            get
            {
                if (control == null)
                    control = new Controlador();
                return control;
            }
        }

        public Vector2 Dimensiones { private set; get; }
        public ContentManager Content { private set; get; }

        public Controlador(int altoPantalla, int anchoPantalla)
        {
            Dimensiones = new Vector2(altoPantalla, anchoPantalla);
        }

        public Controlador()
        {
            Dimensiones = new Vector2(640, 480);
        }

        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
