using DuelMastersModels.Abilities;

namespace DuelMastersModels.PlayerActionResponses
{
    public class SelectAbilityToResolveResponse : PlayerActionResponse
    {
        public NonStaticAbility Ability { get; set; }

        public SelectAbilityToResolveResponse(NonStaticAbility ability)
        {
            Ability = ability;
        }
    }
}
