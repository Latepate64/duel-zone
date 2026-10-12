using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

sealed class BoomerangComet : Charger
{
    public BoomerangComet() : base("Boomerang Comet", 6, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new ManaRecoveryEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                ownMana: true
        ));
    }
}