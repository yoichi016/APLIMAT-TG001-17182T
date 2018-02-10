using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs.Models
{
    class CubeMesh
    {
        public Vector3 Position;

        public CubeMesh()
        {
            this.Position = new Vector3();
        }

        public CubeMesh(Vector3 initPos) {
            this.Position = initPos;
        }

        public CubeMesh(float x , float y, float z)
        {
            this.Position = new Vector3(x,y,z);
        }

        public void Draw(OpenGL gl) {
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            
            //front face
            gl.Vertex(this.Position.x - 0.5, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5, this.Position.y - 0.5f, this.Position.z + 0.5f);

            //Right face
            gl.Vertex(this.Position.x + 0.5, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x + 0.5, this.Position.y - 0.5f, this.Position.z - 0.5f);

            //Back face
            gl.Vertex(this.Position.x - 0.5, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x - 0.5, this.Position.y - 0.5f, this.Position.z - 0.5f);

            //Left face
            gl.Vertex(this.Position.x - 0.5, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.End();

            //top  face
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(this.Position.x - 0.5, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5, this.Position.y + 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x + 0.5, this.Position.y + 0.5f, this.Position.z - 0.5f);
            gl.End();

            // bottom face
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(this.Position.x - 0.5, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x + 0.5, this.Position.y - 0.5f, this.Position.z + 0.5f);
            gl.Vertex(this.Position.x - 0.5, this.Position.y - 0.5f, this.Position.z - 0.5f);
            gl.Vertex(this.Position.x + 0.5, this.Position.y - 0.5f, this.Position.z - 0.5f);
            gl.End();
        }
    }
}
