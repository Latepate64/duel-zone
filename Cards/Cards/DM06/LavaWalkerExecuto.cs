using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class LavaWalkerExecuto : EvolutionCreature
    {
        public LavaWalkerExecuto() : base("Lava Walker Executo", 4, 5000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Common.Civilization.Fire, new LavaWalkerExecutoEffect(3000)));
        }
    }

    class LavaWalkerExecutoEffect : CardSelectionEffect
    {
        public int Power { get; }

        public LavaWalkerExecutoEffect(LavaWalkerExecutoEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public LavaWalkerExecutoEffect(int power) : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Common.Civilization.Fire), 1, 1, true)
        {
            Power = power;
        }

        public override IOneShotEffect Copy()
        {
            return new LavaWalkerExecutoEffect(this);
        }

        public override string ToString()
        {
            return $"One of your fire creatures in the battle zone gets +{Power} power until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(Power, cards));
        }
    }
}
