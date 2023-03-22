using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class EllipseFigure : Figure
    {
        public EllipseFigure() {
        }
        private bool _ActiveButton { get; set; }
        public override bool ActiveButton { get => _ActiveButton; set { _ActiveButton = value; } }
        private string _FigureType = "Ellipse";

        public override string Name { get; set; }
        public override string FigureType { get => _FigureType; set { _FigureType = value; } }

        public override int Width { get; set; }
        public override int Height { get; set; }

        public override int LineThickness { get; set; }

        public override string LineColor { get; set; }

        public override string FillColor { get; set; }

        public override string FigurePoint { get; set; }

        public EllipseGeometry EllipseNew { get; set; }

        public EllipseFigure(string _Name, int _LineThickness, string _LineColor, string _FillColor, string height, string width, string _StartPoint)
        {
            FigureType = "Ellipse";
            EllipseNew = new EllipseGeometry();
            Name = _Name;
            Height = int.Parse(height);
            FigurePoint = _StartPoint;
            Width = int.Parse(width);
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            FillColor = _FillColor;
            EllipseNew.RadiusX = Width;
            EllipseNew.RadiusY = Height;
            EllipseNew.Center = Point.Parse(_StartPoint);
            Debug.WriteLine(FigureType);
        }

    }
}
