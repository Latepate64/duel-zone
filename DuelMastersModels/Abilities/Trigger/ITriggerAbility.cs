using DuelMastersModels.Cards;

namespace DuelMastersModels.Abilities.TriggerAbilities
{
    public interface ITriggerAbility : INonStaticAbility
    {
        TriggerCondition TriggerCondition { get; set; }

        TriggerAbility CreatePendingTriggerAbility(IPlayer controller, ICard source);
    }
}