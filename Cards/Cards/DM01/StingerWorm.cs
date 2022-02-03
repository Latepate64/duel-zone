using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StingerWorm : Creature
    {
        public StingerWorm() : base("Stinger Worm", 3, Common.Civilization.Darkness, 5000, Common.Subtype.ParasiteWorm)
        {
            // When you put this creature into the battle zone, destroy 1 of your creatures.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true)));
        }
    }
}
