﻿using Avalonia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class Line : Figure
    {
        /*public Line() {
            FigureType = "Line";
            Debug.WriteLine(LineXPoint);
            Debug.WriteLine(LineYPoint);
            XPoint = Point.Parse(LineXPoint);
            YPoint = Point.Parse(LineYPoint);
        }*/

        public Line (string _LineName, string _LineXPoint, string _LineYPoint, int _LineThickness, string _LineColor)
        {
            Name = _LineName;
            LineXPoint = _LineXPoint;
            LineYPoint = _LineYPoint;
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            FigureType = "Line";
            XPoint = Point.Parse(LineXPoint);
            YPoint = Point.Parse(LineYPoint);
        }
        private bool _ActiveButton { get; set; }
        public override bool ActiveButton { get => _ActiveButton; set { _ActiveButton = value; } }
        private string _FigureType = "Line";
        public override string FigureType { get => _FigureType; set { _FigureType = value; } }

        private string _LineXPoint { get; set; }
        private string _LineYPoint { get; set; }
        public override string LineXPoint { get => _LineXPoint; set => _LineXPoint = value; }
        public override string LineYPoint { get => _LineYPoint; set => _LineYPoint = value; }
        private string _Name { get; set; }
        public override string Name { get => _Name; set { _Name = value; } }
        public override Point XPoint { get; set; }
        public override Point YPoint { get; set; }

        public override int LineThickness { get; set; }

        public override string LineColor { get; set; }

    }
}
