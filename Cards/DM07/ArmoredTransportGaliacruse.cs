using Abilities;
using Abilities.Static;
using CardFilters;
using ContinuousEffects.CanAttackUntappedCreatures;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class ArmoredTransportGaliacruse : Creature
{
    public ArmoredTransportGaliacruse() : base("Armored Transport Galiacruse",
        6, 5000, Race.Armorloid, Civilization.Fire)
    {
        AddAbilities(
            new TapAbility(
                new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
                    new StaticAbility(
                        new ThisCreatureCanAttackUntappedCreaturesEffect()),
                    new CivilizationCreatureFilter(Civilization.Fire)
                )));
    }
}
