using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM12
{
    class TerradragonArqueDelacerna : Creature
    {
        public TerradragonArqueDelacerna() : base("Terradragon Arque Delacerna", 8, 6000, Race.EarthDragon, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new OptionalMadnessEffect());
        }
    }
}
