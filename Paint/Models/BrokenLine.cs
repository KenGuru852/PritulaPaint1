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

namespace Paint.Models
{
    public class BrokenLine : Line
    {
        public BrokenLine() { }
        private string _BrokenLinePoints { get; set; }

        public Points GetPoints {get; set; }
        public string BrokenLinePoints { get => _BrokenLinePoints; set { _BrokenLinePoints = value; } }


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
            _BrokenLinePoints = SBrokenPoints;
            LineThickness= SLineThickness;
            LineColor = SLineColor;
        }

        //BrokenLines.Add(new BrokenLine { Name = _Name, BrokenLinePoints = BrokenPoints, LineThickness = lineThickness, LineColor = Colors[SelectedBoxIndex]

    }
}
