using Cards.ContinuousEffects;
using Common;
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
        public Hokira() : base("Hokira", 4, 3000, Subtype.CyberLord, Civilization.Water)
        {
            AddTapAbility(new HokiraOneShotEffect());
        }
    }

    class HokiraOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new HokiraContinuousEffect(source.GetController(game).ChooseRace(ToString())));
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

    class HokiraContinuousEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect, IDuration
    {
        private readonly Subtype _subtype;

        public HokiraContinuousEffect(Subtype subtype) : base()
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

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return $"Whenever one of your {_subtype}s would be destroyed this turn, return it to your hand instead.";
        }

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return card.Owner == GetController(game).Id && card.HasSubtype(_subtype);
        }

        protected override List<Engine.ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id, _subtype).ToList();
        }
    }
}
