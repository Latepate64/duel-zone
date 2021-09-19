using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using DuelMastersModels.Zones;

namespace DuelMastersModels.Managers
{
    public interface IAbilityManager
    {
        bool IsAbilityBeingResolved { get; }
        bool IsAbilityBeingResolvedSpellAbility { get; }

        PlayerActionWithEndInformation ContinueResolution(Duel duel);
        ICollection<IContinuousEffect> GetContinuousEffectsGeneratedByCard(Card card, IPlayer player, BattleZone battleZone);
        int GetSpellAbilityCount(Spell spell);
        void RemovePendingAbility(NonStaticAbility ability);
        void SetAbilityBeingResolved(NonStaticAbility ability);
        void StartResolvingSpellAbility(Spell spell);
        void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(IEnumerable<Creature> creatures);
        void TriggerWheneverAPlayerCastsASpellAbilities(IEnumerable<Creature> creatures);
        void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(Creature creature);
        SelectAbilityToResolve TryGetSelectAbilityToResolve(IPlayer player);
    }
}