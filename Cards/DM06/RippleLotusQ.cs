using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class RippleLotusQ : Creature
{
    public RippleLotusQ() : base("Ripple Lotus Q", 6, 2000,
        [Race.Survivor, Race.CyberVirus], Civilization.Water)
    {
        AddStaticAbilities(
            new SurvivorEffect(
                new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                    new TapChoiceEffect(
                        minimum: 0,
                        maximum: 1,
                        ownerChooses: true,
                        filter: new CreatureFilter(),
                        selectionRange: SelectionRange.OpponentsCreatures
                    ))));
    }
}