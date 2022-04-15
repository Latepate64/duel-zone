using Common;

namespace Cards.Cards.DM06
{
    class TankMutant : Creature
    {
        public TankMutant() : base("Tank Mutant", 9, 6000, Engine.Subtype.Hedrian, Civilization.Darkness)
        {
            AddTapAbility(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
