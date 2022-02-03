using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class SuperExplosiveVolcanodon : Creature
    {
        public SuperExplosiveVolcanodon() : base("Super Explosive Volcanodon", 4, Common.Civilization.Fire, 2000, Common.Subtype.Dragonoid)
        {
            Abilities.Add(new PowerAttackerAbility(4000));
        }
    }
}
