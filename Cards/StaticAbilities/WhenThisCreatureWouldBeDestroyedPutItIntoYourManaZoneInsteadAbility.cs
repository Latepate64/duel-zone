using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility() : base(new WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(new TargetFilter()))
        {
        }
    }

    class WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect
    {
        public WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(CardFilter filter) : base(filter)
        {
        }

        public WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(this);
        }

        public override bool Apply(Game game, Engine.Player player)
        {
            game.Move(ZoneType.BattleZone, ZoneType.ManaZone, GetAffectedCards(game).ToArray());
            return true;
        }

        public override string ToString()
        {
            return base.ToString() + "put it into your mana zone instead.";
        }
    }
}
