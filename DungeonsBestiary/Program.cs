using DungeonsBestiary.Classes;
using DungeonsBestiary.Enum;
namespace DungeonsBestiary
{
    class Program
	{
		static MonsterRepository repository = new MonsterRepository();
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

			Console.WriteLine("Exiting program.");
		}

		private static void DeleteMonster()
		{
			Console.Write("Type the monster ID: ");
			int monsterIndex = int.Parse(Console.ReadLine());

			repository.Delete(monsterIndex);

			Console.Write("Monster with id " + monsterIndex + " Delete Successfully ");
		}

		private static void ShowMonster()
		{
			Console.Write("Type the monster ID:  ");
			int monsterIndex = int.Parse(Console.ReadLine());

			var monster = repository.ReturnId(monsterIndex);

			Console.WriteLine(monster);
		}

		private static void ListMonsters()
		{
			Console.WriteLine("List Monsters: ");

			var list = repository.GetAll();

			if (list.Count == 0)
			{
				Console.WriteLine("None monster found");
				return;
			}

			foreach (var monster in list)
			{	
				Console.WriteLine(monster.getId());
				Console.WriteLine(monster.ToString());
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

			List<Language> lang = new List<Language>();

			Console.Write("Type the monster's Language Spoken (For more than one type one per entry then when finish just press Enter): ");

			string EntryLanguage = Console.ReadLine();

			while (EntryLanguage != "") {

				lang.Add(new Language(EntryLanguage));

				EntryLanguage = Console.ReadLine();
			}

			Monster newMonster = new Monster(repository.NextId(), entryName, entryDescription, entryAlignment, EntryLifePoints, EntryStrength, EntryDexterity, EntryConstitution, EntryInteligence, EntryWisdom, EntryCharisma, lang);

			repository.Insert(newMonster);
		}

		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Inform a valid option");

			Console.WriteLine("1- List monsters");
			Console.WriteLine("2- Insert a new monster");
			Console.WriteLine("3- Delete a existing monster");
			Console.WriteLine("4- Show monster");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}