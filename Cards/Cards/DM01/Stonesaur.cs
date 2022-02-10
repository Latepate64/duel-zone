using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Stonesaur : Creature
    {
        public Stonesaur() : base("Stonesaur", 5, Common.Civilization.Fire, 4000, Common.Subtype.RockBeast)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
