using Abilities;
using Abilities.Static;
using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class Biancus : Creature
{
    public Biancus() : base("Biancus", 6, 3000, Race.SeaHacker,
        Civilization.Water)
    {
        AddAbilities(new BlockerAbility());
        AddAbilities(
            new TapAbility(
                new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(
                    new CreatureFilter(),
                    new ChosenCreaturesCannotBeBlockedThisTurnEffectFactory()
                )));
    }
}