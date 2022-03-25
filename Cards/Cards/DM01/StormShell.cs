using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StormShell : Creature
    {
        public StormShell() : base("Storm Shell", 7, 2000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            // When you put this creature into the battle zone, your opponent chooses 1 of his creatures in the battle zone and puts it into his mana zone.
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new ManaFeedEffect(new OpponentsBattleZoneCreatureFilter(), 1, 1, false)));
        }
    }
}
