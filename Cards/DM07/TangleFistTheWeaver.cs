using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM07
{
    class TangleFistTheWeaver : Engine.Creature
    {
        public TangleFistTheWeaver() : base("Tangle Fist, the Weaver", 4, 2000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddAbilities(new TapAbility(new TangleFistEffect()));
        }
    }

    class TangleFistEffect : YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect
    {
        public TangleFistEffect() : base(3)
        {
        }

        public TangleFistEffect(YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new TangleFistEffect(this);
        }
    }
}
