using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Cards.DM10
{
    class GlaisMejiculaTheExtreme : EvolutionCreature
    {
        public GlaisMejiculaTheExtreme() : base("Glais Mejicula, the Extreme", 2, 5500, Race.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new GlaisMejiculaEffect());
        }
    }

    class GlaisMejiculaEffect : WhenOneOfYourShieldsWouldBeBrokenEffect
    {
        public GlaisMejiculaEffect()
        {
        }

        public GlaisMejiculaEffect(WhenOneOfYourShieldsWouldBeBrokenEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            var e = gameEvent as ShieldsBreakEvent;
            var maximum = Controller.Hand.Size / 2;
            var shields = Controller.ChooseCards(e.Shields, 0, maximum, ToString());
            if (shields.Any())
            {
                var toDiscard = Controller.ChooseCards(Controller.Hand.Cards, 2 * shields.Count(), 2 * shields.Count(), ToString());
                return new GlaisMejiculaEvent(e.Shields.Where(x => x != shields), toDiscard, Ability);
            }
            else
            {
                return gameEvent;
            }
        }

        public override IContinuousEffect Copy()
        {
            return new GlaisMejiculaEffect(this);
        }

        public override string ToString()
        {
            return "Whenever one of your shields would be broken, you may discard 2 cards from your hand instead.";
        }
    }

    class GlaisMejiculaEvent(IEnumerable<ICard> remainingShields, IEnumerable<ICard> discard, IAbility ability) : GameEvent
    {
        private readonly IAbility _ability = ability;
        private readonly IEnumerable<ICard> _discard = discard;
        private readonly IEnumerable<ICard> _remainingShields = remainingShields;

        public override void Happen(IGame game)
        {
            game.Move(_ability, ZoneType.Hand, ZoneType.Graveyard, [.. _discard]);
            game.PutFromShieldZoneToHand(_remainingShields, true, null);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
