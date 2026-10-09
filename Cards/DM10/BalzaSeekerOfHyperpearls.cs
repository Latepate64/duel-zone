using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM10
{
    sealed class BalzaSeekerOfHyperpearls : Creature
    {
        public BalzaSeekerOfHyperpearls() : base("Balza, Seeker of Hyperpearls", 8, 4000, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
