using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM07
{
    class Cratersaur : Creature
    {
        public Cratersaur() : base("Cratersaur", 3, 2000, Engine.Subtype.RockBeast, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new CratersaurEffect());
        }
    }

    class CratersaurEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect, IAbilityAddingEffect
    {
        public CratersaurEffect() : base()
        {
        }

        public void AddAbility(IGame game)
        {
            if (YouHaveNoShields(game))
            {
                GetSourceCard(game).AddGrantedAbility(new StaticAbilities.PowerAttackerAbility(3000));
            }
        }

        public bool Applies(ICard attacker, ICard targetOfAttack, IGame game)
        {
            return YouHaveNoShields(game) && IsSourceOfAbility(attacker, game);
        }

        public override IContinuousEffect Copy()
        {
            return new CratersaurEffect();
        }

        public override string ToString()
        {
            return "While you have no shields, this creature can attack untapped creatures and has \"Power attacker +3000.\"";
        }

        private bool YouHaveNoShields(IGame game)
        {
            return !GetSourceAbility(game).GetController(game).ShieldZone.Cards.Any();
        }
    }
}
