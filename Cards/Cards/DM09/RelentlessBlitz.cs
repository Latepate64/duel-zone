using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class RelentlessBlitz : Spell
    {
        public RelentlessBlitz() : base("Relentless Blitz", 3, Civilization.Fire)
        {
            AddSpellAbilities(new RelentlessBlitzEffect());
        }
    }

    class RelentlessBlitzEffect : OneShotEffect
    {
        public RelentlessBlitzEffect()
        {
        }

        public RelentlessBlitzEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var race = GetController(game).ChooseRace(ToString());
            game.AddContinuousEffects(GetSourceAbility(game), new RelentlessBlitzContinuousEffect(race));
        }

        public override IOneShotEffect Copy()
        {
            return new RelentlessBlitzEffect(this);
        }

        public override string ToString()
        {
            return "Choose a race. This turn, each creature of that race can attack untapped creatures and can't be blocked while attacking a creature.";
        }
    }

    class RelentlessBlitzContinuousEffect : UntilEndOfTurnEffect, ICanAttackUntappedCreaturesEffect, IUnblockableEffect
    {
        private readonly Race _race;

        public RelentlessBlitzContinuousEffect(Race race)
        {
            _race = race;
        }

        public RelentlessBlitzContinuousEffect(RelentlessBlitzContinuousEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack, IGame game)
        {
            return attacker.HasRace(_race);
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return attacker.HasRace(_race) && targetOfAttack is ICard;
        }

        public override IContinuousEffect Copy()
        {
            return new RelentlessBlitzContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"This turn, {_race}s can attack untapped creatures and can't be blocked while attacking a creature.";
        }
    }
}
