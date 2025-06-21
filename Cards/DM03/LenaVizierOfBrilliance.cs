using TriggeredAbilities;

namespace Cards.DM03
{
    class LenaVizierOfBrilliance : Engine.Creature
    {
        public LenaVizierOfBrilliance() : base("Lena, Vizier of Brilliance", 4, 2000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect()));
        }
    }
}
