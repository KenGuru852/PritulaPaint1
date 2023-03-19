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
    public class MixLineClass : MultipleCorners
    {
        public string MixCommand { get; set; }

        public Path MixLinesPoggers { get; set; }

        public MixLineClass(string _Name, string _MixLineCommand, int _LineThickness, string _LineColor, string _FillColor)
        {
            MixLinesPoggers = new Path();
            Name = _Name;
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            MixCommand = _MixLineCommand;
            FillColor = _FillColor;
            MixLinesPoggers.Data = (Geometry.Parse(MixCommand));
        }
    }
}
