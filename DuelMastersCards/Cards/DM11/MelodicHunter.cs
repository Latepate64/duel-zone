using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM11
{
    public class MelodicHunter : Creature
    {
        public MelodicHunter() : base("Melodic Hunter", 5, Civilization.Water, 3000, Subtype.Merfolk)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
