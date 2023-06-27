using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class GigiosHammer : Creature
    {
        public GigiosHammer() : base("Gigio's Hammer", 3, 2000, Race.Xenoparts, Civilization.Fire)
        {
            AddTapAbility(new GigiosHammerOneShotEffect());
        }
    }

    class GigiosHammerOneShotEffect : OneShotEffect
    {
        public GigiosHammerOneShotEffect()
        {
        }

        public GigiosHammerOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new GigiosHammerContinuousEffect(Applier.ChooseRace(ToString())));
        }

        public override IOneShotEffect Copy()
        {
            return new GigiosHammerOneShotEffect(this);
        }

        public override string ToString()
        {
            return "Choose a race. Each creature of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
        }
    }

    class GigiosHammerContinuousEffect : ContinuousEffects.UntilEndOfTurnEffect, IAttacksIfAbleEffect, IAbilityAddingEffect
    {
        private readonly Race _race;

        public GigiosHammerContinuousEffect(GigiosHammerContinuousEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public GigiosHammerContinuousEffect(Race race) : base()
        {
            _race = race;
        }

        public void AddAbility(IGame game)
        {
            game.BattleZone.Creatures.Where(x => x.HasRace(_race)).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.PowerAttackerAbility(4000)));
        }

        public bool AttacksIfAble(ICard creature, IGame game)
        {
            return creature.HasRace(_race);
        }

        public override IContinuousEffect Copy()
        {
            return new GigiosHammerContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"Each {_race} of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
        }
    }
}
