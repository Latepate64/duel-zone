﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM09
{
    class TraRionPenumbraGuardian : Creature
    {
        public TraRionPenumbraGuardian() : base("Tra Rion, Penumbra Guardian", 6, 5500, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddTapAbility(new TraRionPenumbraGuardianEffect());
        }
    }

    class TraRionPenumbraGuardianEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(
                new TriggeredAbilities.AtTheEndOfTurnAbility(game.CurrentTurn.Id, new TraRionPenumbraGuardianUntapEffect(source.GetController(game).ChooseRace(ToString()))),
                source.Id,
                source.Controller,
                true));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new TraRionPenumbraGuardianEffect();
        }

        public override string ToString()
        {
            return "Choose a race. At the end of this turn, untap all creatures of that race in the battle zone.";
        }
    }

    class TraRionPenumbraGuardianUntapEffect : UntapAreaOfEffect
    {
        private readonly Subtype _subtype;

        public TraRionPenumbraGuardianUntapEffect(Subtype subtype) : base()
        {
            _subtype = subtype;
        }

        public TraRionPenumbraGuardianUntapEffect(TraRionPenumbraGuardianUntapEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public override IOneShotEffect Copy()
        {
            return new TraRionPenumbraGuardianUntapEffect(this);
        }

        public override string ToString()
        {
            return $"Untap all ${_subtype}s in the battle zone.";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(_subtype);
        }
    }
}
