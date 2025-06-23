using Engine.Abilities;

namespace Cards.DM06
{
    sealed class TankMutant : Creature
    {
        public TankMutant() : base("Tank Mutant", 9, 6000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
