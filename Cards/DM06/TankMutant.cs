using Engine.Abilities;

namespace Cards.DM06
{
    sealed class TankMutant : Engine.Creature
    {
        public TankMutant() : base("Tank Mutant", 9, 6000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
