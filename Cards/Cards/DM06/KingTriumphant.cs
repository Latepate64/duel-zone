using Common;

namespace Cards.Cards.DM06
{
    class KingTriumphant : Creature
    {
        public KingTriumphant() : base("King Triumphant", 8, 7000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
