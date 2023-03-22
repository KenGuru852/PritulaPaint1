using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Paint.Models
{
    public class XMLSaver : IFigureSaver
    {
        public void Save(IEnumerable<Figure> figures, string path)
        {
            XDocument xDocument = new XDocument();
            XElement xElementFigures = new XElement("AllFigures");

            foreach(Figure f in figures)
            {
                if (f.FigureType == "Line")
                {
                    XElement xElementFigure = new XElement("figure");
                    XAttribute xAttributeFigureType = new XAttribute("Type", f.FigureType);
                    XElement xElementFigureName = new XElement("Name", f.Name);
                    XElement xElementFigureXPoint = new XElement("XPoint", f.XPoint);
                    XElement xElementFigureYPoint = new XElement("YPoint", f.YPoint);
                    XElement xElementFigureTickness = new XElement("Thickness", f.LineThickness);
                    XElement xElementFigureLineColor = new XElement("LineColor", f.LineColor);

                    xElementFigure.Add(xAttributeFigureType);
                    xElementFigure.Add(xElementFigureName);
                    xElementFigure.Add(xElementFigureXPoint);
                    xElementFigure.Add(xElementFigureYPoint);
                    xElementFigure.Add(xElementFigureTickness);
                    xElementFigure.Add(xElementFigureLineColor);

                    xElementFigures.Add(xElementFigure);
                }

                if (f.FigureType == "BrokenLine")
                {
                    XElement xElementFigure = new XElement("figure");
                    XAttribute xAttributeFigureType = new XAttribute("Type", f.FigureType);
                    XElement xElementFigureName = new XElement("Name", f.Name);
                    XElement xElementFigurePoints = new XElement("FigPoints", f.FigurePoint);
                    XElement xElementFigureTickness = new XElement("Thickness", f.LineThickness);
                    XElement xElementFigureLineColor = new XElement("LineColor", f.LineColor);

                    xElementFigure.Add(xAttributeFigureType);
                    xElementFigure.Add(xElementFigureName);
                    xElementFigure.Add(xElementFigurePoints);
                    xElementFigure.Add(xElementFigureTickness);
                    xElementFigure.Add(xElementFigureLineColor);

                    xElementFigures.Add(xElementFigure);
                }

                if (f.FigureType == "MultipleCorners")
                {
                    XElement xElementFigure = new XElement("figure");
                    XAttribute xAttributeFigureType = new XAttribute("Type", f.FigureType);
                    XElement xElementFigureName = new XElement("Name", f.Name);
                    XElement xElementFigurePoints = new XElement("FigPoints", f.FigurePoint);
                    XElement xElementFigureTickness = new XElement("Thickness", f.LineThickness);
                    XElement xElementFigureLineColor = new XElement("LineColor", f.LineColor);
                    XElement xElementFigureFillColor = new XElement("FillColor", f.FillColor);

                    xElementFigure.Add(xAttributeFigureType);
                    xElementFigure.Add(xElementFigureName);
                    xElementFigure.Add(xElementFigurePoints);
                    xElementFigure.Add(xElementFigureTickness);
                    xElementFigure.Add(xElementFigureLineColor);
                    xElementFigure.Add(xElementFigureFillColor);

                    xElementFigures.Add(xElementFigure);
                }

                if (f.FigureType == "Rectangle" || f.FigureType == "Ellipse")
                {
                    XElement xElementFigure = new XElement("figure");
                    XAttribute xAttributeFigureType = new XAttribute("Type", f.FigureType);
                    XElement xElementFigureName = new XElement("Name", f.Name);
                    XElement xElementFigurePoints = new XElement("FigPoints", f.FigurePoint);
                    XElement xElementFigureHeight = new XElement("Height", f.Height);
                    XElement xElementFigureWidth = new XElement("Width", f.Width);
                    XElement xElementFigureTickness = new XElement("Thickness", f.LineThickness);
                    XElement xElementFigureLineColor = new XElement("LineColor", f.LineColor);
                    XElement xElementFigureFillColor = new XElement("FillColor", f.FillColor);

                    xElementFigure.Add(xAttributeFigureType);
                    xElementFigure.Add(xElementFigureName);
                    xElementFigure.Add(xElementFigurePoints);
                    xElementFigure.Add(xElementFigureHeight);
                    xElementFigure.Add(xElementFigureWidth);
                    xElementFigure.Add(xElementFigureTickness);
                    xElementFigure.Add(xElementFigureLineColor);
                    xElementFigure.Add(xElementFigureFillColor);

                    xElementFigures.Add(xElementFigure);
                }

                if (f.FigureType == "MixLine")
                {
                    XElement xElementFigure = new XElement("figure");
                    XAttribute xAttributeFigureType = new XAttribute("Type", f.FigureType);
                    XElement xElementFigureName = new XElement("Name", f.Name);
                    XElement xElementFigureCommands = new XElement("Commands", f.Commands);
                    XElement xElementFigureTickness = new XElement("Thickness", f.LineThickness);
                    XElement xElementFigureLineColor = new XElement("LineColor", f.LineColor);
                    XElement xElementFigureFillColor = new XElement("FillColor", f.FillColor);

                    xElementFigure.Add(xAttributeFigureType);
                    xElementFigure.Add(xElementFigureName);
                    xElementFigure.Add(xElementFigureCommands);
                    xElementFigure.Add(xElementFigureTickness);
                    xElementFigure.Add(xElementFigureLineColor);
                    xElementFigure.Add(xElementFigureFillColor);

                    xElementFigures.Add(xElementFigure);
                }
            }
            xDocument.Add(xElementFigures);
            xDocument.Save(path);
        }
    }
}
