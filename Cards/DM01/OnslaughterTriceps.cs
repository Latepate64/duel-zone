using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class OnslaughterTriceps : Creature
{
    public OnslaughterTriceps() : base("Onslaughter Triceps", 3, 5000,
        Race.Dragonoid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    ownMana: true
        )));
    }
}