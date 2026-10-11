using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

sealed class SteamrollerMutant : WaveStrikerCreature
{
    public SteamrollerMutant() : base("Steamroller Mutant", 4, 3000,
        Race.Hedrian, Civilization.Darkness)
    {
        AddWaveStrikerAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyAllCreaturesEffect(new CreatureFilter())));
    }
}