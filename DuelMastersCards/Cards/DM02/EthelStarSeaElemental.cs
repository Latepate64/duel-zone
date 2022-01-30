using DuelMastersModels;

namespace Cards.Cards.DM02
{
    class EthelStarSeaElemental : Creature
    {
        public EthelStarSeaElemental() : base("Ethel, Star Sea Elemental", 6, Civilization.Light, 5500, Subtype.AngelCommand)
        {
            Abilities.Add(new StaticAbilities.UnblockableAbility());
        }
    }
}
