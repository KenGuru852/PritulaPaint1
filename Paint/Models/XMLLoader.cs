using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Paint.Models
{
    public class XMLLoader : IFigureLoader
    {
        public IEnumerable<Figure> Load(string path)
        {
            string[] Colors = { "Red", "Yellow", "Blue", "Green", "Black" };
            XDocument xDocument = XDocument.Load(path);
            IEnumerable<Figure>? allLines = xDocument.Element("AllFigures")?
                .Elements("figure")
                .Select(
                    figure =>
                    {
                        var figureType = figure.Attribute("Type");
                        if (figureType.Value == "Line")
                        {
                            var figureName = figure.Element("Name");
                            var figureXPoint = figure.Element("XPoint");
                            var figureYPoint = figure.Element("YPoint");
                            var figureThickness = figure.Element("Thickness");
                            var figureLineColor = figure.Element("LineColor");
                            return new Line
                            {
                                Name = figureName.Value,
                                XPoint = Point.Parse(figureXPoint.Value),
                                YPoint = Point.Parse(figureYPoint.Value),
                                LineThickness = int.Parse(figureThickness.Value),
                                LineColor = figureLineColor.Value
                            };
                                   //         AllFigure.Add(new Line
                                     //       {
                                       //         Name = NewName,
                                         //       XPoint = NewXPoint,
                                           //     YPoint = NewYPoint,
                                             //   LineThickness = NewThickness,
                                               // LineColor = NewColor
                                            //});
                        }
                        return new Line
                        {
                            Name = "UNDEFINED",
                            XPoint = Point.Parse("100 100"),
                            YPoint = Point.Parse("100 100"),
                            LineThickness = 1,
                            LineColor = "RED"
                        };
                    }
                );

            IEnumerable<Figure>? allBrokenLines = xDocument.Element("AllFigures")?
            .Elements("figure")
            .Select(
        figure =>
        {
            var figureType = figure.Attribute("Type");
            if (figureType.Value == "BrokenLine")
            {
                var figureName = figure.Element("Name");
                var figurePoints = figure.Element("FigPoints");
                var figureThickness = figure.Element("Thickness");
                var figureLineColor = figure.Element("LineColor");
                var BrLine = new BrokenLine(figureName.Value, figurePoints.Value, int.Parse(figureThickness.Value), figureLineColor.Value);
                return BrLine;
            }
            return new BrokenLine("UNDEFINED", "100 100", 2, "Red");
        }
    );

            IEnumerable<Figure>? allMultipleCorners = xDocument.Element("AllFigures")?
            .Elements("figure")
            .Select(
        figure =>
        {
            var figureType = figure.Attribute("Type");
            if (figureType.Value == "MultipleCorners")
            {
                var figureName = figure.Element("Name");
                var figurePoints = figure.Element("FigPoints");
                var figureThickness = figure.Element("Thickness");
                var figureLineColor = figure.Element("LineColor");
                var figureFillColor = figure.Element("FillColor");
                var MulCorners = new MultipleCorners(figureName.Value, figurePoints.Value, int.Parse(figureThickness.Value), figureLineColor.Value, figureFillColor.Value);
                return MulCorners;
            }
            return new MultipleCorners("UNDEFINED", "100 100", 2, "Red", "Red");
        }
    );

            IEnumerable<Figure>? allRectangles = xDocument.Element("AllFigures")?
            .Elements("figure")
            .Select(
            figure =>
            {
                var figureType = figure.Attribute("Type");
                if (figureType.Value == "Rectangle")
                {
                    var figureName = figure.Element("Name");
                    var figureThickness = figure.Element("Thickness");
                    var figureLineColor = figure.Element("LineColor");
                    var figureFillColor = figure.Element("FillColor");
                    var figureHeight = figure.Element("Height");
                    var figureWidth = figure.Element("Width");
                    var figurePoints = figure.Element("FigPoints");
                    var NewRec = new RectangleClass(figureName.Value, int.Parse(figureThickness.Value), figureLineColor.Value, figureFillColor.Value, figureHeight.Value, figureWidth.Value, figurePoints.Value);
                    return NewRec;
                }
                return new RectangleClass("UNDEFINED", 2, "Red", "Red", "100", "200", "100 100");
            }
            );

            IEnumerable<Figure>? allEllipse = xDocument.Element("AllFigures")?
           .Elements("figure")
           .Select(
           figure =>
           {
               var figureType = figure.Attribute("Type");
               if (figureType.Value == "Ellipse")
               {
                   var figureName = figure.Element("Name");
                   var figureThickness = figure.Element("Thickness");
                   var figureLineColor = figure.Element("LineColor");
                   var figureFillColor = figure.Element("FillColor");
                   var figureHeight = figure.Element("Height");
                   var figureWidth = figure.Element("Width");
                   var figurePoints = figure.Element("FigPoints");
                   var NewRec = new EllipseFigure(figureName.Value, int.Parse(figureThickness.Value), figureLineColor.Value, figureFillColor.Value, figureHeight.Value, figureWidth.Value, figurePoints.Value);
                   return NewRec;
               }
               return new EllipseFigure("UNDEFINED", 2, "Red", "Red", "100", "200", "100 100");
           }
           );

            IEnumerable<Figure>? allMixLines = xDocument.Element("AllFigures")?
            .Elements("figure")
            .Select(
            figure =>
              {
                  var figureType = figure.Attribute("Type");
                  if (figureType.Value == "MixLine")
                  {
                      var figureName = figure.Element("Name");
                      var figureThickness = figure.Element("Thickness");
                      var figureLineColor = figure.Element("LineColor");
                      var figureFillColor = figure.Element("FillColor");
                      var figureCommands = figure.Element("Commands");
                      var NewMixLine = new MixLineClass(figureName.Value, figureCommands.Value, int.Parse(figureThickness.Value), figureLineColor.Value, figureFillColor.Value);
                      return NewMixLine;
                  }
                  return new MixLineClass("UNDEFINED", "M 100,400 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -30 v 50 l -50,50 Z", 2, "Red", "Red");
              }
           );


            ObservableCollection<Figure> AllFigures = new ObservableCollection<Figure>();
            foreach(var lines in allLines)
            {
                if (lines.Name != "UNDEFINED")
                {
                    AllFigures.Add(lines);
                }
            }
            foreach(var brlines in allBrokenLines)
            {
                if (brlines.Name != "UNDEFINED")
                {
                    AllFigures.Add(brlines);
                }
            }
            foreach(var item in allMultipleCorners)
            {
                if(item.Name != "UNDEFINED")
                { AllFigures.Add(item);}
            }
            foreach(var item in allRectangles)
            {
                if (item.Name != "UNDEFINED")
                { AllFigures.Add(item); }
            }
            foreach (var item in allEllipse)
            {
                if (item.Name != "UNDEFINED")
                { AllFigures.Add(item); }
            }
            foreach(var item in allMixLines)
            {
                if (item.Name != "UNDEFINED")
                { AllFigures.Add(item); }
            }
            return AllFigures;
        }
       
    }
}
