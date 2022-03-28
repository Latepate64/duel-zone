using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class GrimSoulShadowOfReversal : Creature
    {
        public GrimSoulShadowOfReversal() : base("Grim Soul, Shadow of Reversal", 5, 3000, Subtype.Ghost, Civilization.Darkness)
        {
            AddTapAbility(new GrimSoulShadowOfReversalEffect());
        }
    }

    class GrimSoulShadowOfReversalEffect : OneShotEffects.SalvageCivilizationCreatureEffect
    {
        public GrimSoulShadowOfReversalEffect() : base(1, 1, Civilization.Darkness)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GrimSoulShadowOfReversalEffect();
        }

        public override string ToString()
        {
            return "Return a darkness creature from your graveyard to your hand.";
        }
    }
}
