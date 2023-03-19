using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class MultipleCorners : BrokenLine
    {
        public MultipleCorners() { }
        public string FillColor { get; set; }

        public MultipleCorners(string _Name, string _BrokenPoints, int _LineThickness, string _LineColor, string _FillColor)
        {
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
            BrokenLinePoints = _BrokenPoints;
            LineThickness = _LineThickness;
            LineColor = _LineColor;
            FillColor = _FillColor;
        }
    }
}
