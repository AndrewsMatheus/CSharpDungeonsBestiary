using DungeonsBestiary.Classes;
using DungeonsBestiary.Enum;
using DungeonsBestiary.Models;
using DungeonsBestiary.Repository;
using DungeonsBestiary.Service;

namespace DungeonsBestiary
{
    class Program
	{
		static MonsterContext monsterContext = new MonsterContext();
		static MonsterService monsterService = new MonsterService(monsterContext);
		static void Main(string[] args)
		{
			string option = GetUserOption();

			while (option.ToUpper() != "X")
			{
				switch (option)
				{
					case "1":
						ListMonsters();
						break;
					case "2":
						InsertMonster();
						break;
					case "3":
						DeleteMonster();
						break;
					case "4":
						ShowMonster();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				option = GetUserOption();
			}
		}

		private static void DeleteMonster()
		{
			var monsterId = getId();
			
			monsterService.DeleteById(monsterId);
			
		}
		private static void ShowMonster()
		{
			
			int monsterIndex = getId();

			try
			{
				var monster = monsterService.GetById(monsterIndex);

				Console.WriteLine(monster.ToString());

				var lang = monsterService.GetLanguages(monster.MonsterId);

				Console.WriteLine(String.Join(", ", lang));
			}
			catch {
				Console.WriteLine("Monster with ID {0} not found!", monsterIndex);
			}
			
		}
		private static void ListMonsters()
		{
			Console.WriteLine("List All Monsters: ");

			try
			{
				var list = monsterService.GetMonsters();
				
				foreach (var monster in list)
				{
					Console.WriteLine(monster.ToString());
					var lang = monsterService.GetLanguages(monster.MonsterId);
					Console.WriteLine(string.Join(", ", lang));
					
				}
			}
			catch {
				Console.WriteLine("The database is empty!!");
			}
			
		}
		private static void InsertMonster()
		{
			Console.WriteLine("Insert a new monster: ");

            foreach (int i in Enum.Alignment.GetValues(typeof(Alignment)))
			{
				Console.WriteLine(i + " - " + Enum.Alignment.GetName(typeof(Alignment), i));
			}
			Console.Write("Type the monster's Alignment: ");
			int entryAlignmentnumber = int.Parse(Console.ReadLine());

			Alignment entryAlignment = new Alignment();

			entryAlignment = (Alignment) entryAlignmentnumber;

			Console.Write("Type the monster's name: ");
			string entryName = Console.ReadLine();

			Console.Write("Type the monster's description: ");
			string entryDescription  = Console.ReadLine();

			Console.Write("Type the monster's LifePoints: ");
			int EntryLifePoints = int.Parse(Console.ReadLine());

			Console.Write("Type the monster's Strength: ");
			int EntryStrength = int.Parse(Console.ReadLine());

			Console.Write("Type the monster's Dexterity: ");
			int EntryDexterity = int.Parse(Console.ReadLine());
			
			Console.Write("Type the monster's Constitution: ");
			int EntryConstitution = int.Parse(Console.ReadLine());

			Console.Write("Type the monster's Inteligence: ");
			int EntryInteligence = int.Parse(Console.ReadLine());

			Console.Write("Type the monster's Wisdom: ");
			int EntryWisdom = int.Parse(Console.ReadLine());

			Console.Write("Type the monster's Charisma: ");
			int EntryCharisma = int.Parse(Console.ReadLine());

			Monster newMonster = new Monster(entryName, entryDescription, entryAlignment, EntryLifePoints, EntryStrength, EntryDexterity, EntryConstitution, EntryInteligence, EntryWisdom, EntryCharisma);

			Console.Write("Type the monster's Language Spoken (For more than one type one per entry then when finish just press Enter): ");

			string EntryLanguage = Console.ReadLine();

			while (EntryLanguage != "") {

				var l = new Language();

				l.Name = EntryLanguage;

				LanguageMonster languageMonster = new LanguageMonster(l.LanguageId, newMonster.MonsterId, l, newMonster);

				l.LanguageMonsters.Add(languageMonster);
				newMonster.LanguageMonsters.Add(languageMonster);

				EntryLanguage = Console.ReadLine();

			}

			monsterService.Create(newMonster);
		}

		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Inform a valid option");

			Console.WriteLine("1- List monsters");
			Console.WriteLine("2- Insert a new monster");
			Console.WriteLine("3- Delete a existing monster");
			Console.WriteLine("4- Show monster");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
		private static int getId() {

			Console.Write("Type the monster ID:  ");

			return int.Parse(Console.ReadLine());
		}
	}
}