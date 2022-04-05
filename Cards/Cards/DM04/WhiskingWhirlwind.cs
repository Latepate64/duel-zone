using Common;
using Engine;
using Engine.Abilities;

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
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new TriggeredAbilities.AtTheEndOfTurnAbility(game.CurrentTurn.Id, new WhiskingWhirlwindUntapEffect()), source.Source, source.Controller, true));
            return null;
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
        public WhiskingWhirlwindUntapEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
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
    }
}
