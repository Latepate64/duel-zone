using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadAbility() : base(new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect())
        {
        }
    }

    class WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect : DestructionReplacementEffect
    {
        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect() : base(new TargetFilter())
        {
        }

        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect(WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect effect) : base(effect)
        {
        }

        public override bool Apply(Game game, Engine.IPlayer player)
        {
            game.Move(ZoneType.BattleZone, ZoneType.ShieldZone, GetAffectedCards(game).ToArray());
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
