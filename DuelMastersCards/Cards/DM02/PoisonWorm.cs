using DuelMastersModels;

namespace Cards.Cards.DM02
{
    class PoisonWorm : Creature
    {
        public PoisonWorm() : base("Poison Worm", 4, Civilization.Darkness, 4000, Subtype.ParasiteWorm)
        {
            // When you put this creature into the battle zone, destroy one of your creatures that has power 3000 or less.
            Abilities.Add(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyEffect(new CardFilters.OwnersBattleZoneMaxPowerCreatureFilter(3000), 1, 1, true)));
        }
    }
}
