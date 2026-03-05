using TriggeredAbilities;

namespace Cards.DM03
{
    sealed class StingerBall : Creature
    {
        public StingerBall() : base("Stinger Ball", 3, 1000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect()));
        }
    }
}
