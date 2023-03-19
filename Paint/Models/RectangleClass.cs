using Avalonia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class RectangleClass : MultipleCorners
    {
        private string _SStartPoint;

        public RectangleClass() { }
        public int HeightRec { get; set; }
        public int WidthRec { get; set; }


        public Rect RectClassRect { get; set; }



        public string SStartPoint { get => _SStartPoint; set { _SStartPoint = value; } }
        private string _RecStartPoint { get; set; }
        public string RecStartPoint { get => _RecStartPoint; set { _RecStartPoint = value; } }
        public RectangleClass(string _Name, int _LineThickness, string _LineColor, string _FillColor, int height, int width, string _StartPoint)
        {
            Name = _Name;
            HeightRec = height;
            WidthRec = width;
            SStartPoint = _StartPoint;
            string RectPointsString = SStartPoint + ',' + width.ToString() + ',' + height.ToString(); 
            RectClassRect = Rect.Parse(RectPointsString);
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            FillColor = _FillColor;
        }
    }
}
