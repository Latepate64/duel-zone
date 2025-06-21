using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM08
{
    class SuperNecrodragonAbzoDolba : DragonEvolutionCreature
    {
        public SuperNecrodragonAbzoDolba() : base("Super Necrodragon Abzo Dolba", 6, 11000, Race.ZombieDragon, Civilization.Darkness)
        {
            AddStaticAbilities(new SuperNecrodragonAbzoDolbaEffect());
            AddStaticAbilities(new TripleBreakerEffect());
        }
    }

    class SuperNecrodragonAbzoDolbaEffect(int power = 2000) : PowerModifyingMultiplierEffect(power)
    {
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
