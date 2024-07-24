using System;
using System.Collections.Generic;
using System.Linq;

namespace MushroomPocket
{
    class Program
    {
        static void Main(string[] args)
        {
            //MushroomMaster criteria list for checking character transformation availability.   
            /*************************************************************************
                PLEASE DO NOT CHANGE THE CODES FROM LINE 15-19
            *************************************************************************/
            List<MushroomMaster> mushroomMasters = new List<MushroomMaster>(){
            new MushroomMaster("Daisy", 2, "Peach"),
            new MushroomMaster("Wario", 3, "Mario"),
            new MushroomMaster("Waluigi", 1, "Luigi")
            };

            Menu(mushroomMasters);
        }

        static void Menu(List<MushroomMaster> mushroomMasters)
        {
            bool running = true;
            while (running)
            {
                PrintMenu();

                Console.Write("Please only enter [1,2,3,4,5,6,D] or Q to quit: ");
                string userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "1":
                        AddMushroomCharacter();
                        break;
                    case "2":
                        ListMushroom();
                        break;
                    case "3":
                        CheckTransform(mushroomMasters);
                        break;
                    case "4":
                        Transform(mushroomMasters);
                        break;
                    case "5":
                        ListMushroomId();
                        break;
                    case "6":
                        Battle();
                        break;
                    case "d":
                        DeleteAll();
                        break;
                    case "q":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Welcome to Mushroom Pocket App");
            Console.WriteLine("*****************************");
            Console.WriteLine("(1). Add Mushroom's character to my pocket");
            Console.WriteLine("(2). List character(s) in my Pocket");
            Console.WriteLine("(3). Check if I can transform my characters");
            Console.WriteLine("(4). Transforms Mushroom Characters");
            Console.WriteLine("(5). List Mushroom Characters in my Pocket (with sorted IDs)");
            Console.WriteLine("(6). Fight Bowser!");
            Console.WriteLine("(D). Remove All Mushroom Characters in my pocket");
        }

        public static void AddMushroomCharacter()
        {
            string name;
            int hp;
            int exp;



            for (; ; )
            {
                Console.Write("Enter Mushroom Character's Name: ");
                name = Console.ReadLine();
                if (name.ToLower() == "waluigi"
                        || name.ToLower() == "daisy"
                        || name.ToLower() == "wario")
                    break;
                Console.WriteLine("You can only add Waluigi, Daisy, Wario");
            }


            for (; ; )
            {
                Console.Write("Enter Mushroom Character's HP: ");
                while (!Int32.TryParse(Console.ReadLine(), out hp))
                    Console.Write("HP must be an integer! Try again: ");
                if (hp >= 0 && hp <= 1000)
                    break;
                if (hp >= 1000)
                {
                    Console.WriteLine("Maximum HP is 1000!");
                    continue;
                }
                Console.WriteLine("HP must be 0 or positive!");
            }

            for (; ; )
            {
                Console.Write("Enter Mushroom Character's Exp: ");
                while (!Int32.TryParse(Console.ReadLine(), out exp))
                    Console.Write("Exp must be an integer! Try again: ");
                if (exp >= 0)
                    break;
                Console.WriteLine("Exp must be 0 or positive!");
            }
            Dictionary<string, string> ability = new Dictionary<string, string>(){
                {"waluigi", "agility"},
                {"daisy", "leadership"},
                {"wario", "strength"},
                {"luigi", "precision and accuracy"},
                {"peach", "magic abilities"},
                {"mario", "combat skills"},
            };
            ability.TryGetValue(name.ToLower(), out string abilityName);
            var MushroomAdd = MushroomService.AddMushroom(name, hp, exp, abilityName);
            if (MushroomAdd == true)
                Console.WriteLine("Successfully added Mushroom Character!\n");
            else
                Console.WriteLine("Failed to add Mushroom Character.\n");
        }

        public static void ListMushroom()
        {
            using (var context = new MushroomDbContext())
            {
                // Assuming MushroomCharacter has a Name property
                var characterList = context.MushroomCharacters.Select(x => x).ToList();
                characterList.Sort((x, y) => y.Hp.CompareTo(x.Hp));

                if (characterList.Any()) // Check if there are any characters before printing
                {
                    foreach (var character in characterList)
                    {
                        Console.WriteLine($"Name: {character.Name}\nHealth: {character.Hp}\nExp: {character.Exp}\nSkill: {character.Skill}\n"); // Print only the name
                    }
                }
                else
                {
                    Console.WriteLine("No mushroom characters found!");
                }



            }
        }
        public static void ListMushroomId()
        {
            using (var context = new MushroomDbContext())
            {
                // Assuming MushroomCharacter has a Name property
                var characterList = context.MushroomCharacters.Select(x => x).ToList();
                characterList.Sort((x, y) => x.Id.CompareTo(y.Id));

                if (characterList.Any()) // Check if there are any characters before printing
                {
                    foreach (var character in characterList)
                    {
                        Console.WriteLine($"Name: {character.Name}\nId: {character.Id}\nHealth: {character.Hp}\nExp: {character.Exp}\nSkill: {character.Skill}\n"); // Print only the name
                    }
                }
                else
                {
                    Console.WriteLine("No mushroom characters found!");
                }



            }
        }

        public static void CheckTransform(List<MushroomMaster> mushroomMasters)
        {
            using (var context = new MushroomDbContext())
            {
                // Assuming MushroomCharacter has a Name property
                var characterList = context.MushroomCharacters.Select(x => x).ToList();
                var mushroomCount = characterList.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => g.Count());
                if (characterList.Any()) // Check if there are any characters before printing
                {
                    var processedNames = new HashSet<string>();

                    foreach (var character in characterList)
                    {
                        if (!processedNames.Contains(character.Name))
                        {
                            List<string> nameList = new List<string>()
                            {
                                "daisy",
                                "waluigi",
                                "wario"
                            };
                            if (nameList.Contains(character.Name.ToLower()))
                            {
                                var e = mushroomMasters.Find(x => x.Name == character.Name).NoToTransform;

                                if (mushroomCount[character.Name] >= e)
                                {
                                    if (processedNames.Add(character.Name))
                                    {
                                        Console.WriteLine($"{character.Name} --> {mushroomMasters.Find(x => x.Name == character.Name).TransformTo}");
                                    }
                                }
                                else
                                {
                                    if (processedNames.Add(character.Name))
                                    {
                                        Console.WriteLine("No Transformation Available");
                                    }
                                }
                            }


                        }
                    }
                }
                else
                {
                    Console.WriteLine("No mushroom characters found!");
                }



            }
        }

        public static void Transform(List<MushroomMaster> mushroomMasters)
        {
            using (var context = new MushroomDbContext())
            {
                // Assuming MushroomCharacter has a Name property
                var characterList = context.MushroomCharacters.Select(x => x).ToList();
                var mushroomCount = characterList.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => g.Count());
                if (characterList.Any()) // Check if there are any characters before printing
                {
                    var processedNames = new HashSet<string>();
                    List<string> nameList = new List<string>()
                            {
                                "daisy",
                                "waluigi",
                                "wario"
                            };

                    foreach (var character in characterList)
                    {
                        if (!processedNames.Contains(character.Name))
                        {
                            if (nameList.Contains(character.Name.ToLower()))
                            {
                                if (mushroomCount[character.Name] >= mushroomMasters.Find(x => x.Name == character.Name).NoToTransform)
                                {
                                    Dictionary<string, string> transformCharacterAbilities = new Dictionary<string, string>()
                                {
                                    {"peach", "magic abilities"},
                                    {"luigi", "precision and accuracy"},
                                    {"mario", "combat skills"},
                                };
                                    var transformName = new MushroomCharacter
                                    {
                                        Name = mushroomMasters.Find(x => x.Name == character.Name).TransformTo,
                                        Hp = 100,
                                        Exp = 0,
                                        Skill = transformCharacterAbilities.TryGetValue(mushroomMasters.Find(x => x.Name == character.Name).TransformTo.ToLower(), out var skill) ? skill : ""
                                    };


                                    context.MushroomCharacters.Add(transformName);

                                    var characterFind = mushroomMasters.Where(x => x.Name == character.Name).ToList();
                                    context.MushroomCharacters.RemoveRange(context.MushroomCharacters.ToList().Where(x => x.Name == character.Name).Take(mushroomMasters.Find(x => x.Name == character.Name).NoToTransform).ToList());
                                    context.SaveChanges();
                                    Console.WriteLine($"{character.Name} has transformed to {mushroomMasters.Find(x => x.Name == character.Name).TransformTo}");
                                }

                            }

                            processedNames.Add(character.Name);

                        }
                    }
                }
                else
                {
                    Console.WriteLine("No mushroom characters found!");
                }



            }
        }

        public static void DeleteAll()
        {
            Console.WriteLine("Are you sure? (Y/N)");
            string confirm = Console.ReadLine().ToLower();
            bool sure = false;
            if (confirm == "y")
            {
                sure = true;
                if (sure)
                {
                    using (var context = new MushroomDbContext())
                    {
                        context.MushroomCharacters.RemoveRange(context.MushroomCharacters.ToList());
                        context.SaveChanges();
                        Console.WriteLine("All Characters Removed.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Removal Aborted.");
            }

        }
        public static void Battle()
        {
            Console.WriteLine("You face a Bowser!");
            using (var context = new MushroomDbContext())
            {
                context.MushroomCharacters.RemoveRange(context.MushroomCharacters.ToList());
                context.SaveChanges();
                Console.WriteLine("Oops... he is too powerful... all characters died... and the princess is in another castle!");
            }
        }
    }
}