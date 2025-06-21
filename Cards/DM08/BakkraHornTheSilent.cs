using TriggeredAbilities;

namespace Cards.DM08
{
    class BakkraHornTheSilent : Engine.Creature
    {
        public BakkraHornTheSilent() : base("Bakkra Horn, the Silent", 4, 2000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
