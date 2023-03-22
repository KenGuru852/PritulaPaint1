using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class MixLineClass : Figure
    {
        public override string Name { get; set; }

        private string _FigureType = "MixLine";
        public override string FigureType { get => _FigureType; set { _FigureType = value; } }

        public override string Commands { get; set; }

        public override int LineThickness { get; set; }

        public override string LineColor { get; set; }

        public override string FillColor { get; set; }

        private bool _ActiveButton { get; set; }
        public override bool ActiveButton { get => _ActiveButton; set { _ActiveButton = value; } }
        public Path MixLines { get; set; }

        public MixLineClass(string _Name, string _MixLineCommand, int _LineThickness, string _LineColor, string _FillColor)
        {
            FigureType = "MixLine";
            MixLines = new Path();
            Name = _Name;
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            Commands = _MixLineCommand;
            FillColor = _FillColor;
            MixLines.Data = (Geometry.Parse(Commands));
        }
    }
}
