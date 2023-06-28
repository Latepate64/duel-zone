﻿using Engine.Abilities;
using Engine.Steps;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone, IBattleZone
    {
        public IEnumerable<ICard> EvolutionCreatures => Creatures.Where(x => x.IsEvolutionCreature);

        public BattleZone() : base(ZoneType.BattleZone)
        {
        }

        public BattleZone(IBattleZone zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
            card.SummoningSickness = true;
            card.KnownTo = game.Players.Select(x => x.Id).ToList();
            Cards.Add(card);
            game.ContinuousEffects.Add(card, card.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).ToArray());
        }

        public override List<ICard> Remove(ICard card, IGame game)
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
                return new List<ICard>();
            }
            else
            {
                game.ContinuousEffects.Remove(card.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).Select(x => x.Id));
                return card.Deconstruct(new List<ICard>()).ToList();
            }
        }

        public IEnumerable<ICard> GetChoosableCreaturesControlledByChoosersOpponent(IGame game, IPlayer chooser)
        {
            return GetCreatures(chooser.Opponent).Where(creature => game.ContinuousEffects.CanPlayerChooseCreature(chooser, creature));
        }

        public override string ToString()
        {
            return "battle zone";
        }

        public IEnumerable<ICard> GetChoosableEvolutionCreaturesControlledByChoosersOpponent(IGame game, IPlayer chooser)
        {
            return GetChoosableCreaturesControlledByChoosersOpponent(game, chooser).Where(x => x.IsEvolutionCreature);
        }

        public IEnumerable<ICard> GetCreatures(IPlayer controller, Race race)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race));
        }

        public IEnumerable<ICard> GetCreatures(IPlayer controller, Race race1, Race race2)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race1) || x.HasRace(race2));
        }

        public IEnumerable<ICard> GetCreatures(IPlayer controller, Civilization civilization)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetCreatures(IPlayer controller, Civilization civilization1, Civilization civilization2)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization1, civilization2));
        }

        public IEnumerable<ICard> GetOtherCreatures(IPlayer controller, ICard creature)
        {
            return GetCreatures(controller).Where(x => x.Id != creature.Id);
        }

        public IEnumerable<ICard> GetOtherCreatures(IPlayer controller, ICard creature, Civilization civilization)
        {
            return GetOtherCreatures(controller, creature).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetOtherTappedCreatures(IPlayer controller, ICard creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => x.Tapped);
        }

        public IEnumerable<ICard> GetOtherUntappedCreatures(IPlayer controller, ICard creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => !x.Tapped);
        }

        public IEnumerable<ICard> GetOtherCreatures(ICard creature, Civilization civilization)
        {
            return GetOtherCreatures(creature).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetOtherCreatures(ICard creature, Race race)
        {
            return GetOtherCreatures(creature).Where(x => x.HasRace(race));
        }

        public IEnumerable<ICard> GetTappedCreatures(IPlayer controller)
        {
            return GetCreatures(controller).Where(x => x.Tapped);
        }

        public IEnumerable<ICard> GetChoosableUntappedCreaturesControlledByChoosersOpponent(IGame game, IPlayer chooser)
        {
            return GetChoosableCreaturesControlledByChoosersOpponent(game, chooser).Where(x => !x.Tapped);
        }

        public IEnumerable<ICard> GetChoosableCreaturesControlledByAnyone(IGame game, IPlayer chooser)
        {
            return GetCreatures(chooser).Union(GetChoosableCreaturesControlledByChoosersOpponent(game, chooser));
        }

        public IBattleZone Copy()
        {
            return new BattleZone(this);
        }

        public void RemoveSummoningSicknesses(IPlayer player)
        {
            GetCreatures(player).Where(x => x.SummoningSickness).ToList().ForEach(x => x.SummoningSickness = false);
        }

        public IEnumerable<ICard> GetCreaturesWithSilentSkill(IPlayer player)
        {
            return GetCreatures(player).Where(x => x.GetSilentSkillAbilities().Any());
        }
    }
}