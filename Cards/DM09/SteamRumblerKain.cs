using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class SteamRumblerKain : Creature
{
    public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000,
        Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ShieldBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    filter: new AnyCardFilter(),
                    ownShields: true
        )));
    }
}