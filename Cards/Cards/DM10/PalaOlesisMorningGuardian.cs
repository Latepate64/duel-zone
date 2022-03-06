using Cards.CardFilters;
using Cards.StaticAbilities;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM10
{
    class PalaOlesisMorningGuardian : Creature
    {
        public PalaOlesisMorningGuardian() : base("Pala Olesis, Morning Guardian", 3, 2500, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            // During your opponent's turn, each of your other creatures gets +2000 power.
            AddAbilities(new BlockerAbility(), new StaticAbility(new PowerModifyingEffect(new PalaOlesisFilter(), 2000, new Indefinite())), new CannotAttackPlayersAbility());
        }
    }
}
