using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyAreaOfEffect : CardMovingAreaOfEffect
    {
        public DestroyAreaOfEffect(DestroyAreaOfEffect effect) : base(effect)
        {
        }

        public DestroyAreaOfEffect(ICardFilter filter) : base(ZoneType.BattleZone, ZoneType.Graveyard, filter)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Destroy {Filter}.";
        }
    }
}
