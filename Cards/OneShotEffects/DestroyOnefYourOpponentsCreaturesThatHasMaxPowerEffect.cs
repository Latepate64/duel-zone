using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect : DestroyEffect, IPowerable
    {
        public DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(int power) : base(1, 1, true)
        {
            Power = power;
        }

        public DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public int Power { get; }

        public override IOneShotEffect Copy()
        {
            return new DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(this);
        }

        public override string ToString()
        {
            return $"Destroy one of your opponent's creatures that has power {Power} or less.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier).Where(x => x.Power <= Power);
        }
    }
}
