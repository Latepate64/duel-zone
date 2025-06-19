using Abilities.Triggered;

namespace Cards.Cards.DM09
{
    class TrixoWickedDoll : Engine.Creature
    {
        public TrixoWickedDoll() : base("Trixo, Wicked Doll", 4, 2000, Engine.Race.DeathPuppet, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
