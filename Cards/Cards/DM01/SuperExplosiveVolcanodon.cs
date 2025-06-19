using Effects.Continuous;

namespace Cards.Cards.DM01
{
    class SuperExplosiveVolcanodon : Engine.Creature
    {
        public SuperExplosiveVolcanodon() : base("Super Explosive Volcanodon", 4, 2000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
        }
    }
}
