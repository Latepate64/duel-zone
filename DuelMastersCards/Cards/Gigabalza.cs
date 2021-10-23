using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Gigabalza : Creature
    {
        public Gigabalza() : base("Gigabalza", 4, Civilization.Darkness, 1000, Subtype.Chimera)
        {
            ShieldTrigger = true;
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardResolvable()));
        }
    }
}
