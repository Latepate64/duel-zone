using Common;

namespace Cards.Cards.DM10
{
    public class AdventureBoar : Creature
    {
        public AdventureBoar() : base("Adventure Boar", 2, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(1000));
        }
    }
}
