using DuelMastersCards.CardFilters;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.Cards.DM08
{
    class MegariaEmpressOfDread : Creature
    {
        public MegariaEmpressOfDread() : base("Megaria, Empress of Dread", 5, Civilization.Darkness, 5000, Subtype.DarkLord)
        {
            // Each creature in the battle zone has "slayer." (Whenever a creature that has "slayer" battles, destroy the other creature after the battle.)
            Abilities.Add(new StaticAbility(new AbilityGrantingEffect(new BattleZoneCreatureFilter(), new Indefinite(), new SlayerAbility())));
        }
    }
}
