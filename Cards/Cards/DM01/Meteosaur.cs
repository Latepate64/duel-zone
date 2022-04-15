using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class Meteosaur : Creature
    {
        public Meteosaur() : base("Meteosaur", 5, 2000, Engine.Subtype.RockBeast, Common.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
