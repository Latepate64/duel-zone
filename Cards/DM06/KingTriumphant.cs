using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class KingTriumphant : Creature
    {
        public KingTriumphant() : base("King Triumphant", 8, 7000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
