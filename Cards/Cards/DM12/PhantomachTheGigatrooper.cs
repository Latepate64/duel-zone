using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class PhantomachTheGigatrooper : EvolutionCreature
    {
        public PhantomachTheGigatrooper() : base("Phantomach, the Gigatrooper", 5, 6000, Race.Chimera, Race.Armorloid, Civilization.Darkness, Civilization.Fire)
        {
            AddStaticAbilities(new PhantomachPowerEffect(), new PhantomachDoubleBreakerEffect());
        }
    }

    class PhantomachPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public PhantomachPowerEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PhantomachPowerEffect();
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(GetController(game).Id).Where(x => !IsSourceOfAbility(x, game) && (x.HasRace(Race.Chimera) || x.HasRace(Race.Armorloid))).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "Each of your other Chimeras and Armorloids in the battle zone gain +2000 power.";
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id, Race.Chimera, Race.Armorloid);
        }
    }
}
