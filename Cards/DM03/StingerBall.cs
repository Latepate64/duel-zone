using TriggeredAbilities;

namespace Cards.DM03
{
    class StingerBall : Engine.Creature
    {
        public StingerBall() : base("Stinger Ball", 3, 1000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect()));
        }
    }
}
