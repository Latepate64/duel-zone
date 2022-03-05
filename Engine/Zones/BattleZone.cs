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
    public class BattleZone : Zone
    {
        public BattleZone(IEnumerable<Card> cards) : base(cards)
        {
        }

        public BattleZone(BattleZone zone) : base(zone.Cards.Select(x => x.Copy()))
        {
        }

        public override void Add(Card card, Game game)
        {
            card.SummoningSickness = true;
            card.KnownBy = game.Players.Select(x => x.Id).ToList();
            Cards.Add(card);
            game.AddContinuousEffects(card.Abilities.OfType<StaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).ToList());
        }

        public override bool Remove(Card card, Game game)
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
                return false;
            }
            else 
            {
                var staticAbilities = card.Abilities.OfType<StaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).Select(x => x.Id).ToList();
                _ = game.ContinuousEffects.RemoveAll(x => staticAbilities.Contains(x.SourceAbility));
                return true;
            }
        }

        public override Zone Copy()
        {
            return new BattleZone(this);
        }

        public IEnumerable<Card> GetChoosableCreatures(Game game, Guid owner)
        {
            return GetCreatures(owner).Where(x => !game.GetContinuousEffects<UnchoosableEffect>(x).Any());
        }

        public override string ToString()
        {
            return "battle zone";
        }
    }
}