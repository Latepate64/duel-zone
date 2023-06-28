using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM12
{
    class PhantomachTheGigatrooper : EvolutionCreature
    {
        public PhantomachTheGigatrooper() : base("Phantomach, the Gigatrooper", 5, 6000, Race.Chimera, Race.Armorloid, Civilization.Darkness, Civilization.Fire)
        {
            AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.Chimera, Race.Armorloid), new PhantomachDoubleBreakerEffect());
        }
    }

    class PhantomachDoubleBreakerEffect : AbilityAddingEffect
    {
        public PhantomachDoubleBreakerEffect() : base(new StaticAbilities.DoubleBreakerAbility())
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

        protected override IEnumerable<ICard> GetAffectedCards()
        {
            return Game.BattleZone.GetCreatures(Applier, Race.Chimera, Race.Armorloid);
        }
    }
}
