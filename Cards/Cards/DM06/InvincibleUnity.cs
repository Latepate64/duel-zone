using Abilities.Static;
using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class InvincibleUnity : Spell
    {
        public InvincibleUnity() : base("Invincible Unity", 13, Civilization.Nature)
        {
            AddSpellAbilities(new InvincibleUnityOneShotEffect());
        }
    }

    class InvincibleUnityOneShotEffect : OneShotEffect
    {
        public InvincibleUnityOneShotEffect()
        {
        }

        public InvincibleUnityOneShotEffect(InvincibleUnityOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new InvincibleUnityContinuousEffect(game.BattleZone.GetCreatures(Ability.Controller.Id)));
        }

        public override IOneShotEffect Copy()
        {
            return new InvincibleUnityOneShotEffect(this);
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets +8000 power and \"triple breaker\" until the end of the turn.";
        }
    }

    class InvincibleUnityContinuousEffect : UntilEndOfTurnEffect, IAbilityAddingEffect, IPowerModifyingEffect
    {
        private readonly List<Creature> _cards;

        public InvincibleUnityContinuousEffect(IEnumerable<Creature> cards)
        {
            _cards = [.. cards];
        }

        public InvincibleUnityContinuousEffect(InvincibleUnityContinuousEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        public void AddAbility(IGame game)
        {
            _cards.ForEach(x => x.AddGrantedAbility(new TripleBreakerAbility()));
        }

        public override IContinuousEffect Copy()
        {
            return new InvincibleUnityContinuousEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            _cards.ForEach(x => x.IncreasePower(8000));
        }

        public override string ToString()
        {
            return $"{_cards} get +8000 power and \"triple breaker\" until the end of the turn.";
        }
    }
}
