using TriggeredAbilities;
using OneShotEffects;
namespace Cards.DM08
{
    sealed class ScreamSlicerShadowOfFear : Creature
    {
        public ScreamSlicerShadowOfFear() : base("Scream Slicer, Shadow of Fear", 6, 4000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(new ScreamSlicerShadowOfFearEffect()));
        }
    }
}
