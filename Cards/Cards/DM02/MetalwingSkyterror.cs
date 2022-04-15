using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM02
{
    class MetalwingSkyterror : Creature
    {
        public MetalwingSkyterror() : base("Metalwing Skyterror", 7, 6000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new MetalwingSkyterrorEffect());
            AddDoubleBreakerAbility();
        }
    }

    class MetalwingSkyterrorEffect : OneShotEffects.DestroyEffect
    {
        public MetalwingSkyterrorEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MetalwingSkyterrorEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your opponent's creatures that has \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Where(x => x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
