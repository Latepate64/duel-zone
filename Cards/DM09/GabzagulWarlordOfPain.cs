using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09
{
    class GabzagulWarlordOfPain : Creature
    {
        public GabzagulWarlordOfPain() : base("Gabzagul, Warlord of Pain", 6, 5000, Race.DarkLord, Civilization.Darkness)
        {
            AddStaticAbilities(new GabzagulWarlordOfPainEffect());
        }
    }

    class GabzagulWarlordOfPainEffect : ContinuousEffect, IAttacksIfAbleEffect
    {
        public GabzagulWarlordOfPainEffect() : base()
        {
        }

        public bool AttacksIfAble(ICreature creature, IGame game)
        {
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new GabzagulWarlordOfPainEffect();
        }

        public override string ToString()
        {
            return "Each creature attacks each turn if able.";
        }
    }
}
