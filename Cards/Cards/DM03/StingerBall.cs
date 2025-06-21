using TriggeredAbilities;

namespace Cards.Cards.DM03
{
    class StingerBall : Engine.Creature
    {
        public StingerBall() : base("Stinger Ball", 3, 1000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect()));
        }
    }
}
