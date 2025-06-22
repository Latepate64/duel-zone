using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class FortressShell : Engine.Creature
    {
        public FortressShell() : base("Fortress Shell", 9, 5000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect()));
        }
    }
}
