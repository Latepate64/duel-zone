using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ManaRecoveryAreaOfEffect : CardMovingAreaOfEffect
    {
        public ManaRecoveryAreaOfEffect(ManaRecoveryAreaOfEffect effect) : base(effect)
        {
        }

        public ManaRecoveryAreaOfEffect(CardFilter filter) : base(ZoneType.ManaZone, ZoneType.Hand, filter)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ManaRecoveryAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Each player returns {Filter} to his hand.";
        }
    }
}
