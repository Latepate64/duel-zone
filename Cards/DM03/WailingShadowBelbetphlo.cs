using Abilities.Static;

namespace Cards.DM03
{
    sealed class WailingShadowBelbetphlo : Creature
    {
        public WailingShadowBelbetphlo() : base("Wailing Shadow Belbetphlo", 3, 1000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new SlayerAbility());
        }
    }
}
