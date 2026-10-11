using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;

/// <summary>
/// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons,
/// Fortresses, Beats and Fields are put into the battle zone, but no mana,
/// shields, castles nor spells may be put into the battle zone.
/// </summary>
public sealed class BattleZone : Zone, IBattleZone
{
    public BattleZone(params ICard[] cards) : base(ZoneType.BattleZone, cards)
    {
    }

    BattleZone(BattleZone zone) : base(zone)
    {
    }

    public override IZone Copy()
    {
        return new BattleZone(this);
    }

    public IEnumerable<ICreature> GetChoosableCreaturesControlledByPlayer(
        IGame game, Guid owner)
    {
        throw new NotImplementedException("TODO REMOVE!");
    }

    public IEnumerable<ICreature> GetChoosableCreaturesControlledByAnyone(
        IGame game, Guid owner)
    {
        throw new NotImplementedException("TODO REMOVE!");
    }

    IEnumerable<ICreature> GetCreatures(IPlayerV2 player) 
    {
        return Creatures.Where(c => c.OwnerV2 == player);
    }

    public IEnumerable<ICreature> GetUntappedCreatures(IPlayerV2 player) 
    {
        return GetCreatures(player).Where(x => !x.Tapped);
    }

    public int GetNumberOfOtherCreaturesControllerByPlayer(ICreature excluded)
    {
        return GetOtherCreaturesControlledByPlayer(excluded).Count();
    }

    public IEnumerable<ICreature> GetCreaturesControllerByPlayer(
        IPlayerV2 player)
    {
        return Creatures.Where(x => x.OwnerV2.Equals(player));
    }

    public int GetNumberOfOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter)
    {
        return GetOtherCreaturesControlledByPlayer(creature, filter).Count();
    }

    public IEnumerable<ICreature> GetOtherCreaturesControlledByPlayer(
        ICreature excluded)
    {
        return GetCreaturesControllerByPlayer(excluded.OwnerV2).Where(
            x => !x.Equals(excluded));
    }

    public IEnumerable<ICreature> GetOtherCreaturesControlledByPlayer(
        ICreature excluded, ICardFilter filter)
    {
        return GetOtherCreaturesControlledByPlayer(excluded).Where(
            filter.Match);
    }

    public IEnumerable<ICreature> GetCreaturesControlledByPlayer(
        IPlayerV2 player, ICardFilter filter)
    {
        return GetCreaturesControllerByPlayer(player).Where(filter.Match);
    }

    public int GetNumberOfCreaturesControllerByPlayer(
        IPlayerV2 player, ICardFilter filter)
    {
        return GetCreaturesControlledByPlayer(player, filter).Count();
    }

    public bool HasOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter)
    {
        return GetOtherCreaturesControlledByPlayer(creature, filter).Any();
    }

    public int GetNumberOfOtherCreatures(ICreature excluded, ICardFilter filter)
    {
        return GetOtherCreatures(excluded, filter).Count();
    }

    IEnumerable<ICreature> GetOtherCreatures(
        ICreature excluded, ICardFilter filter)
    {
        return GetCreatures(filter).Where(x => !x.Equals(excluded));
    }

    public IEnumerable<ICreature> GetCreatures(ICardFilter filter)
    {
        return Creatures.Where(filter.Match);
    }

    public bool HasCreaturesControllerByPlayer(
        IPlayerV2 applier, ICardFilter filter)
    {
        return GetCreaturesControlledByPlayer(applier, filter).Any();
    }

    public IEnumerable<ICreature> GetOpponentsChoosableCreatures(
        IPlayerV2 player, ICardFilter filter, IGame game)
    {
        return GetCreaturesControlledByPlayer(player.Opponent, filter).Where(
            creature => game.ContinuousEffects.CanPlayerChooseCreature(
                player, creature));
    }

    public IEnumerable<ICreature> GetChoosableCreatures(
        IPlayerV2 player, ICardFilter filter, IGame game)
    {
        return GetOpponentsChoosableCreatures(player, filter, game).Union(
            GetCreaturesControlledByPlayer(player, filter));
    }
}
