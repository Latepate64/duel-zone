using ContinuousEffects;

namespace Cards.Promo
{
    class AngryMaple : Engine.Creature
    {
        public AngryMaple() : base("Angry Maple", 3, 1000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
