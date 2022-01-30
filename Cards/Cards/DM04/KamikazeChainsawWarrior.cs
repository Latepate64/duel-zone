using Engine;

namespace Cards.Cards.DM04
{
    public class KamikazeChainsawWarrior : Creature
    {
        public KamikazeChainsawWarrior() : base("Kamikaze, Chainsaw Warrior", 2, Civilization.Fire, 1000, Subtype.Armorloid)
        {
            ShieldTrigger = true;
        }
    }
}
