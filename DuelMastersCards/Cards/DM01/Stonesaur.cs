using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class Stonesaur : Creature
    {
        public Stonesaur() : base("Stonesaur", 5, Civilization.Fire, 4000, Subtype.RockBeast)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}
