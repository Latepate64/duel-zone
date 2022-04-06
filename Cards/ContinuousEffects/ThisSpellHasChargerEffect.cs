using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisSpellHasChargerEffect : ContinuousEffect, IChargerEffect
    {
        public ThisSpellHasChargerEffect() : base()
        {
        }

        public bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }

        public override IContinuousEffect Copy()
        {
            return new ThisSpellHasChargerEffect();
        }

        public override string ToString()
        {
            return "Charger";
        }
    }
}
