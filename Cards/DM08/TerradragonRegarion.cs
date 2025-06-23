using ContinuousEffects;

namespace Cards.DM08
{
    sealed class TerradragonRegarion : Creature
    {
        public TerradragonRegarion() : base("Terradragon Regarion", 5, 4000, Interfaces.Race.EarthDragon, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
