using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Models
{
    public class ShapeName
    {
        private string _Name;
        public string Name { get => _Name; set { _Name = value; } }

        private string _Type;

        public string Type { get => _Type; set { _Type = value; } }

        public ShapeName(string Names, string Types) 
        {
            _Name = Names;
            _Type = Types;
        }
    }
}
