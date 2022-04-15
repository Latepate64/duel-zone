namespace Cards.Cards.DM10
{
    class MikayRattlingDoll : Creature
    {
        public MikayRattlingDoll() : base("Mikay, Rattling Doll", 2, 2000, Engine.Subtype.DeathPuppet, Common.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
