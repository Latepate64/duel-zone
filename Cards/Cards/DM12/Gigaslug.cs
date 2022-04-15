using Common;

namespace Cards.Cards.DM12
{
    class Gigaslug : Creature
    {
        public Gigaslug() : base("Gigaslug", 3, 1000, Engine.Subtype.Chimera, Civilization.Darkness)
        {
            AddBlockerAbility();
            AddSlayerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
