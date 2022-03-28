using Common;

namespace Cards.Cards.DM06
{
    class KingTriumphant : Creature
    {
        public KingTriumphant() : base("King Triumphant", 8, 7000, Subtype.Leviathan, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnOneShotEffect()));
            AddDoubleBreakerAbility();
        }
    }
}
