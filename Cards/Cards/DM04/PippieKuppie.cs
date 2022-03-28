using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class PippieKuppie : Creature
    {
        public PippieKuppie() : base("Pippie Kuppie", 2, 1000, Subtype.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new PippieKuppieEffect());
        }
    }

    class PippieKuppieEffect : PowerModifyingEffect
    {
        public PippieKuppieEffect(PippieKuppieEffect effect) : base(effect)
        {
        }

        public PippieKuppieEffect() : base(1000, new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.ArmoredDragon), new Durations.Indefinite())
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PippieKuppieEffect(this);
        }

        public override string ToString()
        {
            return "Each Armored Dragon in the battle zone gets +1000 power.";
        }
    }
}
