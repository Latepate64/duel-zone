using TriggeredAbilities;

namespace Cards.DM08
{
    class ÜberdragonBajula : DragonEvolutionCreature
    {
        public ÜberdragonBajula() : base("Überdragon Bajula", 7, 13000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect()));
        }
    }
}
