using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect : DestroyEffect
    {
        private readonly int _power;

        public DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(int power) : base(1, 1, true)
        {
            _power = power;
        }

        public DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(this);
        }

        public override string ToString()
        {
            return $"Destroy one of your opponent's creatures that has power {_power} or less.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Where(x => x.Power <= _power);
        }
    }
}
