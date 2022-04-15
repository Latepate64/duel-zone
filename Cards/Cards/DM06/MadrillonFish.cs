namespace Cards.Cards.DM06
{
    class MadrillonFish : Creature
    {
        public MadrillonFish() : base("Madrillon Fish", 2, 3000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
