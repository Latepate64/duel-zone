using Engine.Abilities;

namespace Cards.DM06
{
    class TankMutant : Engine.Creature
    {
        public TankMutant() : base("Tank Mutant", 9, 6000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddAbilities(new TapAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
