using System;
using System.Collections.Generic;
using System.Linq;

namespace MushroomPocket
{
    /// <summary>
    /// Mushroom service layer singleton
    /// </summary>
    public class MushroomService
    {
        #region Singleton
        private static MushroomService instance = null;
        public static MushroomService GetInstance()
        {
            if (instance == null)
                instance = new MushroomService();
            return instance;
        }
        private MushroomService() { }
        #endregion

        /// <summary>
        /// A list to check evolution ability.
        /// </summary>
        public List<MushroomMaster> Masters { get; set; } = new List<MushroomMaster>();
        /// <summary>
        /// A property to retrieve a list of all Mushrooms.
        /// </summary>
        // public List<Mushroom> Mushrooms { get; private set; } = new List<Mushroom>();
        public List<MushroomCharacter> Mushrooms
        {
            get
            {
                using (MushroomDbContext dbctx = new MushroomDbContext())
                {
                    List<MushroomCharacter> ret = (from p in dbctx.MushroomCharacters
                                                   select p).ToList();
                    return ret;
                }
            }
        }

        /// <summary>
        /// HP and EXP only applicable for Pikachu, Eevee, Charmander
        /// </summary>
        public static MushroomCharacter MushroomFactory(string MushroomName, int hp = 0, int exp = 0, string skill = "")
        {
            MushroomCharacter Mushroom;

            switch (MushroomName.ToLower())
            {
                case "waluigi":
                    Mushroom = new Waluigi(hp, exp, skill);
                    break;
                case "daisy":
                    Mushroom = new Daisy(hp, exp, skill);
                    break;
                case "wario":
                    Mushroom = new Wario(hp, exp, skill);
                    break;
                case "luigi":
                    Mushroom = new Luigi(hp, exp, skill);
                    break;
                case "peach":
                    Mushroom = new Peach(hp, exp, skill);
                    break;
                case "mario":
                    Mushroom = new Mario(hp, exp, skill);
                    break;
                default:
                    return null;
            }

            return Mushroom;
        }

        /// <summary>
        /// Return success of adding a Mushroom by specifying name.
        /// </summary>
        public static bool AddMushroom(string name, int hp, int exp, string skill)
        {
            name = name.ToLower();
            if (name == "waluigi" || name == "daisy" || name == "wario")
            {
                // Mushrooms.Add(MushroomFactory(name, hp, exp));
                MushroomCharacter Mushroom = MushroomFactory(name, hp, exp, skill);
                using (var dbctx = new MushroomDbContext())
                {
                    dbctx.MushroomCharacters.Add(Mushroom);
                    dbctx.SaveChanges();
                    dbctx.Dispose();
                }
                return true;
            }
            return false;
        }
    }
}