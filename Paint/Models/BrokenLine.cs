using Avalonia;
using Avalonia.Markup.Xaml.Converters;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace Paint.Models
{
    public class BrokenLine : Figure 
    {
        private bool _ActiveButton { get; set; }
        public override bool ActiveButton { get => _ActiveButton; set { _ActiveButton = value; } }
        public override string Name {get;set;}

        private string _FigureType = "BrokenLine";
        public override string FigureType { get => _FigureType;set { _FigureType = value; } }

        private string _FigurePoint { get; set; }
        public override string FigurePoint { get => _FigurePoint; set { _FigurePoint = value; } }
        public BrokenLine() { }

        public override Points GetPoints { get; set; }

        public override int LineThickness { get; set; }

        public override string LineColor { get; set; }

        public BrokenLine(string SName, string SBrokenPoints, int SLineThickness, string SLineColor)
        {
            GetPoints = new Points { };
            string[] split = SBrokenPoints.Split(',');
            foreach (var Item in split)
            {
                string[] NewSplit = Item.Split(" ");
                string NewPoint = NewSplit[0] + ',' + NewSplit[1];
                GetPoints.Add(Point.Parse(NewPoint));
            }
            // "20 400, 400 500, 550 870"
            Name = SName;
            _FigurePoint = SBrokenPoints;
            LineThickness= SLineThickness;
            LineColor = SLineColor;
            FigureType = "BrokenLine";
        }

        //BrokenLines.Add(new BrokenLine { Name = _Name, BrokenLinePoints = BrokenPoints, LineThickness = lineThickness, LineColor = Colors[SelectedBoxIndex]

    }
}
