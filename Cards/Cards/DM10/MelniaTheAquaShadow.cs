using Cards.StaticAbilities;
using Engine;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    public class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, new List<Civilization> { Civilization.Water, Civilization.Darkness }, 1000, new List<Subtype> { Subtype.LiquidPeople, Subtype.Ghost })
        {
            Abilities.Add(new UnblockableAbility());
            Abilities.Add(new SlayerAbility());
        }
    }
}
