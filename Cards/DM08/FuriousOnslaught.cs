using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class FuriousOnslaught : Spell
{
    public FuriousOnslaught() : base("Furious Onslaught", 4, Civilization.Fire)
    {
        AddSpellAbilities(
            new InvincibleUnityOneShotEffect(
                new FuriousOnslaughtContinuousEffectFactory(),
                new RaceCreatureFilter(Race.Dragonoid)
            ));
    }
}
