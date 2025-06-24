using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;


/// <summary>
/// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
/// </summary>
public sealed class BattleZone : Zone, IBattleZone
{
    public BattleZone(params ICard[] cards) : base(ZoneType.BattleZone, cards)
    {
    }

    public BattleZone(BattleZone zone) : base(zone)
    {
    }

    public IEnumerable<ICreature> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner)
    {
        IPlayer opponent = game.GetPlayer(game.GetOpponent(owner));
        return GetCreatures(owner).Where(creature => game.ContinuousEffects.CanPlayerChooseCreature(opponent, creature));
    }

    public IEnumerable<ICreature> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner)
    {
        return GetChoosableCreaturesControlledByPlayer(game, owner).Where(x => x.IsEvolutionCreature);
    }

    public IEnumerable<ICreature> GetCreatures(Guid controller, Race race)
    {
        return GetCreatures(controller).Where(x => x.HasRace(race));
    }

    public int GetCreatureCount(Guid controller, Race race)
    {
        return GetCreatures(controller, race).Count();
    }

    public IEnumerable<ICreature> GetCreatures(Guid controller, Race race1, Race race2)
    {
        return GetCreatures(controller).Where(x => x.HasRace(race1) || x.HasRace(race2));
    }

    public IEnumerable<ICreature> GetCreatures(Guid controller, Civilization civilization)
    {
        return GetCreatures(controller).Where(x => x.HasCivilization(civilization));
    }

    public IEnumerable<ICreature> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2)
    {
        return GetCreatures(controller).Where(x => x.HasCivilization(civilization1, civilization2));
    }

    public IEnumerable<ICreature> GetOtherCreatures(Guid controller, Guid creature)
    {
        return GetCreatures(controller).Where(x => x.Id != creature);
    }

    public int GetOtherCreatureCount(Guid controller, Guid creature, Civilization civilization) =>
        GetOtherCreatures(controller, creature).Where(x => x.HasCivilization(civilization)).Count();

    public IEnumerable<ICreature> GetOtherTappedCreatures(Guid controller, Guid creature)
    {
        return GetOtherCreatures(controller, creature).Where(x => x.Tapped);
    }

    public IEnumerable<ICreature> GetOtherUntappedCreatures(Guid controller, Guid creature)
    {
        return GetOtherCreatures(controller, creature).Where(x => !x.Tapped);
    }

    public IEnumerable<ICreature> GetOtherCreatures(Guid creature, Civilization civilization)
    {
        return GetOtherCreatures(creature).Where(x => x.HasCivilization(civilization));
    }

    public int GetOtherCreatureCount(Guid creature, Race race)
    {
        return GetOtherCreatures(creature).Where(x => x.HasRace(race)).Count();
    }

    public IEnumerable<ICreature> GetTappedCreatures(Guid controller)
    {
        return GetCreatures(controller).Where(x => x.Tapped);
    }

    public IEnumerable<ICreature> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller)
    {
        return GetChoosableCreaturesControlledByPlayer(game, controller).Where(x => !x.Tapped);
    }

    public IEnumerable<ICreature> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner)
    {
        return GetCreatures(owner).Union(GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(owner)));
    }

    public override IZone Copy()
    {
        return new BattleZone(this);
    }

    public void RemoveSummoningSicknesses(IPlayer player)
    {
        GetCreatures(player.Id).Where(x => x.SummoningSickness).ToList().ForEach(x => x.RemoveSummoningSickness());
    }

    public IEnumerable<ICreature> GetCreaturesWithSilentSkill(IPlayer player)
    {
        return GetCreatures(player.Id).Where(x => x.GetSilentSkillAbilities().Any());
    }

    public IEnumerable<ICreature> GetCreatures(IPlayer player) => GetCreatures(player.Id);

    IEnumerable<ICreature> GetCreatures(IPlayerV2 player) => Creatures.Where(c => c.OwnerV2 == player);

    public IEnumerable<ICreature> GetUntappedCreatures(IPlayerV2 player) => GetCreatures(player).Where(x => !x.Tapped);

    public IEnumerable<ICreature> CreaturesThatHaveBlockerOwnedBy(IPlayer player) => CreaturesThatHaveBlocker.Where(
        c => c.Owner == player);

    public IEnumerable<ICreature> CreaturesThatHaveBlocker => Creatures.Where(x => x.IsBlocker);

    public IEnumerable<ICreature> CreaturesThatDoNotHaveBlocker => Creatures.Where(x => !x.IsBlocker);
}
