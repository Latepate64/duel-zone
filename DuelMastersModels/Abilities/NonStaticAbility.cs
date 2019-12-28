using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Abilities
{
    /// <summary>
    /// Abstract class for spell, activated and trigger abilities. Non-static abilities are resolvable abilities.
    /// </summary>
    public abstract class NonStaticAbility : Ability
    {
        /// <summary>
        /// Abilities can generate one-shot effects or continuous effects.
        /// </summary>
        public ReadOnlyOneShotEffectCollection Effects { get; private set; }

        /// <summary>
        /// The controller of a triggered ability on the stack (other than a delayed triggered ability) is the player who controlled the ability’s source when it triggered, or, if it had no controller, the player who owned the ability’s source when it triggered.
        /// </summary>
        public Player Controller { get; set; }

        /// <summary>
        /// The source of an ability is the object that generated it. The source of an activated ability on the stack is the object whose ability was activated. The source of a triggered ability (other than a delayed triggered ability) on the stack, or one that has triggered and is waiting to be put on the stack, is the object whose ability triggered.
        /// </summary>
        public Cards.Card Source { get; private set; }

        private int _effectIndex = 0;

        /// <summary>
        /// Used in creating non-static abilities.
        /// </summary>
        /// <param name="effects">Effects the ability generates.</param>
        /// <param name="controller">Player who controls the ability.</param>
        /// <param name="source">Object that generated the ability.</param>
        protected NonStaticAbility(ReadOnlyOneShotEffectCollection effects, Player controller, Cards.Card source)
        {
            Effects = effects;
            Controller = controller;
            Source = source;
        }

        /// <summary>
        /// Applies the next effect generated due to the resolution of the ability. Returns null after all effects of the ability have been applied.
        /// </summary>
        /// <param name="duel"></param>
        /// <returns></returns>
        public PlayerActionWithEndInformation ContinueResolution(Duel duel)
        {
            return _effectIndex < Effects.Count
                ? new PlayerActionWithEndInformation(Effects[_effectIndex++].Apply(duel, Controller), false)
                : new PlayerActionWithEndInformation(null, true);
            //TODO: consider all effects.
            //return PlayerActions[0].Apply(duel, player);
            //return Effects.Apply(duel, player);
        }
    }

    public class PlayerActionWithEndInformation
    {
        public PlayerActionWithEndInformation(PlayerAction playerAction, bool end)
        {
            PlayerAction = playerAction;
            End = end;
        }

        public PlayerAction PlayerAction { get; private set; }
        public bool End { get; private set; }
    }
}
