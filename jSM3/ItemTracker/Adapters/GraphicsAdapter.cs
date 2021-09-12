using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace jSM3.ItemTracker.Adapters
{
    public class GraphicsAdapter
    {
        private readonly Graphics _g;

        public int Width { get; init; }
        public int Height { get; init; }

        public GraphicsAdapter(Graphics g, Size formsize)
        {
            _g = g ?? throw new ArgumentNullException(nameof(g));
            _g.PixelOffsetMode = PixelOffsetMode.Half;
            _g.InterpolationMode = InterpolationMode.NearestNeighbor;

            Width = formsize.Width;
            Height = formsize.Height;
        }

        public void Clear(Color color)
        {
            _g.Clear(color);
        }
        
        
        

        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight,
            GraphicsUnit srcUnit, ImageAttributes attributes)
        {
            _g.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit, attributes);
        }

        public void DrawImage(Image image, Rectangle destRect, int srcX, int srcY, int srcWidth, int srcHeight,
            GraphicsUnit srcUnit)
        {
            _g.DrawImage(image, destRect, srcX, srcY, srcWidth, srcHeight, srcUnit);
        }

        public void DrawImage(Image image, float x, float y)
        {
            _g.DrawImage(image, x, y);
        }

        public void DrawItemEquippedCircle(Rectangle sourceRect)
        {

            Rectangle destinationRect = new Rectangle(
                sourceRect.X,
                sourceRect.Y,
                (int)Math.Ceiling((double)(sourceRect.Width / 3)),
                (int)Math.Ceiling((double)(sourceRect.Height / 3))
            );
            
            // Create a path that consists of a single ellipse.
            GraphicsPath path = new();
            path.AddEllipse(destinationRect);

            // Use the path to construct a brush.
            PathGradientBrush pthGrBrush = new(path);

            // Set the color at the center of the path to blue.
            pthGrBrush.CenterColor = Color.Chartreuse;

            // Set the color along the entire boundary
            // of the path to aqua.
            Color[] colors = { Color.Green,  };
            pthGrBrush.SurroundColors = colors;

            _g.FillEllipse(pthGrBrush, destinationRect);
        }
    }
}