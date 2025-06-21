using TriggeredAbilities;

namespace Cards.DM08
{
    class GachackMechanicalDoll : TurboRushCreature
    {
        public GachackMechanicalDoll() : base("Gachack, Mechanical Doll", 3, 2000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddTurboRushAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YouMayDestroyCreatureEffect()));
        }
    }
}
