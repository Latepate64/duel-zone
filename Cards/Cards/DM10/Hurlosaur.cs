using Common;

namespace Cards.Cards.DM10
{
    class Hurlosaur : Creature
    {
        public Hurlosaur() : base("Hurlosaur", 6, 2000, Subtype.RockBeast, Civilization.Fire)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(1000));
        }
    }
}
