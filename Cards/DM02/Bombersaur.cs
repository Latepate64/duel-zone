using TriggeredAbilities;
using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM02
{
    class Bombersaur : Engine.Creature
    {
        public Bombersaur() : base("Bombersaur", 5, 5000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new BombersaurEffect()));
        }
    }

    class BombersaurEffect : MutualManaSacrificeEffect
    {
        public BombersaurEffect() : base(2)
        {
        }

        public BombersaurEffect(BombersaurEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BombersaurEffect(this);
        }
    }
}
