using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
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
        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new VreemahFreakyMojoTotemContinuousEffect());
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

    class VreemahFreakyMojoTotemContinuousEffect : ContinuousEffects.GetPowerAndDoubleBreakerUntilTheEndOfTheTurnEffect
    {
        public VreemahFreakyMojoTotemContinuousEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new VreemahFreakyMojoTotemContinuousEffect();
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
