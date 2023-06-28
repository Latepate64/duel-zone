using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class Gigarayze : Creature
    {
        public Gigarayze() : base("Gigarayze", 4, 2000, Race.Chimera, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GigarayzeEffect());
        }
    }

    class GigarayzeEffect : OneShotEffects.SalvageCivilizationCreatureEffect
    {
        public GigarayzeEffect() : base(0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GigarayzeEffect();
        }

        public override string ToString()
        {
            return "You may return a water or fire creature from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Applier.Graveyard.Creatures.Where(x => x.HasCivilization(Civilization.Water, Civilization.Fire));
        }
    }
}
