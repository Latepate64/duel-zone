using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM10
{
    class ArdentLunatron : Engine.Creature
    {
        public ArdentLunatron() : base("Ardent Lunatron", 3, 5000, Engine.Race.CyberMoon, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
