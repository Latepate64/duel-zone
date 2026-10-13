using TriggeredAbilities;
using OneShotEffects;
using Abilities.Static;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class ExplosiveFighterUcarn : Creature
{
    public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, 9000,
        Race.Dragonoid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaBurnEffect(
                    minimum: 2,
                    maximum: 2,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OwnCreatures
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}