using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class GabzagulWarlordOfPain : Creature
    {
        public GabzagulWarlordOfPain() : base("Gabzagul, Warlord of Pain", 6, 5000, Subtype.DarkLord, Civilization.Darkness)
        {
            AddStaticAbilities(new GabzagulWarlordOfPainEffect());
        }
    }

    class GabzagulWarlordOfPainEffect : AttacksIfAbleEffect
    {
        public GabzagulWarlordOfPainEffect() : base(new CardFilters.BattleZoneCreatureFilter(), new Durations.Indefinite())
        {
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
