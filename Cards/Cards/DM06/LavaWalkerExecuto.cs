using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class LavaWalkerExecuto : EvolutionCreature
    {
        public LavaWalkerExecuto() : base("Lava Walker Executo", 4, 5000, Race.Dragonoid, Civilization.Fire)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Civilization.Fire, new LavaWalkerExecutoEffect(3000)));
        }
    }

    class LavaWalkerExecutoEffect : CardSelectionEffect, IPowerable
    {
        public int Power { get; }

        public LavaWalkerExecutoEffect(LavaWalkerExecutoEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public LavaWalkerExecutoEffect(int power) : base(1, 1, true)
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
            game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(Power, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Applier, Civilization.Fire);
        }
    }
}
