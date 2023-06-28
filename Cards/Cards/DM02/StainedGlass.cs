using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM02
{
    class StainedGlass : Creature
    {
        public StainedGlass() : base("Stained Glass", 3, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new StainedGlassEffect());
        }
    }

    class StainedGlassEffect : BounceEffect
    {
        public StainedGlassEffect() : base(0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new StainedGlassEffect();
        }

        public override string ToString()
        {
            return "You may choose one of your opponent's fire or nature creatures in the battle zone and return it to its owner's hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, Applier.Opponent.Id).Where(x => x.HasCivilization(Civilization.Fire, Civilization.Nature));
        }
    }
}
