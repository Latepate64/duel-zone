namespace Cards.Cards.DM03
{
    class MiarCometElemental : Creature
    {
        public MiarCometElemental() : base("Miar, Comet Elemental", 8, Common.Civilization.Light, 11500, Common.Subtype.AngelCommand)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
