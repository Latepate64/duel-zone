using ContinuousEffects;

namespace Cards.DM06
{
    class MadrillonFish : Engine.Creature
    {
        public MadrillonFish() : base("Madrillon Fish", 2, 3000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
