using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM01
{
    class ChaosStrike : Spell
    {
        public ChaosStrike() : base("Chaos Strike", 2, Common.Civilization.Fire)
        {
            AddSpellAbilities(new ChaosStrikeOneShotEffect());
        }
    }

    class ChaosStrikeOneShotEffect : OneShotEffects.CardSelectionEffect
    {
        public ChaosStrikeOneShotEffect() : base(new CardFilters.OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChaosStrikeOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's untapped creatures in the battle zone. Your creatures can attack it this turn as though it were tapped.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            if (cards.Length == 1)
            {
                game.AddContinuousEffects(source, new ChaosStrikeContinousEffect(cards.Single().Id));
            }
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(game, source.GetOpponent(game).Id);
        }
    }

    class ChaosStrikeContinousEffect : UntilEndOfTurnEffect, ICanBeAttackedAsThoughTappedEffect
    {
        private readonly Guid _targetOfAttack;

        public ChaosStrikeContinousEffect(Guid targetOfAttack) : base()
        {
            _targetOfAttack = targetOfAttack;
        }

        public ChaosStrikeContinousEffect(ChaosStrikeContinousEffect effect) : base(effect)
        {
            _targetOfAttack = effect._targetOfAttack;
        }

        public bool Applies(ICard targetOfAttack)
        {
            return targetOfAttack.Id == _targetOfAttack;
        }

        public override IContinuousEffect Copy()
        {
            return new ChaosStrikeContinousEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent's creatures can attack this creature as though this creature was tapped.";
        }
    }
}
