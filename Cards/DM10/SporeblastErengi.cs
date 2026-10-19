using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class SporeblastErengi : SilentSkillCreature
{
    public SporeblastErengi() : base("Sporeblast Erengi", 4, 4000,
        Race.BalloonMushroom, Civilization.Nature)
    {
        AddSilentSkillAbility(
            new SearchEffect(
                reveal: true,
                filter: new CreatureFilter()
        ));
    }
}