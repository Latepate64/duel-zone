using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01;

sealed class ArtisanPicora : Creature
{
    public ArtisanPicora() : base("Artisan Picora", 1, 2000, Race.MachineEater,
        Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ManaBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}