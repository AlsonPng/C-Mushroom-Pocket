/*
 * Name: Ashlee Tan
 * Admin number: 211362G
 */

using System;

namespace MushroomPocket
{
    /// <summary>
    /// Base pokemon class
    /// </summary>
    public class MushroomCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Exp { get; set; }
        public string Skill { get; set; }
        public MushroomCharacter()
        {
        }
        public MushroomCharacter(string name, int hp, int exp, string skill)
        {
            Name = name;
            Hp = hp;
            Exp = exp;
            Skill = skill;
        }
    }

}