namespace Cards.DM04
{
    sealed class KamikazeChainsawWarrior : Creature
    {
        public KamikazeChainsawWarrior() : base("Kamikaze, Chainsaw Warrior", 2, 1000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
        }
    }
}
