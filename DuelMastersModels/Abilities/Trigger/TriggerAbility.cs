//using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.PlayerActions;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Abilities.Trigger
{
    public class TriggerAbility
    {
        public TriggerCondition TriggerCondition { get; private set; }
        public Collection<PlayerAction> PlayerActions { get; private set; }

        public TriggerAbility(TriggerCondition triggerCondition, Collection<PlayerAction> playerActions)
        {
            TriggerCondition = triggerCondition;
            PlayerActions = playerActions;
        }

        public PlayerAction StartResolving(Duel duel, Player player)
        {
            //TODO: consider all effects.
            //return PlayerActions[0].Apply(duel, player);
            return PlayerActions[0];
        }

        public TriggerAbility DeepCopy()
        {
            return new TriggerAbility(TriggerCondition, PlayerActions);
            /*
            var effects = new List<Effect>();
            foreach (var effect in Effects)
            {
                effects.Add(effect.DeepCopy());
            }
            return new TriggerAbility(TriggerCondition, effects);*/
        }
    }
}
