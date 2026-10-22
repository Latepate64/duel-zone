using Abilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class Hokira : Creature
{
    public Hokira() : base("Hokira", 4, 3000, Race.CyberLord,
        Civilization.Water)
    {
        AddAbilities(
            new TapAbility(
                new RaceAffectingContinuousEffectAddingEffect(
                    new HokiraContinuousEffectFactory(),
                    new UntilEndOfThisTurnDuration()
                )));
    }
}
