using TriggeredAbilities;
using Interfaces;
using Abilities.Static;

namespace Cards.DM08
{
    sealed class EmperorQuazla : EvolutionCreature
    {
        public EmperorQuazla() : base("Emperor Quazla", 6, 5000, Race.CyberLord, Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(new OneShotEffects.YouMayDrawUpToTwoCardsEffect()));
        }
    }
}
