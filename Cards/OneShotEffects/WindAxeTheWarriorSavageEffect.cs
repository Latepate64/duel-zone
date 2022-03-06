using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class WindAxeTheWarriorSavageEffect : OneShotEffect
    {
        public WindAxeTheWarriorSavageEffect() : base()
        {
        }

        public WindAxeTheWarriorSavageEffect(WindAxeTheWarriorSavageEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new WindAxeTheWarriorSavageEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            // Destroy one of your opponent's creatures that has "blocker."
            new DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true).Apply(game, source);

            // Then put the top card of your deck into your mana zone.
            new PutTopCardsOfDeckIntoManaZoneEffect(1).Apply(game, source);
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\" Then put the top card of your deck into your mana zone.";
        }
    }
}
