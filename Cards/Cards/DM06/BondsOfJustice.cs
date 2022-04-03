using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class BondsOfJustice : Spell
    {
        public BondsOfJustice() : base("Bonds of Justice", 4, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new BondsOfJusticeEffect());
        }
    }

    class BondsOfJusticeEffect : TapAreaOfEffect
    {
        public BondsOfJusticeEffect() : base(new CardFilters.BattleZoneNonBlockerCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BondsOfJusticeEffect();
        }

        public override string ToString()
        {
            return "Tap all creatures in the battle zone that don't have \"blocker.\"";
        }
    }
}
