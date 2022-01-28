using DungeonsBestiary.Classes;
using DungeonsBestiary.Models;
using DungeonsBestiary.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Service
{
    public class MonsterService {

        private readonly MonsterContext _context;

        public MonsterService(MonsterContext context)
        {
            _context = context;
        }
        public void UpdateMonster(int monsterId, Monster updatedMonster) {

            var monsterToUpdate = _context.Monsters.Where(monster => monster.MonsterId == monsterId).ToList().First();

            monsterToUpdate.Name = updatedMonster.Name;
            monsterToUpdate.Description = updatedMonster.Description;
            monsterToUpdate.Alignment = updatedMonster.Alignment;
            monsterToUpdate.Strength = updatedMonster.Strength;
            monsterToUpdate.Constitution= updatedMonster.Constitution;
            monsterToUpdate.Charisma = updatedMonster.Charisma;
            monsterToUpdate.LifePoints = updatedMonster.LifePoints;
            monsterToUpdate.Inteligence = updatedMonster.Inteligence;
            monsterToUpdate.Wisdom = updatedMonster.Wisdom;
            monsterToUpdate.Dexterity = updatedMonster.Dexterity;

            foreach (var l in updatedMonster.LanguageMonsters) {
                monsterToUpdate.LanguageMonsters.Add(l);
            }   

            _context.SaveChanges();
        }
        public IEnumerable<Monster> GetMonsters() {

           return _context.Monsters.AsNoTracking().ToList();
            
        }
        public IEnumerable<Language> GetLanguages(int monsterId) {

            var languages = from lang in _context.LanguageMonsters
                            where lang.MonsterId == monsterId
                            select lang.Language;

            return languages;
        }
        public Monster? GetById(int id) {

            return _context.Monsters
                .Include(m => m.LanguageMonsters)
                .AsNoTracking()
                .SingleOrDefault(m => m.MonsterId == id);
        }

        public Monster Create(Monster newMonster) {

            _context.Monsters.Add(newMonster);
            _context.SaveChanges();

            return newMonster;
        }

        public void DeleteById(int monsterId) {

            var monsterToDelete = _context.Monsters.Find(monsterId);

            var languagesToDelete = from lang in _context.LanguageMonsters
                            where lang.MonsterId == monsterId
                            select lang.Language;


            if (monsterToDelete is not null)
            {
                _context.Monsters.Remove(monsterToDelete);
                _context.Languages.RemoveRange(languagesToDelete);
                _context.SaveChanges();
                Console.Write("Monster with id " + monsterId + " Delete Successfully ");
            }
            else {
                Console.WriteLine("Monster with ID {0} not found!", monsterId);
            }
            
        }
    }
}
