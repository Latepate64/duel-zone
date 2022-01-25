using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    class Meteosaur : Creature
    {
        public Meteosaur() : base("Meteosaur", 5, Civilization.Fire, 2000, Subtype.RockBeast)
        {
            // When you put this creature into the battle zone, you may destroy 1 of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 0, 1, true)));
        }
    }
}
