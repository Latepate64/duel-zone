using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM12
{
    sealed class PhantomachTheGigatrooper : EvolutionCreature
    {
        public PhantomachTheGigatrooper() : base("Phantomach, the Gigatrooper", 5, 6000, Race.Chimera, Race.Armorloid, Civilization.Darkness, Civilization.Fire)
        {
            AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.Chimera, Race.Armorloid), new PhantomachDoubleBreakerEffect());
        }
    }

    sealed class PhantomachDoubleBreakerEffect : AbilityAddingEffect
    {
        public PhantomachDoubleBreakerEffect() : base(new StaticAbility(new DoubleBreakerEffect()))
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Controller.Id, Race.Chimera, Race.Armorloid);
        }
    }
}
