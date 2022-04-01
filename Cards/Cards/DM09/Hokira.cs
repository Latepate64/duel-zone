using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class Hokira : Creature
    {
        public Hokira() : base("Hokira", 4, 3000, Subtype.CyberLord, Civilization.Water)
        {
            AddTapAbility(new HokiraOneShotEffect());
        }
    }

    class HokiraOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new HokiraContinuousEffect(source.GetController(game).ChooseRace()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new HokiraOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Whenever one of your creatures of that race would be destroyed this turn, return it to your hand instead.";
        }
    }

    class HokiraContinuousEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
    {
        private readonly Subtype _subtype;

        public HokiraContinuousEffect(Subtype subtype) : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(subtype), new Durations.UntilTheEndOfTheTurn())
        {
            _subtype = subtype;
        }

        public HokiraContinuousEffect(HokiraContinuousEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public override IContinuousEffect Copy()
        {
            return new HokiraContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"Whenever one of your {_subtype}s would be destroyed this turn, return it to your hand instead.";
        }
    }
}
