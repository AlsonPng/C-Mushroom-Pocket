using System;

namespace MushroomPocket
{
    public class Waluigi : MushroomCharacter
    {
        public Waluigi(int hp, int exp, string skill)
        {
            Name = "Waluigi";
            Hp = hp;
            Exp = exp;
            Skill = skill;
        }
    }
}