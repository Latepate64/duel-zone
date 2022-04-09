using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class MuramasaDukeOfBlades : Creature
    {
        public MuramasaDukeOfBlades() : base("Muramasa, Duke of Blades", 6, 3000, Common.Subtype.Human, Common.Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new MuramasaDukeOfBladesEffect());
        }
    }

    class MuramasaDukeOfBladesEffect : OneShotEffects.DestroyEffect
    {
        public MuramasaDukeOfBladesEffect() : base(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MuramasaDukeOfBladesEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your opponent's creatures that has power 2000 or less.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Where(x => x.Power <= 2000);
        }
    }
}
