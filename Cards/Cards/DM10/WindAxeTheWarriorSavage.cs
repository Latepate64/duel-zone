using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class WindAxeTheWarriorSavage : Creature
    {
        public WindAxeTheWarriorSavage() : base("Wind Axe, the Warrior Savage", 5, 2000, Civilization.Fire, Civilization.Nature)
        {
            AddSubtypes(Subtype.Human, Subtype.BeastFolk);
            AddAbilities(new PutIntoPlayAbility(new WindAxeTheWarriorSavageEffect()));
        }
    }

    class WindAxeTheWarriorSavageEffect : OneShotEffect
    {
        public override OneShotEffect Copy()
        {
            return new WindAxeTheWarriorSavageEffect();
        }

        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true), new PutTopCardsOfDeckIntoManaZoneEffect(1) })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\" Then put the top card of your deck into your mana zone.";
        }
    }
}
