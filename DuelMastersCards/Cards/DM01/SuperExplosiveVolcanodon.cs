using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class SuperExplosiveVolcanodon : Creature
    {
        public SuperExplosiveVolcanodon() : base("Super Explosive Volcanodon", 4, Civilization.Fire, 2000, Subtype.Dragonoid)
        {
            Abilities.Add(new PowerAttackerAbility(4000));
        }
    }
}
