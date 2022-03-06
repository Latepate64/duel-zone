using Common;

namespace Cards.Cards.DM04
{
    class AmberGrass : Creature
    {
        public AmberGrass() : base("Amber Grass", 4, Civilization.Light, 3000, Subtype.StarlightTree)
        {
            ShieldTrigger = true;
        }
    }
}
