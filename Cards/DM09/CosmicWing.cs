using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

sealed class CosmicWing : Spell
{
    public CosmicWing() : base("Cosmic Wing", 3, Civilization.Light)
    {
        AddSpellAbilities(
            new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(
                new CreatureFilter(),
                new ChosenCreaturesCannotBeBlockedThisTurnEffectFactory()
            ));
    }
}