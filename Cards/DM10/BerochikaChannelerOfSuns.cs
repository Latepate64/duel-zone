using TriggeredAbilities;

namespace Cards.DM10
{
    sealed class BerochikaChannelerOfSuns : Creature
    {
        public BerochikaChannelerOfSuns() : base("Berochika, Channeler of Suns", 5, 5000, Interfaces.Race.MechaDelSol, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new AncientHornTheWatcherAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()));
        }
    }
}
