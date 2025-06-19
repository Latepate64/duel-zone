using Abilities.Triggered;

namespace Cards.Cards.DM10
{
    class Hurlosaur : Engine.Creature
    {
        public Hurlosaur() : base("Hurlosaur", 6, 2000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(1000)));
        }
    }
}
