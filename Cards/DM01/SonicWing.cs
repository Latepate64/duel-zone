using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class SonicWing : Spell
{
    public SonicWing() : base("Sonic Wing", 3, Civilization.Light)
    {
        AddSpellAbilities(
            new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(
                new CreatureFilter(),
                new ChosenCreaturesCannotBeBlockedThisTurnEffectFactory()
            ));
    }
}
