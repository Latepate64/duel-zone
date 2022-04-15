using Common;

namespace Cards.Cards.DM03
{
    class StingerBall : Creature
    {
        public StingerBall() : base("Stinger Ball", 3, 1000, Engine.Subtype.CyberVirus, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect());
        }
    }
}
