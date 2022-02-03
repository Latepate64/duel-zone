using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class StormShell : Creature
    {
        public StormShell() : base("Storm Shell", 7, Common.Civilization.Nature, 2000, Common.Subtype.ColonyBeetle)
        {
            // When you put this creature into the battle zone, your opponent chooses 1 of his creatures in the battle zone and puts it into his mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ManaFeedEffect(new OpponentsBattleZoneCreatureFilter(), 1, 1, false)));
        }
    }
}
