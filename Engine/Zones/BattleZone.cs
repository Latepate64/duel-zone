using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public int GetNumberOfOtherCreaturesControllerByPlayer(
        ICreature creature, ICardFilter filter)
    {
        return GetOtherCreaturesControlledByPlayer(creature, filter).Count();
    }

    public IEnumerable<ICreature> GetOtherCreaturesControlledByPlayer(
        ICreature excluded)
    {
        return GetCreaturesControlledByPlayer(excluded.OwnerV2).Where(
            x => !x.Equals(excluded));
    }

    public IEnumerable<ICreature> GetOtherCreaturesControlledByPlayer(
        ICreature excluded, ICardFilter filter)
    {
        return GetOtherCreaturesControlledByPlayer(excluded).Where(
            filter.Match);
    }

    public IEnumerable<ICreature> GetCreaturesControlledByPlayer(
        IPlayer player, ICardFilter filter)
    {
        return GetCreaturesControlledByPlayer(player).Where(filter.Match);
    }

    public int GetNumberOfCreaturesControllerByPlayer(
        IPlayer player, ICardFilter filter)
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

    public IEnumerable<ICreature> GetCreatures(ICardFilter filter)
    {
        return Creatures.Where(filter.Match);
    }

    public bool HasCreaturesControllerByPlayer(
        IPlayer applier, ICardFilter filter)
    {
        return GetCreaturesControlledByPlayer(applier, filter).Any();
    }

    public IEnumerable<ICreature> GetOpponentsChoosableCreatures(
        IPlayer player, ICardFilter filter, IGame game)
    {
        return GetCreaturesControlledByPlayer(player.Opponent, filter).Where(
            creature => game.ContinuousEffects.CanPlayerChooseCreature(
                player, creature));
    }

    public IEnumerable<ICreature> GetChoosableCreatures(
        IPlayer player, ICardFilter filter, IGame game)
    {
        return GetOpponentsChoosableCreatures(player, filter, game).Union(
            GetCreaturesControlledByPlayer(player, filter));
    }

    public IEnumerable<ICreature> GetChoosableCreatures(IPlayer player,
        ICardFilter filter, IGame game, SelectionRange selectionRange)
    {
        return selectionRange switch
        {
            SelectionRange.OpponentsCards => GetOpponentsChoosableCreatures(
                player, filter, game),
            SelectionRange.AllCards => GetChoosableCreatures(
                player, filter, game),
            SelectionRange.OwnCards => GetCreaturesControlledByPlayer(
                player, filter),
            _ => throw new InvalidEnumArgumentException()
        };
    }

    private IEnumerable<ICreature> GetCreaturesControlledByPlayer(
        IPlayer player)
    {
        return Creatures.Where(x => x.OwnerV2.Equals(player));
    }

    private IEnumerable<ICreature> GetOtherCreatures(
        ICreature excluded, ICardFilter filter)
    {
        return GetCreatures(filter).Where(x => !x.Equals(excluded));
    }

    public IEnumerable<ICreature> GetCreatures(
        IPlayer player, ICardFilter filter, SelectionRange selectionRange)
    {
        return selectionRange switch
        {
            SelectionRange.OpponentsCards => GetCreaturesControlledByPlayer(
                player.Opponent, filter),
            SelectionRange.AllCards => GetCreatures(filter),
            SelectionRange.OwnCards => GetCreaturesControlledByPlayer(
                player, filter),
            _ => throw new InvalidEnumArgumentException()
        };
    }
}
