using DuelMastersModels.Effects.ContinuousEffects;

namespace DuelMastersModels.Abilities.Static
{
    /// <summary>
    /// Static abilities do something all the time rather than being activated or triggered. They are written as statements, and they’re simply true.
    /// </summary>
    internal abstract class StaticAbility : Ability
    {
        /// <summary>
        /// Static abilities create continuous effects, some of which are prevention effects or replacement effects. These effects are active as long as the card with the ability remains on the battle zone and has the ability, or as long as the card with the ability remains in the appropriate zone.
        /// </summary>
        internal ReadOnlyContinuousEffectCollection ContinuousEffects { get; private set; }

        /// <summary>
        /// Creates a static ability.
        /// </summary>
        /// <param name="source">Source of the ability.</param>
        /// <param name="continuousEffect">Continuous effect created by the ability.</param>
        protected StaticAbility(Cards.Card source, ContinuousEffect continuousEffect) : base(source)
        {
            ContinuousEffects = new ReadOnlyContinuousEffectCollection(continuousEffect);
        }
    }
}
