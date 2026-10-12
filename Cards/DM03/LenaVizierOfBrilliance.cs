using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM03;

sealed class LenaVizierOfBrilliance : Creature
{
    public LenaVizierOfBrilliance() : base("Lena, Vizier of Brilliance", 4,
        2000, Race.Initiate, Civilization.Light)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaRecoveryEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new SpellFilter(),
                    ownMana: true
        )));
    }
}