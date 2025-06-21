using ContinuousEffects;

namespace Cards.DM10
{
    class ArdentLunatron : Engine.Creature
    {
        public ArdentLunatron() : base("Ardent Lunatron", 3, 5000, Interfaces.Race.CyberMoon, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
