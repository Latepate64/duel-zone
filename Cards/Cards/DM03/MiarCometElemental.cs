namespace Cards.Cards.DM03
{
    class MiarCometElemental : Creature
    {
        public MiarCometElemental() : base("Miar, Comet Elemental", 8, 11500, Common.Subtype.AngelCommand, Common.Civilization.Light)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
