using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class TyrantWorm : Creature
    {
        public TyrantWorm() : base("Tyrant Worm", 1, 2000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
