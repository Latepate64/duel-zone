using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM09
{
    class VreemahFreakyMojoTotem : Creature
    {
        public VreemahFreakyMojoTotem() : base("Vreemah, Freaky Mojo Totem", 5, 4000, Race.MysteryTotem, Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new VreemahFreakyMojoTotemOneShotEffect()));
        }
    }

    class VreemahFreakyMojoTotemOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new VreemahFreakyMojoTotemContinuousEffect());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new VreemahFreakyMojoTotemOneShotEffect();
        }

        public override string ToString()
        {
            return "Each Beast Folk in the battle zone gets +2000 power and \"double breaker\" until the end of the turn.";
        }
    }

    class VreemahFreakyMojoTotemContinuousEffect : ContinuousEffects.GetPowerAndDoubleBreakerEffect, IDuration
    {
        public VreemahFreakyMojoTotemContinuousEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new VreemahFreakyMojoTotemContinuousEffect();
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return "Each Beast Folk in the battle zone gets +2000 power and \"double breaker\" until the end of the turn.";
        }

        protected override List<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.Creatures.Where(x => x.HasRace(Race.BeastFolk)).ToList();
        }
    }
}
