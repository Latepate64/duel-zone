using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class RaVuSeekerOfLightning : Creature
    {
        public RaVuSeekerOfLightning() : base("Ra Vu, Seeker of Lightning", 6, 4000, Race.MechaThunder, Civilization.Light)
        {
            AddWheneverThisCreatureAttacksAbility(new RaVuSeekerOfLightningEffect());
        }
    }

    class RaVuSeekerOfLightningEffect : OneShotEffects.SalvageEffect
    {
        public RaVuSeekerOfLightningEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RaVuSeekerOfLightningEffect();
        }

        public override string ToString()
        {
            return "You may return a light spell from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Graveyard.Spells.Where(x => x.HasCivilization(Civilization.Light));
        }
    }
}
