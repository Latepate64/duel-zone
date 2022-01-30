using Engine;

namespace Cards.Cards.DM02
{
    class FortressShell : Creature
    {
        public FortressShell() : base("Fortress Shell", 9, Civilization.Nature, 5000, Subtype.ColonyBeetle)
        {
            // When you put this creature into the battle zone, choose up to 2 cards in your opponent's mana zone and put them into his graveyard.
            Abilities.Add(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ManaBurnEffect(new CardFilters.OpponentsManaZoneCardFilter(), 0, 2, true)));
        }
    }
}
