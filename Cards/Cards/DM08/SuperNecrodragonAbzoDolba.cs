using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM08
{
    class SuperNecrodragonAbzoDolba : DragonEvolutionCreature
    {
        public SuperNecrodragonAbzoDolba() : base("Super Necrodragon Abzo Dolba", 6, 11000, Race.ZombieDragon, Civilization.Darkness)
        {
            AddStaticAbilities(new SuperNecrodragonAbzoDolbaEffect());
            AddTripleBreakerAbility();
        }
    }

    class SuperNecrodragonAbzoDolbaEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public SuperNecrodragonAbzoDolbaEffect(int power = 2000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SuperNecrodragonAbzoDolbaEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each creature in your graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Controller.Graveyard.Creatures.Count();
        }
    }
}
