using ContinuousEffects;

namespace Cards.DM10
{
    sealed class BalzaSeekerOfHyperpearls : Engine.Creature
    {
        public BalzaSeekerOfHyperpearls() : base("Balza, Seeker of Hyperpearls", 8, 4000, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
