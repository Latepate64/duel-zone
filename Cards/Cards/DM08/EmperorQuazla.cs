using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM08
{
    class EmperorQuazla : EvolutionCreature
    {
        public EmperorQuazla() : base("Emperor Quazla", 6, 5000, Race.CyberLord, Civilization.Water)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(new OneShotEffects.YouMayDrawUpToTwoCardsEffect()));
        }
    }
}
