using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM08
{
    class MigaloVizierOfSpycraft : TurboRushCreature
    {
        public MigaloVizierOfSpycraft() : base("Migalo, Vizier of Spycraft", 2, 1500, Subtype.Initiate, Civilization.Light)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new MigaloVizierOfSpycraftEffect()));
        }
    }

    class MigaloVizierOfSpycraftEffect : LookEffect
    {
        public MigaloVizierOfSpycraftEffect() : base(0, 2)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MigaloVizierOfSpycraftEffect();
        }

        public override string ToString()
        {
            return "You may look at 2 of your opponent's shields. Then put them back where they were.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetOpponent(game).ShieldZone.Cards;
        }
    }
}
