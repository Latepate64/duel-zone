using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class MieleVizierOfLightning : Creature
    {
        public MieleVizierOfLightning() : base("Miele, Vizier of Lightning", 3, 1000, Engine.Subtype.Initiate, Common.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect());
        }
    }
}
