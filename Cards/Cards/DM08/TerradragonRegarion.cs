using Effects.Continuous;

namespace Cards.Cards.DM08
{
    class TerradragonRegarion : Engine.Creature
    {
        public TerradragonRegarion() : base("Terradragon Regarion", 5, 4000, Engine.Race.EarthDragon, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
