using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class GigiosHammer : Creature
    {
        public GigiosHammer() : base("Gigio's Hammer", 3, 2000, Engine.Subtype.Xenoparts, Civilization.Fire)
        {
            AddTapAbility(new GigiosHammerOneShotEffect());
        }
    }

    class GigiosHammerOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new GigiosHammerContinuousEffect(source.GetController(game).ChooseRace(ToString())));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new GigiosHammerOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Each creature of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
        }
    }

    class GigiosHammerContinuousEffect : ContinuousEffects.UntilEndOfTurnEffect, IAttacksIfAbleEffect, IAbilityAddingEffect
    {
        private readonly Subtype _subtype;

        public GigiosHammerContinuousEffect(GigiosHammerContinuousEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public GigiosHammerContinuousEffect(Subtype subtype) : base()
        {
            _subtype = subtype;
        }

        public void AddAbility(IGame game)
        {
            game.BattleZone.Creatures.Where(x => x.HasSubtype(_subtype)).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.PowerAttackerAbility(4000)));
        }

        public bool Applies(Engine.ICard creature, IGame game)
        {
            return creature.HasSubtype(_subtype);
        }

        public override IContinuousEffect Copy()
        {
            return new GigiosHammerContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"Each {_subtype} of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
        }
    }
}
