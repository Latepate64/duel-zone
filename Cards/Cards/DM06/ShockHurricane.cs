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
        public override void Apply(IGame game, IAbility source)
        {
            var player = source.GetController(game);
            var amount = player.ChooseAnyNumberOfCards(game.BattleZone.GetCreatures(player.Id), ToString()).Count();
            var choosableAmount = game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Count();
            if (amount > 0 && amount <= choosableAmount)
            {
                var effect = new ChooseOpponentsCreaturesAndReturnThemToHisHandEffect(amount);
                if (source.GetController(game).ChooseToTakeAction($"You may {effect.ToString().ToLower()}"))
                {
                    effect.Apply(game, source);
                }
            }
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
