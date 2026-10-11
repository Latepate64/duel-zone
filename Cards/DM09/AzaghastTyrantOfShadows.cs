using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using CardFilters;

namespace Cards.DM09;

public sealed class AzaghastTyrantOfShadows : EvolutionCreature
{
    public AzaghastTyrantOfShadows() : base("Azaghast, Tyrant of Shadows", 7,
        9000, Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(
                Race.Ghost,
                new DestroyEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new UntappedCreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
