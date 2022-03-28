using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine.Abilities;

namespace Cards
{
    abstract class Creature : CardImplementation
    {
        /// <summary>
        /// This constructor should be used for cards with one subtype.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="power"></param>
        /// <param name="race"></param>
        /// <param name="civilizations"></param>
        protected Creature(string name, int manaCost, int power, Subtype race, params Civilization[] civilizations) : this(name, manaCost, power, civilizations)
        {
            Subtypes.Add(race);
        }

        /// <summary>
        /// This constructor should be used for multicolored cards. Add subtypes for the card in the constructor of the inheritor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="power"></param>
        protected Creature(string name, int manaCost, int power, params Civilization[] civilizations) : base(CardType.Creature, name, manaCost, power, civilizations)
        {
            Power = power;
        }

        #region Static abilities
        protected void AddBlockerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }

        protected void AddThisCreatureCannotAttackAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }

        protected void AddSlayerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }

        protected void AddPowerAttackerAbility(int power)
        {
            AddStaticAbilities(new PowerAttackerEffect(power));
        }

        protected void AddThisCreatureCannotBeBlockedAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }

        protected void AddDoubleBreakerAbility()
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }

        protected void AddTripleBreakerAbility()
        {
            AddStaticAbilities(new TripleBreakerEffect());
        }

        protected void AddThisCreatureCannotAttackPlayersAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }

        protected void AddThisCreatureCanAttackUntappedCreaturesAbility()
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }

        protected void AddSpeedAttackerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }

        protected void AddThisCreatureCannotBeAttackedAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
        }
        #endregion Static abilities

        #region Triggered abilities
        protected void AddTriggeredAbility(ITriggeredAbility ability)
        {
            AddAbilities(ability);
        }

        protected void AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(effect));
        }

        protected void AddAtTheEndOfYourTurnAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(effect));
        }

        protected void AddWheneverThisCreatureAttacksAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(effect));
        }

        protected void AddWhenThisCreatureIsDestroyedAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(effect));
        }
        #endregion Triggered abilities

        protected void AddTapAbility(IOneShotEffect effect)
        {
            AddAbilities(new TapAbility(effect));
        }
    }
}
