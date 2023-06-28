using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class WindAxeTheWarriorSavage : Creature
    {
        public WindAxeTheWarriorSavage() : base("Wind Axe, the Warrior Savage", 5, 2000, Race.Human, Race.BeastFolk, Civilization.Fire, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageEffect());
        }
    }

    class WindAxeTheWarriorSavageEffect : OneShotEffect
    {
        public WindAxeTheWarriorSavageEffect()
        {
        }

        public WindAxeTheWarriorSavageEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new WindAxeTheWarriorSavageEffect(this);
        }

        public override void Apply(IGame game)
        {
            Applier.DestroyOpponentsBlocker(game, Ability);
            Applier.PutFromTopOfDeckIntoManaZone(1, Ability);
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\" Then put the top card of your deck into your mana zone.";
        }
    }
}
