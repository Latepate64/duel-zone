using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class ShockHurricane : Spell
    {
        public ShockHurricane() : base("Shock Hurricane", 5, Civilization.Water)
        {
            AddSpellAbilities(new ShockHurricaneEffect());
        }
    }

    class ShockHurricaneEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = new ReturnAnyNumberOfYourCreaturesToYourHandEffect().Apply(game, source).Count();
            var choosableAmount = game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Count();
            if (amount > 0 && amount <= choosableAmount)
            {
                var effect = new ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(amount);
                if (source.GetController(game).ChooseToTakeAction($"You may {effect.ToString().ToLower()}"))
                {
                    effect.Apply(game, source);
                }
            }
            return amount;
        }

        public override IOneShotEffect Copy()
        {
            return new ShockHurricaneEffect();
        }

        public override string ToString()
        {
            return "Return any number of your creatures from the battle zone to your hand. Then you may choose that many of your opponent's creatures in the battle zone and return them to your opponent's hand.";
        }
    }

    class ReturnAnyNumberOfYourCreaturesToYourHandEffect : ChooseAnyNumberOfCardsEffect
    {
        public ReturnAnyNumberOfYourCreaturesToYourHandEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReturnAnyNumberOfYourCreaturesToYourHandEffect();
        }

        public override string ToString()
        {
            return "Return any number of your creatures from the battle zone to your hand.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, cards);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }

    class ChooseOpponentsCreaturesAndReturnThemToHisHandEffect : BounceEffect
    {
        private readonly int _amount;

        public ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(ChooseOpponentsCreaturesAndReturnThemToHisHandEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(int amount) : base(amount, amount)
        {
            _amount = amount;
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(this);
        }

        public override string ToString()
        {
            return $"Choose {_amount} of your opponent's creatures in the battle zone and return them to your opponent's hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id);
        }
    }
}
