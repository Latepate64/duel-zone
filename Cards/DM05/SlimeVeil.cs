using ContinuousEffects.AttacksIfAble;
using Interfaces;
using OneShotEffects;

namespace Cards.DM05;

public sealed class SlimeVeil : Spell
{
    public SlimeVeil() : base("Slime Veil", 1, Civilization.Darkness)
    {
        AddSpellAbilities(
            new ForcedFrenzyEffect(
                new SlimeVeilContinuousEffectFactory(),
                new DuringPlayersNextTurnDuration()
            ));
    }
}
