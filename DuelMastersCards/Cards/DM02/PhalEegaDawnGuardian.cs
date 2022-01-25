using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class PhalEegaDawnGuardian : Creature
    {
        public PhalEegaDawnGuardian() : base("Phal Eega, Dawn Guardian", 5, Civilization.Light, 4000, Subtype.Guardian)
        {
            // When you put this creature into the battle zone, you may return a spell from your graveyard to your hand.
            Abilities.Add(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SalvageEffect(new CardFilters.OwnersGraveyardSpellFilter(), 0, 1, true)));
        }
    }
}
