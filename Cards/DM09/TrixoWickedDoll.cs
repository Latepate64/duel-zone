using TriggeredAbilities;

namespace Cards.DM09
{
    sealed class TrixoWickedDoll : Creature
    {
        public TrixoWickedDoll() : base("Trixo, Wicked Doll", 4, 2000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
