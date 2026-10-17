using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM08;

public sealed class TottoPipicchi : Creature
{
    public TottoPipicchi(
        DragonFilter dragonFilter,
        EachCreatureHasAbilityEffectFactory factory,
        SpeedAttackerAbilityFactory speedAttackerAbilityFactory)
        : base("Totto Pipicchi", 3, 1000, Race.FireBird, Civilization.Fire)
    {
        AddStaticAbilities(
            factory.Create(
                dragonFilter,
                speedAttackerAbilityFactory.Create()
            ));
    }
}
