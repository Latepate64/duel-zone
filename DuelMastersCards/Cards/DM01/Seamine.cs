using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class Seamine : Creature
    {
        public Seamine() : base("Seamine", 6, Civilization.Water, 4000, Subtype.Fish)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
