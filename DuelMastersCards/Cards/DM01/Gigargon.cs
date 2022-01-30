using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, Civilization.Darkness, 3000, Subtype.Chimera)
        {
            // When you put this creature into the battle zone, return up to 2 creatures from your graveyard to your hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SalvageEffect(new OwnersGraveyardCardFilter { CardType = CardType.Creature }, 0, 2, true)));
        }
    }
}
