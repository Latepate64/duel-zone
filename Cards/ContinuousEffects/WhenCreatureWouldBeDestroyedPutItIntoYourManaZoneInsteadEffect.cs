using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    abstract class WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect
    {
        protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
        {
        }

        protected WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player, Engine.ICard card)
        {
            game.Move(ZoneType.BattleZone, ZoneType.ManaZone, card);
            return true;
        }
    }

    class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
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

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }
    }
}