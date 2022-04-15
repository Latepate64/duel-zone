using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class HydroHurricane : Spell
    {
        public HydroHurricane() : base("Hydro Hurricane", 6, Engine.Civilization.Water)
        {
            AddSpellAbilities(new HydroHurricaneFirstEffect(), new HydroHurricaneSecondEffect());
        }
    }

    class HydroHurricaneFirstEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Controller).Count(x => x.HasCivilization(Engine.Civilization.Light));
            return new HydroHurricaneManaBounceEffect(amount).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneFirstEffect();
        }

        public override string ToString()
        {
            return "For each light creature you have in the battle zone, you may choose a card in your opponent's mana zone and return it to his hand.";
        }
    }

    class HydroHurricaneManaBounceEffect : OpponentManaRecoveryEffect
    {
        private readonly int _amount;

        public HydroHurricaneManaBounceEffect(int amount) : base(0, amount, true)
        {
            _amount = amount;
        }

        public HydroHurricaneManaBounceEffect(HydroHurricaneManaBounceEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneManaBounceEffect(this);
        }

        public override string ToString()
        {
            return $"Choose up to {(_amount > 1 ? $"{_amount} cards" : "a card")} in your opponent's mana zone and return {(_amount > 1 ? "them" : "it")} to his hand.";
        }
    }

    class HydroHurricaneSecondEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Controller).Count(x => x.HasCivilization(Engine.Civilization.Darkness));
            return new HydroHurricaneBounceEffect(amount).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneSecondEffect();
        }

        public override string ToString()
        {
            return "For each darkness creature you have in the battle zone, you may choose one of your opponent's creatures in the battle zone and return it to his hand.";
        }
    }

    class HydroHurricaneBounceEffect : BounceEffect
    {
        private readonly int _maximum;

        public HydroHurricaneBounceEffect(int maximum) : base(0, maximum)
        {
            _maximum = maximum;
        }

        public HydroHurricaneBounceEffect(HydroHurricaneBounceEffect effect) : base(effect)
        {
            _maximum = effect._maximum;
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneBounceEffect(this);
        }

        public override string ToString()
        {
            return $"Choose up to {(_maximum > 1 ? $"{_maximum} cards" : "a card")} of your opponent's creatures in the battle zone and return {(_maximum > 1 ? "them" : "it")} to his hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id);
        }
    }
}
