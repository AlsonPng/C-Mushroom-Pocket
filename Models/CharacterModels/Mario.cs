using System;

namespace MushroomPocket
{
    public class Mario : MushroomCharacter
    {


        public Mario(int hp, int exp, string skill)
        {
            Name = "Mario";
            Hp = hp;
            Exp = exp;
            Skill = skill;
        }
    }
}