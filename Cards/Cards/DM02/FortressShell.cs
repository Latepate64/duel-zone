using Abilities.Triggered;
using Abilities.Triggered;

namespace Cards.Cards.DM02
{
    class FortressShell : Engine.Creature
    {
        public FortressShell() : base("Fortress Shell", 9, 5000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect()));
        }
    }
}
