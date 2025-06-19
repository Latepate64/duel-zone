using Abilities.Triggered;

namespace Cards.Cards.DM08
{
    class BakkraHornTheSilent : Engine.Creature
    {
        public BakkraHornTheSilent() : base("Bakkra Horn, the Silent", 4, 2000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
