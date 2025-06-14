using Engine.Abilities;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

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

        internal override void Add(Card card, IGame game)
        {
            card.SummoningSickness = true;
            card.KnownTo = [.. game.Players.Select(x => x.Id)];
            Cards.Add(card);
            game.ContinuousEffects.Add(card, [.. card.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone)]);
        }

        internal override List<Card> Remove(Card card, IGame game)
        {
            if (game.CurrentTurn.CurrentPhase is AttackPhase phase)
            {
                if (card == phase.AttackingCreature)
                {
                    phase.RemoveAttackingCreature(game);
                }
                else if (card == phase.AttackTarget)
                {
                    phase.AttackTarget = null;
                }
                else if (card == phase.BlockingCreature)
                {
                    phase.BlockingCreature = null;
                }
            }
            if (!Cards.Remove(card))
            {
                return [];
            }
            else
            {
                game.ContinuousEffects.Remove(card.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).Select(x => x.Id));
                return [.. card.Deconstruct([])];
            }
        }

        public IEnumerable<Card> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner)
        {
            IPlayer opponent = game.GetPlayer(game.GetOpponent(owner));
            return GetCreatures(owner).Where(creature => game.ContinuousEffects.CanPlayerChooseCreature(opponent, creature));
        }

        public override string ToString()
        {
            return "battle zone";
        }

        public IEnumerable<Card> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner)
        {
            return GetChoosableCreaturesControlledByPlayer(game, owner).Where(x => x.IsEvolutionCreature);
        }

        public IEnumerable<Card> GetCreatures(Guid controller, Race race)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race));
        }

        public int GetCreatureCount(Guid controller, Race race)
        {
            return GetCreatures(controller, race).Count();
        }

        public IEnumerable<Card> GetCreatures(Guid controller, Race race1, Race race2)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race1) || x.HasRace(race2));
        }

        public IEnumerable<Card> GetCreatures(Guid controller, Civilization civilization)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<Card> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization1, civilization2));
        }

        public IEnumerable<Card> GetOtherCreatures(Guid controller, Guid creature)
        {
            return GetCreatures(controller).Where(x => x.Id != creature);
        }

        public IEnumerable<Card> GetOtherCreatures(Guid controller, Guid creature, Civilization civilization)
        {
            return GetOtherCreatures(controller, creature).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<Card> GetOtherTappedCreatures(Guid controller, Guid creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => x.Tapped);
        }

        public IEnumerable<Card> GetOtherUntappedCreatures(Guid controller, Guid creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => !x.Tapped);
        }

        public IEnumerable<Card> GetOtherCreatures(Guid creature, Civilization civilization)
        {
            return GetOtherCreatures(creature).Where(x => x.HasCivilization(civilization));
        }

        public int GetOtherCreatureCount(Guid creature, Race race)
        {
            return GetOtherCreatures(creature).Where(x => x.HasRace(race)).Count();
        }

        public IEnumerable<Card> GetTappedCreatures(Guid controller)
        {
            return GetCreatures(controller).Where(x => x.Tapped);
        }

        public IEnumerable<Card> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller)
        {
            return GetChoosableCreaturesControlledByPlayer(game, controller).Where(x => !x.Tapped);
        }

        public IEnumerable<Card> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner)
        {
            return GetCreatures(owner).Union(GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(owner)));
        }

        public BattleZone Copy()
        {
            return new BattleZone(this);
        }

        public void RemoveSummoningSicknesses(IPlayer player)
        {
            GetCreatures(player.Id).Where(x => x.SummoningSickness).ToList().ForEach(x => x.SummoningSickness = false);
        }

        public IEnumerable<Card> GetCreaturesWithSilentSkill(IPlayer player)
        {
            return GetCreatures(player.Id).Where(x => x.GetSilentSkillAbilities().Any());
        }

        public IEnumerable<Card> GetCreatures(IPlayer player)
        {
            return GetCreatures(player.Id);
        }
    }
}