using aplimat_labs.Models;
using aplimat_labs.Utilities;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplimat_labs
{
    public partial class MainWindow : Window
    {

        private const float LINE_SMOOTHNESS = 0.02f;
        private const float GRAPH_LIMIT = 15;
        private const int TOTAL_CIRCLE_ANGLE = 360;

      //   private Vector3 a = new Vector3(15, 15, 0);
       //  private Vector3 b = new Vector3(-2, 10, 0);//0 x,y,z;

        private Vector3 velocity = new Vector3(1, 0, 0);
        private Vector3 mousePos = new Vector3(0, 0, 0);

        private const int Heads = 0;
        private const int Tails = 7;
       // private float pointX = 1;
       // private float pointY = 1;
       // private float speed  = 5.0f;
        private Randomizer rng = new Randomizer(-20, 20);
        public Randomizer rngColor = new Randomizer(0, 1);
        private List<CubeMesh> myCubes = new List<CubeMesh>();
        private CubeMesh myCube = new CubeMesh(-25, 0, 0);
        private Vector3 acceleration = new Vector3(0.1f, 0, 0);
        private Vector3 myVector = new Vector3();
        private Vector3 a = new Vector3(0, 0, 0);
        private Vector3 b = new Vector3(5, 7, 0);

        public bool isHit = false;
        public bool isAcce = true;
        public bool isDecce = false;
        public bool isHere = false;


        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            //myVector = a - b;
            // Vector3 c = a + b;
            Console.WriteLine(myVector.GetMagnitude());
        }

        private CubeMesh lightCube = new CubeMesh()
        {
          //  Accelereration = new Vector3(0.01, 0, 0),
            Position = new Vector3(-10, 10, 0)
        };

        private CubeMesh mediumCube = new CubeMesh()
        {
            //  Accelereration = new Vector3(0.01, 0, 0),
            Position = new Vector3(10, 0, 0),
            Mass = 3
        };

        private CubeMesh heavyCube = new CubeMesh()
        {
            //  Accelereration = new Vector3(0.01, 0, 0),
            Position = new Vector3(0, 10, 0),
            Mass = 5
        };

        private Vector3 wind = new Vector3(0.01f, 0, 0);
        private Vector3 gravity = new Vector3(0,-0.1, 0);
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            
            gl.Translate(0.0f, 0.0f, -40.0f);
            //myVector = a - b;
            // myCube.Draw(gl);

            //Light Cube
            gl.Color(1.0f, 0.0f, 0.0f);
            lightCube.Draw(gl);
            lightCube.ApplyForce(wind);
            lightCube.ApplyForce(gravity);

            //Medium Cube
            gl.Color(0.0f, 1.0f, 0.0f);
            mediumCube.Draw(gl);
            mediumCube.ApplyForce(wind);
            mediumCube.ApplyForce(gravity);


            //Heavy Cube
            gl.Color(0.0f, 0.0f, 1.0f);
            heavyCube.Draw(gl);
            heavyCube.ApplyForce(wind);
            heavyCube.ApplyForce(gravity);



            //Right Border
            if (lightCube.Position.x >= 20.0f)
            {
                lightCube.Velocity.x -= 0.25f;
                lightCube.Velocity.x *= .25f;
            }
            //Bottom Border
            if (lightCube.Position.y <= -10.0f)
            {

                lightCube.Velocity.y *= -0.50f;
                lightCube.Velocity.y -= -0.50f;
            }

            if (mediumCube.Position.x >= 20.0f)
            {
                mediumCube.Velocity.x -= 0.25f;
                mediumCube.Velocity.x *= .25f;
            }
            //Bottom Border
            if (mediumCube.Position.y <= -10.0f)
            {

                mediumCube.Velocity.y *= -0.50f;
                mediumCube.Velocity.y -= -0.50f;
            }

            if (heavyCube.Position.x >= 20.0f)
            {
                heavyCube.Velocity.x -= 0.25f;
                heavyCube.Velocity.x *= .25f;
            }
            //Bottom Border
            if (heavyCube.Position.y <= -10.0f)
            {

                heavyCube.Velocity.y *= -0.50f;
                heavyCube.Velocity.y -= -0.50f;
            }

            ////Right Border
            //if (mediumCube.Position.x >= 20.0f)
            //{
            //    mediumCube.Velocity.x -= 0.25f;
            //    mediumCube.Velocity.x *= .25f;
            //}
            ////Bottom Border
            //if (mediumCube.Position.y <= -10.0f)
            //{
            //    mediumCube.Velocity.y *= -0.50f;
            //    mediumCube.Velocity.y -= -0.50f;
            //}

            ////Right Border
            //if (heavyCube.Position.x >= 20.0f)
            //{
            //    heavyCube.Velocity.x -= 0.25f;
            //    heavyCube.Velocity.x *= .25f;
            //}
            ////Bottom Border
            //if (heavyCube.Position.y <= -10.0f)
            //{
            //    heavyCube.Velocity.y *= -0.50f;
            //    heavyCube.Velocity.y -= -0.50f;
            //}

            gl.DrawText(20, 20, 1, 0, 0, "Arial", 25, myCube.Velocity.x + " ");
            #region velocityregion
            /*
            CubeMesh myCube = new CubeMesh();
            myCube.Position = new Vector3(Gaussian.Generate(0, 15), rng.GenerateInt(), 0);
            myCubes.Add(myCube);
            myCube.Draw(gl);
            Seatwork
                myCube.Position += velocity * speed;
            right
                 if (myCube.Position.x >= 20)
            {
                velocity.x = -1;
                velocity.y = 1;
            }
            left
                 if (myCube.Position.x <= -15)
            {
                velocity.x = 1;
                velocity.y = -1;
            }
            up
                 if (myCube.Position.y >= 10)
            {
                velocity.x = 1;
                velocity.y = -1;
            }

            if (myCube.Position.y <= -15)
            {
                velocity.y = -1;
                velocity.y = 1;
            }

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.LineWidth(20);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(b.x, b.y);
            gl.Vertex(a.x, a.y);
            gl.End();

            gl.Color(1.0f, 1.0f, 1.0f);
            gl.LineWidth(3);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(b.x, b.y);
            gl.Vertex(a.x, a.y);
            gl.End();
            */

            #endregion

            //This will make the line into 1 

            #region lightsaber following mouse

            /* gl.Color(1.0f, 0.0f, 0.0f);
             mousePos.Normalize();
             mousePos *= 10;
             gl.LineWidth(20);
             gl.Begin(OpenGL.GL_LINE_STRIP);
             gl.Vertex(0, 0, 0);
             gl.Vertex(mousePos.x, mousePos.y, 0);
             gl.End();

             gl.Color(0.0f, 0.0f, 1.0f);
             gl.LineWidth(3);
             gl.Begin(OpenGL.GL_LINE_STRIP);
             gl.Vertex(0, 0, 0);
             gl.Vertex(mousePos.x, mousePos.y, 0);
             gl.End();

             gl.Color(0.0f, 1.0f, 0.0f);
             gl.LineWidth(20);
             gl.Begin(OpenGL.GL_LINE_STRIP);
             gl.Vertex(-10, 5, 0);
             gl.Vertex(mousePos.x, mousePos.y, 0);
             gl.End();

             gl.Color(0.0f, 1.0f, 1.0f);
             gl.LineWidth(3);
             gl.Begin(OpenGL.GL_LINE_STRIP);
             gl.Vertex(-10, 5, 0);
             gl.Vertex(mousePos.x, mousePos.y, 0);
             gl.End();

             gl.Color(0.0f, 1.0f, 0.0f);
             gl.LineWidth(20);
             gl.Begin(OpenGL.GL_LINE_STRIP);
             gl.Vertex(10, -5, 0);
             gl.Vertex(mousePos.x, mousePos.y, 0);
             gl.End();

             gl.Color(1.0f, 0.0f, 1.0f);
             gl.LineWidth(3);
             gl.Begin(OpenGL.GL_LINE_STRIP);
             gl.Vertex(10, -5, 0);
             gl.Vertex(mousePos.x, mousePos.y, 0);
             gl.End();
             */
            #endregion
        }

        #region MyRegion
        private void DrawCartesianPlane(OpenGL gl)
        {

            //draw y-axis
            gl.Begin(OpenGL.GL_LINE_STRIP);

            gl.Color(1.0f, 0.0f, 1.0f);
            gl.Vertex(0, -GRAPH_LIMIT, 0);
            gl.Vertex(0, GRAPH_LIMIT, 0);
            gl.End();

            //draw x-axis
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(-GRAPH_LIMIT, 0, 0);
            gl.Vertex(GRAPH_LIMIT, 0, 0);
            gl.End();

            //draw unit lines
            for (int i = -15; i <= 15; i++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(-0.2f, i, 0);
                gl.Vertex(0.2f, i, 0);
                gl.End();

                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(i, -0.2f, 0);
                gl.Vertex(i, 0.2f, 0);
                gl.End();
            }
        }

        private void DrawPoint(OpenGL gl, float x, float y)
        {
            gl.PointSize(5.0f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
        }

        private void DrawLinearFunction(OpenGL gl)
        {
            /*
             * f(x) = x + 2;
             * Let x be 4, then y = 6 (4, 6)
             * Let x be -5, then y = -3 (-5, -3)
             * */
            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x+=LINE_SMOOTHNESS)
            {
                gl.Vertex(x, x + 2);
            }
            gl.End();

            DrawText(gl, "f(x) = x + 2", 500, 400);

        }


        private void DrawQuadraticFunction(OpenGL gl)
        {
            /*
             * f(x) = x^2 + 2x - 5;
             * Let x be 2, then y = 3
             * Let x be -1, then y = -6
             */

            //gl.PointSize(1.0f);
            //gl.Begin(OpenGL.GL_POINTS);
            //for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
            //{
            //    gl.Vertex(x, Math.Pow(x, 2) + (2 * x) - 5);
            //}
            //gl.End();

            /*
             * f(x) = x^2
             * 
             */
            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
            {
                gl.Vertex(x, Math.Pow(x, 2));
            }
            gl.End();

            DrawText(gl, "f(x) = x ^ 2", 360, 380);

        }

        private void DrawCircle(OpenGL gl)
        {
            float radius = 3.0f;

            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = 0; i <= TOTAL_CIRCLE_ANGLE; i++)
            {
                gl.Vertex(Math.Cos(i) * radius, Math.Sin(i) * radius);
            }
            gl.End();

            DrawText(gl, "(cos(x), sin(x))", 350, 200);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    b.x++;
                    break;
                case Key.S:
                    b.x--;
                    break;
                case Key.A:
                    b.y++;
                    break;
                case Key.D:
                    b.y--;
                    break;
            }
        } 
        #region opengl init
        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);

        }
        #endregion

        #region draw text
        private void DrawText(OpenGL gl, string text, int x, int y)
        {
            gl.DrawText(x, y, 1, 1, 1, "Arial", 12, text);
        }
        #endregion
        #endregion
        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
             
            var pos = e.GetPosition(this);
            mousePos.x = (float)pos.X - (float)Width / 2.0f;
            mousePos.y = (float)pos.Y - (float)Height / 2.0f;

            mousePos.y = -mousePos.y;

            //mousePos = new Vector3(e.GetPosition(this).X,
            //    e.GetPosition(this).Y, 0);
            //mousePos.x = (float)mousePos.x - (float)Width / 2.0f;
            //mousePos.y = (float)mousePos.y - (float)Width / 2.0f;

            Console.WriteLine("mouse x: " + mousePos.x + "y: " + mousePos.y);
            // mousePos.X = (float)e.GetPosition.X;
            // mousePos.Y = (float)e.GetPosition.Y;
        }
    }
}
