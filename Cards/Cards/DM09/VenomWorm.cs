using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class VenomWorm : Creature
    {
        public VenomWorm() : base("Venom Worm", 3, 1000, Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddTapAbility(new VenomWormOneShotEffect());
        }
    }

    class VenomWormOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var race = source.GetController(game).ChooseRace();
            var creatures = game.BattleZone.GetCreatures(source.Controller).Where(x => x.Subtypes.Contains(race)).ToArray();
            game.AddContinuousEffects(source, new VenomWormContinuousEffect(creatures));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new VenomWormOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Each creature of that race gets \"slayer\" until the end of the turn.";
        }
    }

    class VenomWormContinuousEffect : AbilityAddingEffect
    {
        public VenomWormContinuousEffect(VenomWormContinuousEffect effect) : base(effect)
        {
        }

        public VenomWormContinuousEffect(params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new Durations.UntilTheEndOfTheTurn(), new StaticAbilities.SlayerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new VenomWormContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} have \"slayer\" until the end of the turn.";
        }
    }
}
