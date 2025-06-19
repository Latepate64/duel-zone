using Abilities.Triggered;
using Cards.OneShotEffects;
using Abilities.Triggered;

namespace Cards.Cards.DM01
{
    class MieleVizierOfLightning : Engine.Creature
    {
        public MieleVizierOfLightning() : base("Miele, Vizier of Lightning", 3, 1000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
