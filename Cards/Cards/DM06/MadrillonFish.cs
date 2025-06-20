using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class MadrillonFish : Engine.Creature
    {
        public MadrillonFish() : base("Madrillon Fish", 2, 3000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
