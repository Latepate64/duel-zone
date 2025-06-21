using TriggeredAbilities;

namespace Cards.DM10
{
    class Hurlosaur : Engine.Creature
    {
        public Hurlosaur() : base("Hurlosaur", 6, 2000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(1000)));
        }
    }
}
