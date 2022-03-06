using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class Meteosaur : Creature
    {
        public Meteosaur() : base("Meteosaur", 5, 2000, Common.Subtype.RockBeast, Common.Civilization.Fire)
        {
            // When you put this creature into the battle zone, you may destroy 1 of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new PutIntoPlayAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 0, 1, true)));
        }
    }
}
