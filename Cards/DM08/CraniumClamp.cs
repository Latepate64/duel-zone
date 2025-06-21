using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM08
{
    class CraniumClamp : Engine.Spell
    {
        public CraniumClamp() : base("Cranium Clamp", 4, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new CraniumClampEffect());
        }
    }

    class CraniumClampEffect : YourOpponentChoosesAndDiscardsCardsFromHisHandEffect
    {
        public CraniumClampEffect() : base(2)
        {
        }

        public CraniumClampEffect(YourOpponentChoosesAndDiscardsCardsFromHisHandEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CraniumClampEffect(this);
        }
    }
}