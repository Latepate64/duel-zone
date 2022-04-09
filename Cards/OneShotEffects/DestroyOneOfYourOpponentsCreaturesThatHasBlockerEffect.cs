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

        public override IOneShotEffect Copy()
        {
            return new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Where(x => x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
