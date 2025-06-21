using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM07
{
    class CrathLadeMercilessKing : Engine.Creature
    {
        public CrathLadeMercilessKing() : base("Crath Lade, Merciless King", 8, 4000, Interfaces.Race.DarkLord, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new TapAbility(new CrathLadeEffect()));
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
