using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class SpiralGate : Spell
    {
        public SpiralGate() : base("Spiral Gate", 2, Common.Civilization.Water)
        {
            ShieldTrigger = true;

            // Choose 1 creature in the battle zone and return it to its owner's hand.
            AddSpellAbilities(new BounceEffect(1, 1, new CardFilters.BattleZoneChoosableCreatureFilter()));
        }
    }
}
