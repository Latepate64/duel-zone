using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect() : base()
        {
        }

        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, return it to your hand instead.";
        }

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }

        protected override List<Engine.ICard> GetAffectedCards(IGame game)
        {
            return new List<Engine.ICard> { GetSourceCard(game) };
        }
    }

    abstract class WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : DestructionReplacementEffect
    {
        protected WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
        {
        }

        protected WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect() : base()
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player, Engine.ICard card)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, card);
            return true;
        }

        protected abstract List<Engine.ICard> GetAffectedCards(IGame game);
    }
}