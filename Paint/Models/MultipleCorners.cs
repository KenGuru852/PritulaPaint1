using Avalonia;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class MultipleCorners : Figure
    {
        private string _FigureType = "MultipleCorners";
        public override string FigureType { get => _FigureType; set { _FigureType = value; } }

        private string _FigurePoint { get; set; }
        public override string FigurePoint { get => _FigurePoint; set { _FigurePoint = value; } }
        public override string Name { get; set; }
        public override Points GetPoints { get; set; }
        public MultipleCorners() { }

        public override int LineThickness { get; set; }

        public override string LineColor { get; set; }

        private bool _ActiveButton { get; set; }
        public override bool ActiveButton { get => _ActiveButton; set { _ActiveButton = value; } }
        public override string FillColor { get; set; }

        public MultipleCorners(string _Name, string _BrokenPoints, int _LineThickness, string _LineColor, string _FillColor)
        {
            FigurePoint = _BrokenPoints;
            FigureType = "MultipleCorners";
            GetPoints = new Points { };
            string[] split = _BrokenPoints.Split(',');
            foreach (var Item in split)
            {
                string[] NewSplit = Item.Split(" ");
                string NewPoint = NewSplit[0] + ',' + NewSplit[1];
                GetPoints.Add(Point.Parse(NewPoint));
            }
            // "20 400, 400 500, 550 870"
            Name = _Name;
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            FillColor = _FillColor;
            Debug.WriteLine(FigureType);
        }
    }
}
