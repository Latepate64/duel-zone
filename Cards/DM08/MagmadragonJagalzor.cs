using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM08;

sealed class MagmadragonJagalzor : TurboRushCreature
{
    public MagmadragonJagalzor() : base("Magmadragon Jagalzor", 6, 6000,
        Race.VolcanoDragon, Civilization.Fire)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTurboRushAbility(
            new EachOfYourCreaturesHasAbilityEffect(
                new SpeedAttackerAbility(),
                new CreatureFilter()
            ));
    }
}
