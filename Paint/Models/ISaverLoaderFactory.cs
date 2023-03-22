using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public interface ISaverLoaderFactory
    {
        IFigureSaver CreateSaver();

        IFigureLoader CreateLoader();
        bool IsMatch(string path);
    }
}
