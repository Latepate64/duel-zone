using Abilities.Static;
using CardFilters;
using ContinuousEffects.CannotAttackPlayers;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

sealed class BelixTheExplorer : Creature
{
    public BelixTheExplorer() : base("Belix, the Explorer", 2, 3000,
        Race.Gladiator, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaRecoveryEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new SpellFilter(),
                    ownMana: true
        )));
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}