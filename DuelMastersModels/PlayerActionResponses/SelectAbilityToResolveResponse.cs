using DuelMastersModels.Abilities;

namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information of an ability player chose to resolve.
    /// </summary>
    public class SelectAbilityToResolveResponse : PlayerActionResponse
    {
        internal NonStaticAbility Ability { get; set; }

        /// <summary>
        /// Creates a ability resolution selection response.
        /// </summary>
        /// <param name="ability">An ability a player chose to resolve.</param>
        public SelectAbilityToResolveResponse(NonStaticAbility ability)
        {
            Ability = ability;
        }
    }
}
