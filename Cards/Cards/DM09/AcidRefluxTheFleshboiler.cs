namespace Cards.Cards.DM09
{
    class AcidRefluxTheFleshboiler : Creature
    {
        public AcidRefluxTheFleshboiler() : base("Acid Reflux, the Fleshboiler", 5, 3000, Engine.Race.DevilMask, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddSlayerAbility();
        }
    }
}
