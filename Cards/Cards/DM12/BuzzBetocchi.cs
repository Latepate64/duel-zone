using Common;

namespace Cards.Cards.DM12
{
    class BuzzBetocchi : Creature
    {
        public BuzzBetocchi() : base("Buzz Betocchi", 3, 4000)
        {
            Civilizations.Add(Civilization.Fire);
            Civilizations.Add(Civilization.Nature);
            Subtypes.Add(Subtype.FireBird);
            Subtypes.Add(Subtype.GiantInsect);
        }
    }
}
