using Abilities.Static;
using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

sealed class ArmoredRaiderGandaval : EvolutionCreature
{
    public ArmoredRaiderGandaval() : base("Armored Raider Gandaval", 5, 6000,
        Race.Human, Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
                2000, new TappedCreatureFilter()));
        AddAbilities(new DoubleBreakerAbility());
    }
}