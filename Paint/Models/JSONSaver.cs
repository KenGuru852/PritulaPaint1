using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class JSONSaver : IFigureSaver
    {
        public void Save(IEnumerable<Figure> figures, string path) 
        {
            File.WriteAllText(path, string.Empty);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, figures,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                    });;;
            }
        }
    }
}
