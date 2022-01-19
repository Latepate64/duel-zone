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

        public override string ToString(Duel duel)
        {
            return $"{Ability} triggered, {Ability.OneShotEffect} is waiting to be resolved.";
        }
    }
}
