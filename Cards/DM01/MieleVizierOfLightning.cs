using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    class MieleVizierOfLightning : Engine.Creature
    {
        public MieleVizierOfLightning() : base("Miele, Vizier of Lightning", 3, 1000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
