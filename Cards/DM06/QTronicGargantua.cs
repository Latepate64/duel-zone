using Abilities.Static;
using CardFilters;
using Interfaces;

namespace Cards.DM06;

sealed class QTronicGargantua : EvolutionCreature
{
    public QTronicGargantua() : base("Q-tronic Gargantua", 6, 9000,
        Race.Survivor, Civilization.Fire)
    {
        AddAbilities(new CrewBreakerAbility(new RaceCreatureFilter(
            Race.Survivor)));
    }
}