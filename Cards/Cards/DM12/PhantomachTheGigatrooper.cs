using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM12
{
    class PhantomachTheGigatrooper : EvolutionCreature
    {
        public PhantomachTheGigatrooper() : base("Phantomach, the Gigatrooper", 5, 6000, Subtype.Chimera, Subtype.Armorloid, Civilization.Darkness, Civilization.Fire)
        {
            AddStaticAbilities(new PhantomachPowerEffect(), new PhantomachDoubleBreakerEffect());
        }
    }

    class PhantomachPowerEffect : PowerModifyingEffect
    {
        public PhantomachPowerEffect() : base(2000, new CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter(Subtype.Chimera, Subtype.Armorloid), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PhantomachPowerEffect();
        }

        public override string ToString()
        {
            return "Each of your other Chimeras and Armorloids in the battle zone gain +2000 power.";
        }
    }

    class PhantomachDoubleBreakerEffect : AbilityAddingEffect
    {
        public PhantomachDoubleBreakerEffect() : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(Subtype.Chimera, Subtype.Armorloid), new Durations.Indefinite(), new StaticAbilities.DoubleBreakerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PhantomachDoubleBreakerEffect();
        }

        public override string ToString()
        {
            return "Each of your Chimeras and Armorloids in the battle zone has \"double breaker.\"";
        }
    }
}
