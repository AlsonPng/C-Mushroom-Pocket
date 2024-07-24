using System;

namespace MushroomPocket
{
    public class Peach : MushroomCharacter
    {

        public Peach(int hp, int exp, string skill)
        {
            Name = "Peach";
            Hp = hp;
            Exp = exp;
            Skill = skill;
        }
    }
}