using Cards.CardFilters;
using Cards.StaticAbilities;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM08
{
    class MegariaEmpressOfDread : Creature
    {
        public MegariaEmpressOfDread() : base("Megaria, Empress of Dread", 5, 5000, Common.Subtype.DarkLord, Common.Civilization.Darkness)
        {
            // Each creature in the battle zone has "slayer." (Whenever a creature that has "slayer" battles, destroy the other creature after the battle.)
            AddAbilities(new StaticAbility(new AbilityGrantingEffect(new BattleZoneCreatureFilter(), new Indefinite(), new SlayerAbility())));
        }
    }
}
