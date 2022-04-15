using Common;

namespace Cards.Cards.DM09
{
    class TrixoWickedDoll : Creature
    {
        public TrixoWickedDoll() : base("Trixo, Wicked Doll", 4, 2000, Engine.Subtype.DeathPuppet, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
