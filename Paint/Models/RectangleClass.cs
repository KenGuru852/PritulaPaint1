using Avalonia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class RectangleClass : Figure
    {
        private string _FigureType = "Rectangle";

        public override string Name { get; set; }
        public override string FigureType { get => _FigureType; set { _FigureType = value; } }
        public RectangleClass() { }
        public override Rect RectClassRect { get; set; }
        public override int Width { get; set; }
        public override int Height { get; set; }
        public override int LineThickness { get; set; }
        public override string LineColor { get; set; }
        private bool _ActiveButton { get; set; }
        public override bool ActiveButton { get => _ActiveButton; set { _ActiveButton = value; } }
        public override string FillColor { get; set; }
        public override string FigurePoint { get; set; }

        public RectangleClass(string _Name, int _LineThickness, string _LineColor, string _FillColor, string height, string width, string _StartPoint)
        {
            FigureType = "Rectangle";
            Name = _Name;
            Height = int.Parse(height);
            Width = int.Parse(width);
            FigurePoint = _StartPoint;
            string RectPointsString = _StartPoint + ',' + width.ToString() + ',' + height.ToString(); 
            RectClassRect = Rect.Parse(RectPointsString);
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            FillColor = _FillColor;
            Debug.WriteLine(FigureType);
        }
    }
}
