using System;

namespace MushroomPocket
{
    public class Wario : MushroomCharacter
    {


        public Wario(int hp, int exp, string skill)
        {
            Name = "Wario";
            Hp = hp;
            Exp = exp;
            Skill = skill;
        }
    }
}