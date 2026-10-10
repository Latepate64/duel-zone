using Abilities.Static;
using CardFilters;
using Interfaces;

namespace Cards.Promo;

sealed class ÜberdragonZaschack : EvolutionCreature
{
    public ÜberdragonZaschack() : base("Überdragon Zaschack", 9, 11000,
        Race.ArmoredDragon, Civilization.Fire)
    {
        AddAbilities(new CrewBreakerAbility(new RaceCreatureFilter(
            Race.ArmoredDragon)));
    }
}