using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MiraculousMeltdown : Spell
    {
        public MiraculousMeltdown() : base("Miraculous Meltdown", 6, Civilization.Darkness, Civilization.Fire)
        {
            AddStaticAbilities(new MiraculousMeltdownContinuousEffect());
            AddSpellAbilities(new MiraculousMeltdownOneShotEffect());
        }
    }

    class MiraculousMeltdownContinuousEffect : ContinuousEffect, ICannotUseCardEffect
    {
        public MiraculousMeltdownContinuousEffect()
        {
        }

        public MiraculousMeltdownContinuousEffect(MiraculousMeltdownContinuousEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard card, IGame game)
        {
            return card == Source && Applier.ShieldZone.Cards.Count >= Applier.Opponent.ShieldZone.Cards.Count;
        }

        public override IContinuousEffect Copy()
        {
            return new MiraculousMeltdownContinuousEffect(this);
        }

        public override string ToString()
        {
            return "You can cast this spell only if your opponent has more shields than you do.";
        }
    }

    class MiraculousMeltdownOneShotEffect : OneShotEffect
    {
        public MiraculousMeltdownOneShotEffect()
        {
        }

        public MiraculousMeltdownOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var amount = Applier.ShieldZone.Cards.Count;
            var chosen = Applier.Opponent.ChooseCards(Applier.Opponent.ShieldZone.Cards, amount, amount, ToString());
            var toHand = Applier.Opponent.ShieldZone.Cards.Except(chosen);
            Game.PutFromShieldZoneToHand(toHand, true, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousMeltdownOneShotEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his shields for each shield you have. He puts the rest of his shields into his hand.";
        }
    }
}
