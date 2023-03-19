using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class EllipseFigure : RectangleClass
    {
        public EllipseFigure() {
        }

        public EllipseGeometry EllipseNew { get; set; }

        public EllipseFigure(string _Name, int _LineThickness, string _LineColor, string _FillColor, int height, int width, string _StartPoint)
        {
            EllipseNew = new EllipseGeometry();
            Name = _Name;
            HeightRec = height;
            WidthRec = width;
            SStartPoint = _StartPoint;
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            FillColor = _FillColor;
            EllipseNew.RadiusX = WidthRec;
            EllipseNew.RadiusY = HeightRec;
            EllipseNew.Center = Point.Parse(SStartPoint);
        }

    }
}
