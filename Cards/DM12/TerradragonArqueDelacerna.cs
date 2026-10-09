using Abilities.Static;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards.DM12
{
    sealed class TerradragonArqueDelacerna : Creature
    {
        public TerradragonArqueDelacerna() : base("Terradragon Arque Delacerna", 8, 6000, Race.EarthDragon, Civilization.Nature)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddStaticAbilities(new OptionalMadnessEffect());
        }
    }
}
