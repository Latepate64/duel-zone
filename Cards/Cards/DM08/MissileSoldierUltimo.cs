using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class MissileSoldierUltimo : TurboRushCreature
    {
        public MissileSoldierUltimo() : base("Missile Soldier Ultimo", 3, 2000, Race.Dragonoid, Civilization.Fire)
        {
            AddTurboRushAbility(new MissileSoldierUltimoEffect());
        }
    }

    class MissileSoldierUltimoEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect, IAbilityAddingEffect
    {
        public MissileSoldierUltimoEffect() : base()
        {
        }

        public MissileSoldierUltimoEffect(MissileSoldierUltimoEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            Source.AddGrantedAbility(new StaticAbilities.PowerAttackerAbility(4000));
        }

        public bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack)
        {
            return IsSourceOfAbility(attacker);
        }

        public override IContinuousEffect Copy()
        {
            return new MissileSoldierUltimoEffect(this);
        }

        public override string ToString()
        {
            return "This creature can attack untapped creatures and has \"Power attacker +4000.\"";
        }
    }
}
