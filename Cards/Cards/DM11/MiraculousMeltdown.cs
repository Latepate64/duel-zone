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
            return card == GetSourceCard(game) && GetController(game).ShieldZone.Cards.Count >= game.GetOpponent(GetController(game)).ShieldZone.Cards.Count;
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
        public override object Apply(IGame game, IAbility source)
        {
            var amount = source.GetController(game).ShieldZone.Cards.Count;
            var chosen = source.GetOpponent(game).ChooseCards(source.GetOpponent(game).ShieldZone.Cards, amount, amount, ToString());
            var toHand = source.GetOpponent(game).ShieldZone.Cards.Except(chosen);
            game.PutFromShieldZoneToHand(toHand, true, source);
            return toHand;
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousMeltdownOneShotEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his shields for each shield you have. He puts the rest of his shields into his hand.";
        }
    }
}
