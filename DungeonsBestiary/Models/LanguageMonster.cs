using DungeonsBestiary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Models
{
    public class LanguageMonster{

        public int LanguageId { get; set; }

        public Language Language { get; set; }
        
        public int MonsterId { get; set; }

        public Monster Monster { get; set; }

        public LanguageMonster(int languageId, int monsterId, Language l, Monster m) {

            this.LanguageId = languageId;
            this.MonsterId = monsterId;
            this.Language = l;
            this.Monster = m;
        }
        public LanguageMonster() {
            Language = new Language();
            Monster = new Monster();
        }

        public override string ToString() {

            return Language.Name;
        }
    }
}
