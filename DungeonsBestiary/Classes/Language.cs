using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Classes
{
    public class Language
    {

        private string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public Language(string name) {
            Name = name;
        }
    }
}
