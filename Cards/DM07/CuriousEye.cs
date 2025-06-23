using TriggeredAbilities;

namespace Cards.DM07
{
    sealed class CuriousEye : Creature
    {
        public CuriousEye() : base("Curious Eye", 3, 1000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect()));
        }
    }
}
