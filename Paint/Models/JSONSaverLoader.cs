using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    internal class JSONSaverLoader : ISaverLoaderFactory
    {
        public IFigureLoader CreateLoader()
        {
            return new JSONLoader();
        }
        public IFigureSaver CreateSaver()
        {
            return new JSONSaver();
        }
        public bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
