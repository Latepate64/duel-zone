﻿using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
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
            var choosableAmount = game.BattleZone.GetChoosableCreatures(game, source.GetOpponent(game).Id).Count();
            if (amount > 0 && amount <= choosableAmount)
            {
                var effect = new ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(amount);
                if (source.GetController(game).Choose(new Common.Choices.YesNoChoice(source.GetController(game).Id, $"Take action: \"{effect}\"?"), game).Decision)
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
        public ReturnAnyNumberOfYourCreaturesToYourHandEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
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

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Hand, cards);
        }
    }

    class ChooseOpponentsCreaturesAndReturnThemToHisHandEffect : BounceEffect
    {
        private readonly int _amount;

        public ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(ChooseOpponentsCreaturesAndReturnThemToHisHandEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(int amount) : base(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), amount, amount)
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
    }
}