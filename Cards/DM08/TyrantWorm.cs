using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class TyrantWorm : Engine.Creature
    {
        public TyrantWorm() : base("Tyrant Worm", 1, 2000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
