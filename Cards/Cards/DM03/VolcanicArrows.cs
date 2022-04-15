using Cards.OneShotEffects;

namespace Cards.Cards.DM03
{
    class VolcanicArrows : Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DestroyMaxPowerCreature(6000), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
