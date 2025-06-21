using TriggeredAbilities;

namespace Cards.Cards.DM10
{
    class BerochikaChannelerOfSuns : Engine.Creature
    {
        public BerochikaChannelerOfSuns() : base("Berochika, Channeler of Suns", 5, 5000, Engine.Race.MechaDelSol, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new AncientHornTheWatcherAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()));
        }
    }
}
