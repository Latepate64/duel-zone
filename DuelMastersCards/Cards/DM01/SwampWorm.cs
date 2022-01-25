using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    class SwampWorm : Creature
    {
        public SwampWorm() : base("Swamp Worm", 7, Civilization.Darkness, 2000, Subtype.ParasiteWorm)
        {
            // When you put this creature into the battle zone, your opponent chooses 1 of his creatures and destroys it.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyEffect(new OpponentsBattleZoneCreatureFilter(), 1, 1, false)));
        }
    }
}
