using OneShotEffects;

namespace Cards.DM03
{
    class VolcanicArrows : Engine.Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyMaxPowerCreature(6000), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
