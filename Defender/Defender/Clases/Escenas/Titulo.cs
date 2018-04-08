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
    public class Titulo : Escena
    {
        string titulo;

        public override void LoadContent()
        {
            base.LoadContent();
            titulo = "DEFENDER";
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
                ScreenManager.Instance.ChangeScreens("Menu");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(imagen, new Vector2(ScreenManager.Instance.Dimensiones.X/2 - imagen.Width/2, ScreenManager.Instance.Dimensiones.Y / 2 - imagen.Height/2), Color.White);
            Vector2 textSize = ScreenManager.Instance.Fuente.MeasureString(titulo);
            spriteBatch.DrawString(ScreenManager.Instance.Fuente, titulo, new Vector2(ScreenManager.Instance.Dimensiones.X / 2 - textSize.X / 2, ScreenManager.Instance.Dimensiones.Y / 2 - textSize.Y / 2), Color.Black);
        }

        //private readonly Matrix _projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);
        //private readonly Matrix _view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        //private readonly Matrix _world = Matrix.CreateTranslation(0, 0, 0);
        //private BasicEffect _basicEffect;
        //private VertexBuffer _vertexBuffer;

        //public override void LoadAssets()
        //{
        //    _basicEffect = new BasicEffect(ScreenManager.GraphicsDeviceMgr.GraphicsDevice);

        //    var vertices = new VertexPositionColor[3];

        //    vertices[0] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Red);
        //    vertices[1] = new VertexPositionColor(new Vector3(+0.5f, 0, 0), Color.Green);
        //    vertices[2] = new VertexPositionColor(new Vector3(-0.5f, 0, 0), Color.Blue);

        //    _vertexBuffer = new VertexBuffer(ScreenManager.GraphicsDeviceMgr.GraphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
        //    _vertexBuffer.SetData(vertices);
        //}

        //public override void Draw(GameTime gameTime)
        //{
        //    _basicEffect.World = _world;
        //    _basicEffect.View = _view;
        //    _basicEffect.Projection = _projection;
        //    _basicEffect.VertexColorEnabled = true;

        //    ScreenManager.GraphicsDeviceMgr.GraphicsDevice.SetVertexBuffer(_vertexBuffer);

        //    var rasterizerState = new RasterizerState { CullMode = CullMode.None };
        //    ScreenManager.GraphicsDeviceMgr.GraphicsDevice.RasterizerState = rasterizerState;

        //    foreach (var pass in _basicEffect.CurrentTechnique.Passes)
        //    {
        //        pass.Apply();
        //        ScreenManager.GraphicsDeviceMgr.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
        //    }
        //}

    }
}
