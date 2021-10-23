using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class WindmillMutant : Creature
    {
        public WindmillMutant() : base("Windmill Mutant", 3, Civilization.Darkness, 2000, Subtype.Hedrian)
        {
            Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardResolvable()));
        }
    }
}
