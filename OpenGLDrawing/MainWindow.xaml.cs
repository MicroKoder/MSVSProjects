using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;
using SharpGL.WPF;

namespace OpenGLDrawing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.OpenGLEventArgs args)
        {
            //  Get the OpenGL instance that's been passed to us.
            OpenGL gl = args.OpenGL;

            //  Clear the color and depth buffers.
            //  Reset the modelview matrix.
            gl.LoadIdentity();
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT );

            gl.LoadIdentity();

            gl.LineWidth(2);

            gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 0.5);
                gl.Vertex(-1.0f, 0.0f);

                gl.Color(1.0, 1.0, 0.5);
                gl.Vertex(0.75f, 0.0f);
            gl.End();


            //  Flush OpenGL.
            gl.Flush();

         
        }

        private void ogl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            OpenGL gl= args.OpenGL;
        }
    }
}
