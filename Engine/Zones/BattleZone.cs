using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone
    {
        public BattleZone(params Card[] cards) : base(ZoneType.BattleZone, cards)
        {
        }

        public BattleZone(BattleZone zone) : base(zone)
        {
        }

        public IEnumerable<Creature> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner)
        {
            Player opponent = game.GetPlayer(game.GetOpponent(owner));
            return GetCreatures(owner).Where(creature => game.ContinuousEffects.CanPlayerChooseCreature(opponent, creature));
        }

        public IEnumerable<Creature> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner)
        {
            return GetChoosableCreaturesControlledByPlayer(game, owner).Where(x => x.IsEvolutionCreature);
        }

        public IEnumerable<Creature> GetCreatures(Guid controller, Race race)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race));
        }

        public int GetCreatureCount(Guid controller, Race race)
        {
            return GetCreatures(controller, race).Count();
        }

        public IEnumerable<Creature> GetCreatures(Guid controller, Race race1, Race race2)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race1) || x.HasRace(race2));
        }

        public IEnumerable<Creature> GetCreatures(Guid controller, Civilization civilization)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<Creature> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization1, civilization2));
        }

        public IEnumerable<Creature> GetOtherCreatures(Guid controller, Guid creature)
        {
            return GetCreatures(controller).Where(x => x.Id != creature);
        }

        public int GetOtherCreatureCount(Guid controller, Guid creature, Civilization civilization) =>
            GetOtherCreatures(controller, creature).Where(x => x.HasCivilization(civilization)).Count();

        public IEnumerable<Creature> GetOtherTappedCreatures(Guid controller, Guid creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => x.Tapped);
        }

        public IEnumerable<Creature> GetOtherUntappedCreatures(Guid controller, Guid creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => !x.Tapped);
        }

        public IEnumerable<Creature> GetOtherCreatures(Guid creature, Civilization civilization)
        {
            return GetOtherCreatures(creature).Where(x => x.HasCivilization(civilization));
        }

        public int GetOtherCreatureCount(Guid creature, Race race)
        {
            return GetOtherCreatures(creature).Where(x => x.HasRace(race)).Count();
        }

        public IEnumerable<Creature> GetTappedCreatures(Guid controller)
        {
            return GetCreatures(controller).Where(x => x.Tapped);
        }

        public IEnumerable<Creature> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller)
        {
            return GetChoosableCreaturesControlledByPlayer(game, controller).Where(x => !x.Tapped);
        }

        public IEnumerable<Creature> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner)
        {
            return GetCreatures(owner).Union(GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(owner)));
        }

        public BattleZone Copy()
        {
            return new BattleZone(this);
        }

        public void RemoveSummoningSicknesses(Player player)
        {
            GetCreatures(player.Id).Where(x => x.SummoningSickness).ToList().ForEach(x => x.RemoveSummoningSickness());
        }

        public IEnumerable<Creature> GetCreaturesWithSilentSkill(Player player)
        {
            return GetCreatures(player.Id).Where(x => x.GetSilentSkillAbilities().Any());
        }

        public IEnumerable<Creature> GetCreatures(Player player) => GetCreatures(player.Id);

        IEnumerable<Creature> GetCreatures(PlayerV2 player) => Creatures.Where(c => c.OwnerV2 == player);

        internal IEnumerable<Creature> GetUntappedCreatures(PlayerV2 player) => GetCreatures(player).Where(
            x => !x.Tapped);

        public IEnumerable<Creature> CreaturesThatHaveBlockerOwnedBy(Player player) => CreaturesThatHaveBlocker.Where(
            c => c.Owner == player);

        public IEnumerable<Creature> CreaturesThatHaveBlocker => Creatures.Where(x => x.IsBlocker);

        public IEnumerable<Creature> CreaturesThatDoNotHaveBlocker => Creatures.Where(x => !x.IsBlocker);
    }
}