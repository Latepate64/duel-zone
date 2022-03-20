using Cards.OneShotEffects;

namespace Cards.Cards.DM03
{
    class VolcanicArrows : Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Common.Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy a creature that has power 6000 or less.
            // Choose one of your shields and put it into your graveyard.
            AddSpellAbilities(new DestroyMaxPowerCreature(6000), new SelfShieldBurnEffect());
        }
    }
}
