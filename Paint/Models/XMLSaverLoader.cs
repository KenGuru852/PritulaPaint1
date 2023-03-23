using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    internal class XMLSaverLoader : ISaverLoaderFactory
    {
        public IFigureLoader CreateLoader()
        {
            return new XMLLoader();
        }
        public IFigureSaver CreateSaver()
        {
            return new XMLSaver();
        }

        public bool IsMatch(string path)
        {
            return ".xml".Equals(Path.GetExtension(path));
        }
    }
}
