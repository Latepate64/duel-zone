using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class CrathLadeMercilessKing : Creature
    {
        public CrathLadeMercilessKing() : base("Crath Lade, Merciless King", 8, 4000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddTapAbility(new CrathLadeEffect());
        }
    }

    class CrathLadeEffect : OpponentRandomDiscardEffect
    {
        public CrathLadeEffect() : base(2)
        {
        }

        public CrathLadeEffect(OpponentRandomDiscardEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CrathLadeEffect(this);
        }
    }
}
