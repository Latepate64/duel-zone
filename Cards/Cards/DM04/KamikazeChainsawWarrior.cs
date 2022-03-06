namespace Cards.Cards.DM04
{
    class KamikazeChainsawWarrior : Creature
    {
        public KamikazeChainsawWarrior() : base("Kamikaze, Chainsaw Warrior", 2, Common.Civilization.Fire, 1000, Common.Subtype.Armorloid)
        {
            ShieldTrigger = true;
        }
    }
}
