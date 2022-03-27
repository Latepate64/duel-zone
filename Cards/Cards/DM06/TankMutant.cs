using Common;

namespace Cards.Cards.DM06
{
    class TankMutant : Creature
    {
        public TankMutant() : base("Tank Mutant", 9, 6000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.OpponentSacrificeEffect()));
        }
    }
}
