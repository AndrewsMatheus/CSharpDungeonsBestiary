using DungeonsBestiary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Classes
{
    public class Monster : BaseEntity {

        // Atributtes

        private String Name { get; set; }

        private String Description { get; set; }

        private Alignment alignment { get; set; }

        private int LifePoints { get; set; }

        private int Strength { get; set; }

        internal void Delete()
        {
            throw new NotImplementedException();
        }

        private int Dexterity { get; set; }

        private int Constitution { get; set; }

        private int Inteligence { get; set; }

        private int Wisdom { get; set; }

        private int Charisma { get; set; }

        private List<Language> Language { get; set; }

        private bool deleted { get; set; }

        public Monster(int id, string name, string description, Alignment aligment, int lifePoints, int strength, int dexterity, int constitution, int inteligence, int wisdom, int charisma, List<Language> language)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.alignment = aligment;
            this.LifePoints = lifePoints;
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Inteligence = inteligence;
            this.Wisdom = wisdom;
            this.Charisma = charisma;
            this.Language = language;
            this.deleted = false;
        }

        public override string ToString() {

            string retorno = "";

            retorno += "Name: " + this.Name + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Aligment: " + this.alignment + Environment.NewLine;
            retorno += "Life Points: " + this.LifePoints + Environment.NewLine;
            retorno += "Strength: " + this.Strength + Environment.NewLine;
            retorno += "Dexterity: " + this.Dexterity + Environment.NewLine;
            retorno += "Constitution: " + this.Constitution + Environment.NewLine;
            retorno += "Inteligence: " + this.Inteligence + Environment.NewLine;
            retorno += "Wisdom: " + this.Wisdom + Environment.NewLine;
            retorno += "Charisma: " + this.Charisma + Environment.NewLine;
            retorno += "Languages: ";

            retorno += String.Join(", ", Language);

            return retorno;
        }

        public int getId()
        {
            return this.Id;
        }

    }
}
