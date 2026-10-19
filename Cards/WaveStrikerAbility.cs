using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards;

public class WaveStrikerAbility(WaveStrikerEffect effect) :
    StaticAbility(effect), IWaveStrikerAbility
{
}