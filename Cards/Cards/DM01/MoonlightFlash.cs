using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class MoonlightFlash : Spell
    {
        public MoonlightFlash() : base("Moonlight Flash", 4, Common.Civilization.Light)
        {
            // Choose up to 2 of your opponent's creatures in the battle zone and tap them.
            AddAbilities(new SpellAbility(new TapChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 0, 2, true)));
        }
    }
}
