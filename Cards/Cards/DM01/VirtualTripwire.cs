using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class VirtualTripwire : Spell
    {
        public VirtualTripwire() : base("Virtual Tripwire", 3, Common.Civilization.Water)
        {
            // Choose 1 of your opponent's creatures in the battle zone and tap it.
            AddAbilities(new SpellAbility(new TapChoiceEffect(1, 1, true)));
        }
    }
}
