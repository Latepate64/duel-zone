using Common;

namespace Cards.Cards.DM08
{
    class GachackMechanicalDoll : Creature
    {
        public GachackMechanicalDoll() : base("Gachack, Mechanical Doll", 3, 2000, Subtype.DeathPuppet, Civilization.Darkness)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.YouMayDestroyCreatureEffect()));
        }
    }
}
