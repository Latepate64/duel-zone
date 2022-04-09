using Common;
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
        public BattleZone() : base()
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
                if (card.Id == phase.AttackingCreature)
                {
                    phase.RemoveAttackingCreature(game);
                }
                else if (card.Id == phase.AttackTarget)
                {
                    phase.AttackTarget = Guid.Empty;
                }
                else if (card.Id == phase.BlockingCreature)
                {
                    phase.BlockingCreature = Guid.Empty;
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

        public IEnumerable<ICard> GetChoosableCreatures(IGame game, Guid owner)
        {
            return GetCreatures(owner).Where(creature => !game.GetContinuousEffects<IUnchoosableEffect>().Any(effect => effect.Applies(creature, game)));
        }

        public override string ToString()
        {
            return "battle zone";
        }

        public IEnumerable<ICard> GetChoosableEvolutionCreatures(IGame game, Guid owner)
        {
            return GetChoosableCreatures(game, owner).Where(x => x.IsEvolutionCreature);
        }

        public IEnumerable<ICard> GetCreatures(Guid controller, Subtype subtype)
        {
            return GetCreatures(controller).Where(x => x.HasSubtype(subtype));
        }

        public IEnumerable<ICard> GetCreatures(Guid controller, Subtype subtype1, Subtype subtype2)
        {
            return GetCreatures(controller).Where(x => x.HasSubtype(subtype1) || x.HasSubtype(subtype2));
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
            return Creatures.Where(x => x.Id != creature && x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetOtherCreatures(Guid creature, Subtype subtype)
        {
            return Creatures.Where(x => x.Id != creature && x.HasSubtype(subtype));
        }

        public IEnumerable<ICard> GetTappedCreatures(Guid controller)
        {
            return GetCreatures(controller).Where(x => x.Tapped);
        }
    }
}