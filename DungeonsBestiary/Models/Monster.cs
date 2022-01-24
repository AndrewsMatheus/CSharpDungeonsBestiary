using DungeonsBestiary.Enum;
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
    public class Monster : BaseEntity {

        // Properties

        public String Name { get; set; }

        public String Description { get; set; }

        public Alignment Alignment { get; set; }

        public int LifePoints { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Inteligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

        // Entity Relationship
        public List<LanguageMonster> LanguageMonsters { set; get; }

        public virtual ICollection<Language> Languages { get; set; }

        // Constructors
        public Monster(string name, string description, Alignment aligment, int lifePoints, int strength, int dexterity, int constitution, int inteligence, int wisdom, int charisma)
        {
            this.MonsterId = 0;
            this.Name = name;
            this.Description = description;
            this.Alignment = aligment;
            this.LifePoints = lifePoints;
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Inteligence = inteligence;
            this.Wisdom = wisdom;
            this.Charisma = charisma;
            this.LanguageMonsters = new List<LanguageMonster>();
            this.Languages = new HashSet<Language>();

        }
        public Monster()
        {
            this.LanguageMonsters = new List<LanguageMonster>();
            this.Languages = new List<Language>();
        }

        // To String method
        public override string ToString() {

            string _return = "";

            _return += "Name: " + this.Name + Environment.NewLine;
            _return += "Description: " + this.Description + Environment.NewLine;
            _return += "Aligment: " + this.Alignment + Environment.NewLine;
            _return += "Life Points: " + this.LifePoints + Environment.NewLine;
            _return += "Strength: " + this.Strength + Environment.NewLine;
            _return += "Dexterity: " + this.Dexterity + Environment.NewLine;
            _return += "Constitution: " + this.Constitution + Environment.NewLine;
            _return += "Inteligence: " + this.Inteligence + Environment.NewLine;
            _return += "Wisdom: " + this.Wisdom + Environment.NewLine;
            _return += "Charisma: " + this.Charisma + Environment.NewLine;
            _return += "Languages: ";


            _return += String.Join<Language>(",", this.LanguageMonsters.Select(m => m.Language));

            return _return;
        }
    }
}
