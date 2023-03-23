using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class JSONLoader : IFigureLoader
    {
        public IEnumerable<Figure> Load(string path)
        {
            ObservableCollection<Figure> figures = new ObservableCollection<Figure>();

            ObservableCollection<RectangleClass> lines = new ObservableCollection<RectangleClass>();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                lines = JsonSerializer.Deserialize<ObservableCollection<RectangleClass>>(fs);
                if (lines == null)
                {
                    lines = new ObservableCollection<RectangleClass>();
                }
            }

            foreach(RectangleClass item in lines)
            {
                figures.Add(item);
            }
            return figures;
        }
    }
}
