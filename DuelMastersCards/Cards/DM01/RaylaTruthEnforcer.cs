using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class RaylaTruthEnforcer : Creature
    {
        public RaylaTruthEnforcer() : base("Rayla, Truth Enforcer", 6, Civilization.Light, 3000, Subtype.Berserker)
        {
            // When you put this creature into the battle zone, search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchDeckEffect(new OwnersDeckCardFilter { CardType = CardType.Spell }, true)));
        }
    }
}
