using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Interfaces;

namespace Cards.DM10
{
    class TauntingSkyterror : Creature
    {
        public TauntingSkyterror() : base("Taunting Skyterror", 5, 3000, Race.ArmoredWyvern, Civilization.Fire)
        {
            AddStaticAbilities(new TauntingSkyterrorEffect());
        }
    }

    class TauntingSkyterrorEffect : ContinuousEffect, IAttacksIfAbleEffect
    {
        public TauntingSkyterrorEffect()
        {
        }

        public TauntingSkyterrorEffect(TauntingSkyterrorEffect effect) : base(effect)
        {
        }

        public bool AttacksIfAble(Creature creature, IGame game)
        {
            return Source.Tapped && creature.Owner == GetOpponent(game);
        }

        public override IContinuousEffect Copy()
        {
            return new TauntingSkyterrorEffect(this);
        }

        public override string ToString()
        {
            return "While this creature is tapped during your opponent's turn, each of his creatures attacks if able.";
        }
    }
}
