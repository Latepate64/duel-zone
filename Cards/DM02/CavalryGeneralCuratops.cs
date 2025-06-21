using ContinuousEffects;

namespace Cards.DM02
{
    class CavalryGeneralCuratops : Engine.Creature
    {
        public CavalryGeneralCuratops() : base("Cavalry General Curatops", 3, 2000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }
    }
}
