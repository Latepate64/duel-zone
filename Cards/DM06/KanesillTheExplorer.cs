using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM06
{
    sealed class KanesillTheExplorer : Creature
    {
        public KanesillTheExplorer() : base("Kanesill, the Explorer", 3, 4000, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
