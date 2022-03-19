﻿using Common;
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
        public BattleZone() : base()
        {
        }

        public BattleZone(BattleZone zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
            card.SummoningSickness = true;
            card.KnownTo = game.Players.Select(x => x.Id).ToList();
            Cards.Add(card);
            game.AddContinuousEffects(card, card.GetAbilities<StaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).ToArray());
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
                var staticAbilities = card.GetAbilities<StaticAbility>().Where(x => x.FunctionZone == ZoneType.BattleZone).Select(x => x.Id);
                game.RemoveContinuousEffects(staticAbilities);
                return card.Deconstruct(game, new List<ICard>()).ToList();
            }
        }

        public IEnumerable<ICard> GetChoosableCreatures(Game game, Guid owner)
        {
            return GetCreatures(owner).Where(x => !game.GetContinuousEffects<UnchoosableEffect>(x).Any());
        }

        public override string ToString()
        {
            return "battle zone";
        }
    }
}