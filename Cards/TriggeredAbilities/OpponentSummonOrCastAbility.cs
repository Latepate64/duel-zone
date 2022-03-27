using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class OpponentSummonOrCastAbility : TriggeredAbility
    {
        public OpponentSummonOrCastAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public OpponentSummonOrCastAbility(OpponentSummonOrCastAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            var opponent = game.GetOpponent(Controller);
            return gameEvent is CreatureSummonedEvent summon && summon.Player.Id == opponent || gameEvent is SpellCastEvent cast && cast.Player.Id == opponent;
        }

        public override IAbility Copy()
        {
            return new OpponentSummonOrCastAbility(this);
        }

        public override string ToString()
        {
            return $"When your opponent summons a creature or casts a spell, {GetEffectText()}";
        }
    }
}