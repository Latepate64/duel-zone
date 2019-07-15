using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.PlayerActions;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Abilities.Trigger
{
    /// <summary>
    /// 603.1. Triggered abilities have a trigger condition and an effect. They are written as “[When/Whenever/At] [trigger condition or event], [effect]. [Instructions (if any).]”
    /// </summary>
    public class TriggerAbility
    {
        public TriggerCondition TriggerCondition { get; private set; }
        public Collection<OneShotEffect> Effects { get; private set; }

        /// <summary>
        /// 113.8. The controller of a triggered ability on the stack (other than a delayed triggered ability) is the player who controlled the ability’s source when it triggered, or, if it had no controller, the player who owned the ability’s source when it triggered. To determine the controller of a delayed triggered ability, see rules 603.7d–f.
        /// </summary>
        public Player Controller { get; set; }

        private int _effectIndex = 0;

        public TriggerAbility(TriggerCondition triggerCondition, Collection<OneShotEffect> effects)
        {
            TriggerCondition = triggerCondition;
            Effects = effects;
        }

        /// <summary>
        /// Applies the next effect generated due to the resolution of the ability. Returns null after all effects of the ability have been applied.
        /// </summary>
        /// <param name="duel"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public PlayerAction ContinueResolution(Duel duel, out bool resolved)
        {
            if (_effectIndex < Effects.Count)
            {
                resolved = false;
                return Effects[_effectIndex++].Apply(duel, Controller);
            }
            else
            {
                resolved = true;
                return null;
            }
            //TODO: consider all effects.
            //return PlayerActions[0].Apply(duel, player);
            //return Effects.Apply(duel, player);
        }

        /// <summary>
        /// 603.3. Once an ability has triggered, its controller puts it on the stack as an object that’s not a card the next time a player would receive priority.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public TriggerAbility CreatePendingTriggerAbility(Player controller)
        {
            return new TriggerAbility(TriggerCondition, Effects) { Controller = controller };
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
