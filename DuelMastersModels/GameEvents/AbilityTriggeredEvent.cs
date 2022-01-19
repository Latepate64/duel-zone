using DuelMastersModels.Abilities;

namespace DuelMastersModels.GameEvents
{
    public class AbilityTriggeredEvent : GameEvent
    {
        public TriggeredAbility Ability { get; }

        public AbilityTriggeredEvent(TriggeredAbility ability)
        {
            Ability = ability;
        }

        public override string ToString(Game game)
        {
            return $"{Ability} triggered, {Ability.OneShotEffect} is waiting to be resolved.";
        }
    }
}
