using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Stonesaur : Creature
    {
        public Stonesaur() : base("Stonesaur", 5, 4000, Common.Subtype.RockBeast, Common.Civilization.Fire)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
