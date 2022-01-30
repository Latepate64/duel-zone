using DuelMastersModels;

namespace Cards.Cards.DM03
{
    class MiarCometElemental : Creature
    {
        public MiarCometElemental() : base("Miar, Comet Elemental", 8, Civilization.Light, 11500, Subtype.AngelCommand)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
