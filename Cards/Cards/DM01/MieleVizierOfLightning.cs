using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class MieleVizierOfLightning : Creature
    {
        public MieleVizierOfLightning() : base("Miele, Vizier of Lightning", 3, 1000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
