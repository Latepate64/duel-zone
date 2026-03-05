using ContinuousEffects;

namespace Cards.DM02
{
    sealed class EthelStarSeaElemental : Creature
    {
        public EthelStarSeaElemental() : base("Ethel, Star Sea Elemental", 6, 5500, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
