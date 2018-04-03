using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defender.Clases.Personajes
{
    class Enemigo
    {
        public Vector2 posicion { set; get; }               //Posición en el eje de las Y
        public int width { set; get; }                    //Ancho del frame
        public int height { set; get; }                  //Alto del frame
        public int xDead { set; get; }                    //Punto en el eje de las X en el que se considera que el enemigo ha muerto por haber llegado a su destino (Ha realizado ataque al jugador)
        public int vida { set; get; }                   //Cantidad de vida del enemigo
        public int ataque { set; get; }                   //Cantidad de ataque del enemigo
        public int recompensa { set; get; }               //Cantidad de monedas que otorga el enemigo al morirse debido a que su vida llegó a 0
        public int puntuacion { set; get; }               //Cantidad de puntos que otorga el enemigo al morirse debido a que su vida llegó a 0
        public int numFrame { set; get; }                   //Indice del array de frames del enemigo que se esta dibujando
        //private long tiempoDibujo;              //Variable auxiliar que ayuda a gestionar la velocidad de actualización de FPS
        //protected int tickFrame;                //Variable auxiliar que ayuda a gestionar la velocidad de actualización de FPS
        public int altoPantalla { set; get; }               //Alto de la pantalla
        public int anchoPantalla { set; get; }              //Ancho de la pantalla
        public Vector2 velocidad { set; get; }              //Velocidad de movimiento
        private Rectangle rectangulo;         //Rectángulo de colisión
        //private Paint pRect;                    //Paint para dibujar el rectángulo de colisión
        public Texture2D[] frames { set; get; }           //Array de frames de la secuencia de movimiento
        //private Context context;                //Contexto de la aplicación
        private bool muerto;                 //Indica si el enemigo está muerto o no
        //private SensorManager sensorManager;    //Gestor de sensores del móvil
        //private Sensor orientacion;             //Sensor que gestiona la orientacion en el espacio del móvil (ejes x-y-z)
        //private boolean haciaAtras;             //Indica si los enemigos deben ir hacia atrás debido a los valores del sensor de orientación

        public Enemigo(GraphicsDevice gd, int altoPantalla, int anchoPantalla, int ataque, int vida, int recompensa, int puntuacion, Vector2 velocidad, int xDead)
        {
            this.altoPantalla = altoPantalla;
            this.anchoPantalla = anchoPantalla;
            this.ataque = ataque;
            this.vida = vida;
            this.recompensa = recompensa;
            this.puntuacion = puntuacion;
            this.velocidad = velocidad;
            this.xDead = xDead;
            this.frames = frames;

            width = frames[0].Width;
            height = frames[0].Height;

            posicion = new Vector2(anchoPantalla, new Random().Next(0, altoPantalla - frames[0].Height));
            rectangulo.Height = frames[0].Height;
            rectangulo.Width = frames[0].Width;
            rectangulo.Location = new Point((int)posicion.X, (int)posicion.Y);

            numFrame = 0;
            muerto = false;
        }

        /// <summary>
        /// Carga las texturas y otros elementos necesarios para la clase
        /// </summary>
        /// <param name="content"></param>
        public void Load(ContentManager content)
        {
            frames[0] = content.Load<Texture2D>("alien0.png");
            frames[1] = content.Load<Texture2D>("alien1.png");
        }

        /// <summary>
        /// Gestiona el movimiento de la clase
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Actualizar(float elapsedTime)
        {
            if (posicion.X < xDead)
            {
                //muerto = true;
                posicion = new Vector2(anchoPantalla, new Random().Next(0, altoPantalla - frames[0].Height));
            }
            else
            {
                posicion += velocidad * elapsedTime;
                numFrame++;
                if (numFrame >= frames.Length)
                    numFrame = 0;
            }

            rectangulo.Location = new Point((int)posicion.X, (int)posicion.Y);
        }

        /// <summary>
        /// Se encarga de dibujar los sprites de la clase
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Dibujar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(frames[numFrame], posicion, null);
        }
    }
}
