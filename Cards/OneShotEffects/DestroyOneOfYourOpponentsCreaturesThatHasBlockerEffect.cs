using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect : DestroyEffect
    {
        public DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect() : base(1, 1, true)
        {
        }

        public DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect(DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect(this);
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier).Where(x => x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
