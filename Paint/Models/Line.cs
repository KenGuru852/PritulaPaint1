using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class Line
    {
        public string Name { get; set; }
        public Point XPoint { get; set; }
        public Point YPoint { get; set; }

        public int LineThickness { get; set; }

        public string LineColor { get; set; }
    }
}
