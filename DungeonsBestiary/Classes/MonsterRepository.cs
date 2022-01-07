using DungeonsBestiary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Classes
{
    public class MonsterRepository : IRepository<Monster>
    {

        private List<Monster> MonsterList = new List<Monster>();

        public void Update(int id, Monster obj) {

            MonsterList[id] = obj;
        }

        public void Delete(int id) {

            MonsterList.RemoveAt(id);        
        }
        public void Insert(Monster obj) {

            MonsterList.Add(obj);
        }
        public List<Monster> GetAll() {

            return MonsterList;
        }
        public int NextId() {

            return MonsterList.Count;
        }
        public Monster ReturnId(int id) {

            return MonsterList[id];
        }
    }
}
