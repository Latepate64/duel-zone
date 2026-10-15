using ContinuousEffects.Replacement;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class FruitOfEternity : Spell
{
    public FruitOfEternity() : base("Fruit of Eternity", 4, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new ContinuousEffectAddingEffect(
                new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect()
            )
        );
    }
}