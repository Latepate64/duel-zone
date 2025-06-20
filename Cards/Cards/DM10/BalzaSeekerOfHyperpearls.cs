using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM10
{
    class BalzaSeekerOfHyperpearls : Engine.Creature
    {
        public BalzaSeekerOfHyperpearls() : base("Balza, Seeker of Hyperpearls", 8, 4000, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
