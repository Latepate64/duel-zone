using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class BondsOfJustice : Spell
    {
        public BondsOfJustice() : base("Bonds of Justice", 4, Civilization.Light)
        {
            ShieldTrigger = true;
            // Tap all creatures in the battle zone that don't have "blocker."
            Abilities.Add(new SpellAbility(new TapAreaOfEffect(new CardFilters.BattleZoneNonBlockerCreatureFilter())));
        }
    }
}
