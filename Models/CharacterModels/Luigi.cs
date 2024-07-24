using System;

namespace MushroomPocket
{
    public class Luigi : MushroomCharacter
    {


        public Luigi(int hp, int exp, string skill)
        {
            Name = "Luigi";
            Hp = hp;
            Exp = exp;
            Skill = skill;
        }
    }
}