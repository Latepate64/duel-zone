using ContinuousEffects;

namespace Cards.DM01
{
    class SuperExplosiveVolcanodon : Engine.Creature
    {
        public SuperExplosiveVolcanodon() : base("Super Explosive Volcanodon", 4, 2000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
