using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM07
{
    class FreezingIcehammer : Spell
    {
        public FreezingIcehammer() : base("Freezing Icehammer", 3, Civilization.Nature)
        {
            AddSpellAbilities(new FreezingIcehammerEffect());
        }
    }

    class FreezingIcehammerEffect : OneShotEffects.ManaFeedEffect
    {
        public FreezingIcehammerEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new FreezingIcehammerEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's water or darkness creatures in the battle zone. Your opponent puts that creature into his mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, Applier.Opponent).Where(x => x.HasCivilization(Civilization.Water, Civilization.Darkness));
        }
    }
}
