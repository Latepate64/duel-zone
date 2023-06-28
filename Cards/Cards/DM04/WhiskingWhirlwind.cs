using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM04
{
    class WhiskingWhirlwind : Spell
    {
        public WhiskingWhirlwind() : base("Whisking Whirlwind", 1, Civilization.Light)
        {
            AddSpellAbilities(new WhiskingWhirlwindEffect());
        }
    }

    class WhiskingWhirlwindEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new TriggeredAbilities.AtTheEndOfTurnAbility(game.CurrentTurn.Id, new WhiskingWhirlwindUntapEffect()), Ability.Source, Ability.Controller, true));
        }

        public override IOneShotEffect Copy()
        {
            return new WhiskingWhirlwindEffect();
        }

        public override string ToString()
        {
            return "At the end of the turn, untap all your creatures in the battle zone.";
        }
    }

    class WhiskingWhirlwindUntapEffect : OneShotEffects.UntapAreaOfEffect
    {
        public WhiskingWhirlwindUntapEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new WhiskingWhirlwindUntapEffect();
        }

        public override string ToString()
        {
            return "Untap all your creatures in the battle zone.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Applier);
        }
    }
}
