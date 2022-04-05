using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class PhantomachTheGigatrooper : EvolutionCreature
    {
        public PhantomachTheGigatrooper() : base("Phantomach, the Gigatrooper", 5, 6000, Subtype.Chimera, Subtype.Armorloid, Civilization.Darkness, Civilization.Fire)
        {
            AddStaticAbilities(new PhantomachPowerEffect(), new PhantomachDoubleBreakerEffect());
        }
    }

    class PhantomachPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public PhantomachPowerEffect() : base(new CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter(Subtype.Chimera, Subtype.Armorloid))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PhantomachPowerEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "Each of your other Chimeras and Armorloids in the battle zone gain +2000 power.";
        }
    }

    class PhantomachDoubleBreakerEffect : AbilityAddingEffect
    {
        public PhantomachDoubleBreakerEffect() : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(Subtype.Chimera, Subtype.Armorloid), new StaticAbilities.DoubleBreakerAbility())
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
