using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class VreemahFreakyMojoTotem : Creature
    {
        public VreemahFreakyMojoTotem() : base("Vreemah, Freaky Mojo Totem", 5, 4000, Subtype.MysteryTotem, Civilization.Nature)
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

    class VreemahFreakyMojoTotemContinuousEffect : ContinuousEffects.GetPowerAndDoubleBreakerEffect
    {
        public VreemahFreakyMojoTotemContinuousEffect() : base(new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.BeastFolk), 2000, new Durations.UntilTheEndOfTheTurn())
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
    }
}
