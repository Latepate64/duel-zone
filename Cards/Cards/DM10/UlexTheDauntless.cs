using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class UlexTheDauntless : Creature
    {
        public UlexTheDauntless() : base("Ulex, the Dauntless", 3, 3000, Race.SpiritQuartz, Civilization.Darkness, Civilization.Fire)
        {
            AddStaticAbilities(new YourOpponentCannotTapThisCreatureEffect());
        }
    }

    class YourOpponentCannotTapThisCreatureEffect : ContinuousEffect, IPlayerCannotTapCreatureEffect
    {
        public YourOpponentCannotTapThisCreatureEffect()
        {
        }

        public YourOpponentCannotTapThisCreatureEffect(YourOpponentCannotTapThisCreatureEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new YourOpponentCannotTapThisCreatureEffect(this);
        }

        public bool PlayerCannotTapCreature(IPlayer player, ICard creature, IGame game)
        {
            return player == GetOpponent(game) && IsSourceOfAbility(creature);
        }

        public override string ToString()
        {
            return "Your opponent can't tap this creature.";
        }
    }
}
