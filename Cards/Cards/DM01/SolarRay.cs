using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class SolarRay : Spell
    {
        public SolarRay() : base("Solar Ray", 2, Common.Civilization.Light)
        {
            ShieldTrigger = true;

            // Choose 1 of your opponent's creatures in the battle zone and tap it.
            AddAbilities(new SpellAbility(new TapChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }
}
