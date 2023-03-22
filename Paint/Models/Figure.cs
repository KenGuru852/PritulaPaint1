using Avalonia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public abstract class Figure 
    {
        public virtual string FigureType { get; set; }
        public virtual string Name { get; set; }

        public virtual Point XPoint { get; set; }

        public virtual Point YPoint { get; set; }

        public virtual int LineThickness { get; set; }

        public virtual string LineColor { get; set; }

        public virtual Points GetPoints { get; set; }

        public virtual string FigurePoint { get; set; }

        public virtual string FillColor { get; set; }

        public virtual Rect RectClassRect { get; set; }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public virtual string Commands { get; set; }

        public virtual bool ActiveButton { get; set; }

    }
}
