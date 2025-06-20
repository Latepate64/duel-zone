using Abilities.Triggered;
using OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class Bombersaur : Engine.Creature
    {
        public Bombersaur() : base("Bombersaur", 5, 5000, Engine.Race.RockBeast, Engine.Civilization.Fire)
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
