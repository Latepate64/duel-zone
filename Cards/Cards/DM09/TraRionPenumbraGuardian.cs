using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM09
{
    class TraRionPenumbraGuardian : Creature
    {
        public TraRionPenumbraGuardian() : base("Tra Rion, Penumbra Guardian", 6, 5500, Race.Guardian, Civilization.Light)
        {
            AddTapAbility(new TraRionPenumbraGuardianEffect());
        }
    }

    class TraRionPenumbraGuardianEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(
                new TriggeredAbilities.AtTheEndOfTurnAbility(game.CurrentTurn.Id, new TraRionPenumbraGuardianUntapEffect(Controller.ChooseRace(ToString()))),
                Ability.Id,
                Ability.Controller,
                true));
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

    class TraRionPenumbraGuardianUntapEffect : UntapAreaOfEffect, IRaceable
    {
        public TraRionPenumbraGuardianUntapEffect(Race race) : base()
        {
            Race = race;
        }

        public TraRionPenumbraGuardianUntapEffect(TraRionPenumbraGuardianUntapEffect effect) : base(effect)
        {
            Race = effect.Race;
        }

        public Race Race { get; }

        public override IOneShotEffect Copy()
        {
            return new TraRionPenumbraGuardianUntapEffect(this);
        }

        public override string ToString()
        {
            return $"Untap all ${Race}s in the battle zone.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Race);
        }
    }
}
