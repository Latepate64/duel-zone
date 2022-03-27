using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    public class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility() : base(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(new TargetFilter()))
        {
        }
    }

    class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect : DestructionReplacementEffect
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(CardFilter filter) : base(filter)
        {
        }

        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(this);
        }

        public override bool Apply(IGame game, Engine.IPlayer player)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, GetAffectedCards(game).ToArray());
            return true;
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, return it to your hand instead.";
        }
    }
}
