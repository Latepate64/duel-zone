using Abilities.Static;
using CardFilters;
using ContinuousEffects.CannotAttackPlayers;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class JilWarkaTimeGuardian : Creature
{
    public JilWarkaTimeGuardian() : base("Jil Warka, Time Guardian", 3, 2000,
        Race.Guardian, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 2,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCards
                )));
    }
}