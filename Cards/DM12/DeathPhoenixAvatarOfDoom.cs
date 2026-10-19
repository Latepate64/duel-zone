using TriggeredAbilities;
using Interfaces;
using StaticAbilities;
using ContinuousEffects.Replacement;
using OneShotEffects;
using CardFilters;

namespace Cards.DM12;

sealed class DeathPhoenixAvatarOfDoom : VortexEvolutionCreature
{
    public DeathPhoenixAvatarOfDoom() : base("Death Phoenix, Avatar of Doom", 4,
        9000, Civilization.Darkness, Civilization.Fire, Race.Phoenix,
        Race.ZombieDragon, Race.FireBird)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddStaticAbilities(new BolmeteusEffect());
        AddTriggeredAbility(
            new WhenThisCreatureLeavesBattleZoneAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.Hand,
                    destination: ZoneType.Graveyard,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OpponentsCards,
                    excludeSource: false
        )));
    }
}
