using OneShotEffects;

namespace Cards.DM03
{
    sealed class VolcanicArrows : Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyMaxPowerCreature(6000), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
