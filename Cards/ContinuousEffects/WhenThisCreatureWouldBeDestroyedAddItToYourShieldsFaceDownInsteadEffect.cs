using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect : DestructionReplacementEffect
    {
        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect() : base(new TargetFilter())
        {
        }

        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect(WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect effect) : base(effect)
        {
        }

        public override bool Apply(IGame game, IPlayer player)
        {
            //game.Move(Common.ZoneType.BattleZone, Common.ZoneType.ShieldZone, GetAffectedCards(game).ToArray());
            return true;
        }

        public override ContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, add it to your shields face down instead.";
        }
    }
}