using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM08;

sealed class TorpedoSkyterror : Creature
{
    public TorpedoSkyterror() : base("Torpedo Skyterror", 5, 4000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileAttackingGetPowerForEachOfYourOtherCreaturesEffect(
                2000, new TappedCreatureFilter()));
    }
}