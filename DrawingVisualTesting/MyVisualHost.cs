using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingVisualTesting
{
    public class MyVisualHost : FrameworkElement
    {
        private VisualCollection _children;
       // private List<Visual> _children = new List<Visual>();

   
        public MyVisualHost()
        {
         
           
          //  this.ClipToBounds = true;

            Random rnd = new Random(DateTime.Now.Second);
            List<Point> pts = new List<Point>();
            for (int i=0; i <10; i++)
            {

                pts.Add(new Point(rnd.Next(10, 500), rnd.Next(10, 400)));
            }
            _children = new VisualCollection(this);
            _children.Add(CreateDrawingVisualRectangle());
            _children.Add(CreatePolyLine(pts));

         
            this.MouseDown += MyVisualHost_MouseDown;
            this.SizeChanged += MyVisualHost_SizeChanged;
        }

        private void MyVisualHost_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Clip = new RectangleGeometry(new Rect(new Size(ActualWidth, ActualHeight)));
        }

        private void MyVisualHost_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Retreive the coordinates of the mouse button event.
            Point pt = e.GetPosition((UIElement)sender);

            // Initiate the hit test by setting up a hit test result callback method.
            VisualTreeHelper.HitTest(this, null, MyCallback, new PointHitTestParameters(pt));
        }

        public HitTestResultBehavior MyCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(System.Windows.Media.DrawingVisual))
            {
                ((DrawingVisual)result.VisualHit).Opacity =
                    ((DrawingVisual)result.VisualHit).Opacity == 1.0 ? 0.4 : 1.0;
            }

            // Stop the hit test enumeration of objects in the visual tree.
            return HitTestResultBehavior.Stop;
        }

        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new System.Windows.Point(160, 100), new System.Windows.Size(320, 80));
            drawingContext.DrawRectangle(System.Windows.Media.Brushes.LightBlue, (System.Windows.Media.Pen)null, rect);
            
          
            // Persist the drawing content.
            drawingContext.Close();

            return drawingVisual;
        }

        private DrawingVisual CreatePolyLine(List<Point> points)
        {
            DrawingVisual dv = new DrawingVisual();

        

            DrawingContext dc = dv.RenderOpen();
            
            if (points.Count>2)
            {
                for (int i = 0; i < points.Count - 1; i++)
                    dc.DrawLine(new Pen(Brushes.DodgerBlue,1), points[i], points[i + 1]);
            }
            
            dc.Close();
            return dv;
        }
    
        protected override int VisualChildrenCount => _children.Count;

    
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }

    }
}
