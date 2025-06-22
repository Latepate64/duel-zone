using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class KingTriumphant : Engine.Creature
    {
        public KingTriumphant() : base("King Triumphant", 8, 7000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
