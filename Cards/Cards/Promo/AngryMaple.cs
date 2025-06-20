using ContinuousEffects;

namespace Cards.Cards.Promo
{
    class AngryMaple : Engine.Creature
    {
        public AngryMaple() : base("Angry Maple", 3, 1000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
