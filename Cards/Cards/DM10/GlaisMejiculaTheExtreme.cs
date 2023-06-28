using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM10
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

        public override IGameEvent Apply(IGameEvent gameEvent)
        {
            var e = gameEvent as ShieldsBreakEvent;
            var maximum = Applier.Hand.Cards.Count() / 2;
            var shields = Applier.ChooseCards(e.Shields, 0, maximum, ToString());
            if (shields.Any())
            {
                var toDiscard = Applier.ChooseCards(Applier.Hand.Cards, 2 * shields.Count(), 2 * shields.Count(), ToString());
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

    class GlaisMejiculaEvent : GameEvent
    {
        private readonly IAbility _ability;
        private readonly IEnumerable<ICard> _discard;
        private readonly IEnumerable<ICard> _remainingShields;

        public GlaisMejiculaEvent(IEnumerable<ICard> remainingShields, IEnumerable<ICard> discard, IAbility ability)
        {
            _ability = ability;
            _discard = discard;
            _remainingShields = remainingShields;
        }

        public override void Happen(IGame game)
        {
            game.Move(_ability, ZoneType.Hand, ZoneType.Graveyard, _discard.ToArray());
            game.PutFromShieldZoneToHand(_remainingShields, true, null);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
