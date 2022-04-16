using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone, IBattleZone
    {
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
            game.AddContinuousEffects(card, card.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).ToArray());
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
                game.RemoveContinuousEffects(card.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).Select(x => x.Id));
                return card.Deconstruct(game, new List<ICard>()).ToList();
            }
        }

        public IEnumerable<ICard> GetChoosableCreaturesControlledByPlayer(IGame game, Guid owner)
        {
            return GetCreatures(owner).Where(creature => !game.GetContinuousEffects<IUnchoosableEffect>().Any(effect => effect.Applies(creature, game)));
        }

        public override string ToString()
        {
            return "battle zone";
        }

        public IEnumerable<ICard> GetChoosableEvolutionCreaturesControlledByPlayer(IGame game, Guid owner)
        {
            return GetChoosableCreaturesControlledByPlayer(game, owner).Where(x => x.IsEvolutionCreature);
        }

        public IEnumerable<ICard> GetCreatures(Guid controller, Race race)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race));
        }

        public IEnumerable<ICard> GetCreatures(Guid controller, Race race1, Race race2)
        {
            return GetCreatures(controller).Where(x => x.HasRace(race1) || x.HasRace(race2));
        }

        public IEnumerable<ICard> GetCreatures(Guid controller, Civilization civilization)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetCreatures(Guid controller, Civilization civilization1, Civilization civilization2)
        {
            return GetCreatures(controller).Where(x => x.HasCivilization(civilization1, civilization2));
        }

        public IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature)
        {
            return GetCreatures(controller).Where(x => x.Id != creature);
        }

        public IEnumerable<ICard> GetOtherCreatures(Guid controller, Guid creature, Civilization civilization)
        {
            return GetOtherCreatures(controller, creature).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetOtherTappedCreatures(Guid controller, Guid creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => x.Tapped);
        }

        public IEnumerable<ICard> GetOtherUntappedCreatures(Guid controller, Guid creature)
        {
            return GetOtherCreatures(controller, creature).Where(x => !x.Tapped);
        }

        public IEnumerable<ICard> GetOtherCreatures(Guid creature, Civilization civilization)
        {
            return GetOtherCreatures(creature).Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetOtherCreatures(Guid creature, Race race)
        {
            return GetOtherCreatures(creature).Where(x => x.HasRace(race));
        }

        public IEnumerable<ICard> GetTappedCreatures(Guid controller)
        {
            return GetCreatures(controller).Where(x => x.Tapped);
        }

        public IEnumerable<ICard> GetChoosableUntappedCreaturesControlledByPlayer(IGame game, Guid controller)
        {
            return GetChoosableCreaturesControlledByPlayer(game, controller).Where(x => !x.Tapped);
        }

        public IEnumerable<ICard> GetChoosableCreaturesControlledByAnyone(IGame game, Guid owner)
        {
            return GetCreatures(owner).Union(GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(owner)));
        }

        public IBattleZone Copy()
        {
            return new BattleZone(this);
        }
    }
}