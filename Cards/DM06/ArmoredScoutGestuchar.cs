using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM06;

public sealed class ArmoredScoutGestuchar : Creature
{
    public ArmoredScoutGestuchar() : base("Armored Scout Gestuchar", 5, 4000,
        Race.Armorloid, Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileYouControlNoOtherCreaturesThisCreatureHasAbilitiesEffect(
                new CivilizationCreatureFilter(Civilization.Fire),
                new StaticAbility(new PowerAttackerEffect(3000)),
                new DoubleBreakerAbility()
            ));
    }
}
