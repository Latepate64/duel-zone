using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, Civilization.Darkness, 3000, Subtype.Chimera)
        {
            // When you put this creature into the battle zone, return up to 2 creatures from your graveyard to your hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SalvageEffect(new OwnersGraveyardCreatureFilter(), 0, 2, true)));
        }
    }
}
