using Abilities.Triggered;
using Cards.OneShotEffects;
namespace Cards.Cards.DM08
{
    class ScreamSlicerShadowOfFear : Engine.Creature
    {
        public ScreamSlicerShadowOfFear() : base("Scream Slicer, Shadow of Fear", 6, 4000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(new ScreamSlicerShadowOfFearEffect()));
        }
    }
}
