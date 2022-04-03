using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class HolyAwe : Spell
    {
        public HolyAwe() : base("Holy Awe", 6, Common.Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new HolyAweEffect());
        }
    }

    class HolyAweEffect : OneShotEffects.TapAreaOfEffect
    {
        public HolyAweEffect() : base(new CardFilters.OpponentsBattleZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new HolyAweEffect();
        }

        public override string ToString()
        {
            return "Tap all your opponent's creatures in the battle zone.";
        }
    }
}
