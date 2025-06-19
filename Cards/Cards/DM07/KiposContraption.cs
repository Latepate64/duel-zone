using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class KiposContraption : Engine.Creature
    {
        public KiposContraption() : base("Kipo's Contraption", 6, 3000, Engine.Race.Xenoparts, Engine.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000)));
        }
    }
}
