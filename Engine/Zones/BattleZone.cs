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
        var opponent = game.GetPlayer(game.GetOpponent(owner));
        return GetCreatures(owner).Where(
            creature => game.ContinuousEffects.CanPlayerChooseCreature(
                opponent, creature));
    }

    public IEnumerable<ICreature>
        GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner)
    {
        return GetChoosableCreaturesControlledByPlayer(game, owner).Where(
            x => x.IsEvolutionCreature);
    }

    public IEnumerable<ICreature>
        GetChoosableUntappedCreaturesControlledByPlayer(
            IGame game, Guid controller)
    {
        return GetChoosableCreaturesControlledByPlayer(game, controller).Where(
            x => !x.Tapped);
    }

    public IEnumerable<ICreature> GetChoosableCreaturesControlledByAnyone(
        IGame game, Guid owner)
    {
        return GetCreatures(owner).Union(
            GetChoosableCreaturesControlledByPlayer(
                game, game.GetOpponent(owner)));
    }

    public IEnumerable<ICreature> GetCreatures(Guid controller, Race race)
    {
        return GetCreatures(controller).Where(x => x.HasRace(race));
    }

    public int GetCreatureCount(Guid controller, Race race)
    {
        return GetCreatures(controller, race).Count();
    }

    public IEnumerable<ICreature> GetCreatures(
        Guid controller, Race race1, Race race2)
    {
        return GetCreatures(controller).Where(
            x => x.HasRace(race1) || x.HasRace(race2));
    }

    public IEnumerable<ICreature> GetCreatures(
        Guid controller, Civilization civilization)
    {
        return GetCreatures(controller).Where(
            x => x.HasCivilization(civilization));
    }

    public IEnumerable<ICreature> GetCreatures(
        Guid controller, Civilization civilization1, Civilization civilization2)
    {
        return GetCreatures(controller).Where(
            x => x.HasCivilization(civilization1, civilization2));
    }

    public IEnumerable<ICreature> GetOtherCreatures(
        Guid controller, Guid creature)
    {
        return GetCreatures(controller).Where(x => x.Id != creature);
    }

    public int GetOtherCreatureCount(
        Guid controller, Guid creature, Civilization civilization)
    {
        return GetOtherCreatures(controller, creature).Count(
            x => x.HasCivilization(civilization));
    }

    public int GetOtherCreatureCount(Guid creature, Race race)
    {
        return GetOtherCreatures(creature).Count(x => x.HasRace(race));
    }

    IEnumerable<ICreature> GetCreatures(IPlayerV2 player) 
    {
        return Creatures.Where(c => c.OwnerV2 == player);
    }

    public IEnumerable<ICreature> GetUntappedCreatures(IPlayerV2 player) 
    {
        return GetCreatures(player).Where(x => !x.Tapped);
    }

    public IEnumerable<ICreature> CreaturesThatHaveBlockerOwnedBy(
        IPlayer player)
    {
        return CreaturesThatHaveBlocker.Where(c => c.Owner == player);
    }

    public int GetNumberOfOtherCreaturesControllerByPlayer(ICreature excluded)
    {
        return GetOtherCreaturesControlledByPlayer(excluded).Count();
    }

    public IEnumerable<ICreature> CreaturesThatHaveBlocker => Creatures.Where(
        x => x.IsBlocker);

    public IEnumerable<ICreature> CreaturesThatDoNotHaveBlocker => Creatures
        .Where(x => !x.IsBlocker);

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

    public IEnumerable<ICreature> GetCreaturesControllerByPlayer(
        IPlayerV2 player, ICardFilter filter)
    {
        return GetCreaturesControllerByPlayer(player).Where(filter.Match);
    }

    public int GetNumberOfCreaturesControllerByPlayer(
        IPlayerV2 player, ICardFilter filter)
    {
        return GetCreaturesControllerByPlayer(player, filter).Count();
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
        return Creatures.Where(x => !x.Equals(excluded) && filter.Match(x));
    }
}
