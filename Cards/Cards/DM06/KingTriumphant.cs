using Abilities.Triggered;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class KingTriumphant : Engine.Creature
    {
        public KingTriumphant() : base("King Triumphant", 8, 7000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
