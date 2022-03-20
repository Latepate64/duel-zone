using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class Teleportation : Spell
    {
        public Teleportation() : base("Teleportation", 5, Common.Civilization.Water)
        {
            // Choose up to 2 creatures in the battle zone and return them to their owners' hands.
            AddSpellAbilities(new BounceEffect(0, 2, new CardFilters.BattleZoneChoosableCreatureFilter()));
        }
    }
}
