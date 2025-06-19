using Engine;
using System.Collections.Generic;

namespace Cards
{
    class Creature : Engine.Creature
    {
        protected Creature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : base(
            tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, [race])
        {
        }

        protected Creature(string name, int manaCost, int power, List<Race> races, params Civilization[] civilizations)
            : base(tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, races)
        {
        }
    }
}
