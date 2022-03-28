using Common;

namespace Cards.Cards.DM06
{
    class Gigagriff : Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Subtype.Chimera, Civilization.Darkness)
        {
            AddBlockerAbility();
            AddSlayerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
