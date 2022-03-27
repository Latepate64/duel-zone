using Common;

namespace Cards.Cards.DM03
{
    class Shtra : Creature
    {
        public Shtra() : base("Shtra", 4, 2000, Subtype.CyberLord, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.MutualManaRecoveryEffect(1)));
        }
    }
}
