using Common;

namespace Cards.Cards.DM06
{
    class GrimSoulShadowOfReversal : Creature
    {
        public GrimSoulShadowOfReversal() : base("Grim Soul, Shadow of Reversal", 5, 3000, Subtype.Ghost, Civilization.Darkness)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.SalvageCivilizationCreatureEffect(1, 1, Civilization.Darkness)));
        }
    }
}
