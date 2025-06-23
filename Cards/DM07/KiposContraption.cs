using Engine.Abilities;

namespace Cards.DM07
{
    sealed class KiposContraption : Creature
    {
        public KiposContraption() : base("Kipo's Contraption", 6, 3000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddAbilities(new TapAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000)));
        }
    }
}
