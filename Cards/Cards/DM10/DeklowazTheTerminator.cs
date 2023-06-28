using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class DeklowazTheTerminator : Creature
    {
        public DeklowazTheTerminator() : base("Deklowaz, the Terminator", 6, 5000, Race.SpiritQuartz, Civilization.Darkness, Civilization.Fire)
        {
            AddTapAbility(new DeklowazTheTerminatorEffect());
        }
    }

    class DeklowazTheTerminatorEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            Applier.DestroyAllCreaturesThatHaveMaximumPower(3000, Ability);
            Applier.LookAtOpponentsHand();
            Applier.Opponent.DiscardAllCreaturesThatHaveMaximumPower(3000, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new DeklowazTheTerminatorEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures that have power 3000 or less. Then look at your opponent's hand. He discards all creatures from it that have power 3000 or less.";
        }
    }
}
