using Avalonia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class Line : Figure
    {
        public Line() {
            FigureType = "Line";
        }
        private bool _ActiveButton { get; set; }
        public override bool ActiveButton { get => _ActiveButton; set { _ActiveButton = value; } }
        private string _FigureType = "Line";
        public override string FigureType { get => _FigureType; set { _FigureType = value; } }
        
        private string _Name { get; set; }
        public override string Name { get => _Name; set { _Name = value; } }
        public override Point XPoint { get; set; }
        public override Point YPoint { get; set; }

        public override int LineThickness { get; set; }

        public override string LineColor { get; set; }

    }
}
