using Common;

namespace Cards.Cards.Promo
{
    class AngryMaple : Creature
    {
        public AngryMaple() : base("Angry Maple", 3, Civilization.Nature, 1000, Subtype.TreeFolk)
        {
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(4000));
        }
    }
}
