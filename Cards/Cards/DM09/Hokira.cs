using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM09
{
    class Hokira : Creature
    {
        public Hokira() : base("Hokira", 4, 3000, Race.CyberLord, Civilization.Water)
        {
            AddTapAbility(new HokiraOneShotEffect());
        }
    }

    class HokiraOneShotEffect : OneShotEffect
    {
        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new HokiraContinuousEffect(Applier.ChooseRace(ToString())));
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

    class HokiraContinuousEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect, IExpirable
    {
        private readonly Race _race;

        public HokiraContinuousEffect(Race race) : base()
        {
            _race = race;
        }

        public HokiraContinuousEffect(HokiraContinuousEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public override IContinuousEffect Copy()
        {
            return new HokiraContinuousEffect(this);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return $"Whenever one of your {_race}s would be destroyed this turn, return it to your hand instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return card.Owner == Applier && card.HasRace(_race);
        }
    }
}
