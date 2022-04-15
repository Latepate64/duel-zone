using Common;

namespace Cards.Cards.DM08
{
    class TyrantWorm : Creature
    {
        public TyrantWorm() : base("Tyrant Worm", 1, 2000, Engine.Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
