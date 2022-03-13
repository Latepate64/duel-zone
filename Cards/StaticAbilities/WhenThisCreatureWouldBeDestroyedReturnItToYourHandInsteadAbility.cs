using Cards.ContinuousEffects;
using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    public class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility() : base(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect())
        {
        }
    }

    class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : DestructionReplacementEffect
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

        public override bool Apply(Game game, Engine.Player player)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, GetAffectedCards(game).ToArray());
            return true;
        }

        public override string ToString()
        {
            return base.ToString() + "return it to your hand instead.";
        }
    }
}
