using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class AttackPlayerAbility : AttackAbility
    {
        public AttackPlayerAbility(OneShotEffect effect) : base(effect)
        {
        }

        public AttackPlayerAbility(AttackAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e && e.Attackable == game.GetOpponent(Owner);
        }

        public override Ability Copy()
        {
            return new AttackPlayerAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever {Filter} attacks a player, {ToStringBase()}";
        }
    }
}
