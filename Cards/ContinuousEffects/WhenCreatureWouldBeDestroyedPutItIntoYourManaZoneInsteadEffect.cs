using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect
    {
        protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(CardFilter filter) : base(filter)
        {
        }

        protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player)
        {
            //game.Move(ZoneType.BattleZone, ZoneType.ManaZone, GetAffectedCards(game).ToArray());
            return true;
        }
    }

    class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base(new TargetFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, put it into your mana zone instead.";
        }
    }
}