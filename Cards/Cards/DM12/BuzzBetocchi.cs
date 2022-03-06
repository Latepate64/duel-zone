using Common;

namespace Cards.Cards.DM12
{
    class BuzzBetocchi : Creature
    {
        public BuzzBetocchi() : base("Buzz Betocchi", 3, 4000)
        {
            AddCivilizations(Civilization.Fire, Civilization.Nature);
            AddSubtypes(Subtype.FireBird, Subtype.GiantInsect);
        }
    }
}
