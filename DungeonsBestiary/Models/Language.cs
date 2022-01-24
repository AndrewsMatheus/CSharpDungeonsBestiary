using DungeonsBestiary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Classes
{
    public class Language
    {
        // Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId { set; get; }

        public string Name {set; get;}


        // Entity Relationships
        public List<LanguageMonster> LanguageMonsters { get; set; }

        public virtual ICollection<Monster> Monsters { get; set; }

        // Constructor
        public Language() { 
        
            LanguageMonsters = new List<LanguageMonster>();
            this.Monsters = new List<Monster>();
        }

        public override string ToString() {

            string _return = "";

            _return += "Name: " + this.Name;

            return _return;
        }

    }
}
