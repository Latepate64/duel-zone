using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class MuramasaDukeOfBlades : Creature
    {
        public MuramasaDukeOfBlades() : base("Muramasa, Duke of Blades", 6, 3000, Race.Human, Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new MuramasaDukeOfBladesEffect());
        }
    }

    class MuramasaDukeOfBladesEffect : OneShotEffects.DestroyEffect
    {
        public MuramasaDukeOfBladesEffect() : base(0, 1, true)
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
            return game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier).Where(x => x.Power <= 2000);
        }
    }
}
