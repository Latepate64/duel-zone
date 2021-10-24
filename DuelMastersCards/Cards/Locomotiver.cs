using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Locomotiver : Creature
    {
        public Locomotiver() : base("Locomotiver", 4, Civilization.Darkness, 1000, Subtype.Hedrian)
        {
            ShieldTrigger = true;
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardResolvable()));
        }
    }
}
