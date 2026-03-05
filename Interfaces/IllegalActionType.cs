namespace Interfaces;

public enum IllegalActionType
{
    Unknown,
    UnexpectedType,
    UnexpectedPlayer,
    HandDoesNotContainCard,
    UseCardTappedManaForPayment,
    UseCardPaymentForManaCost,
    UseCardPaymentForCivilizations,
    AttackingCreatureIsNull,
    AttackingCreatureIsTapped,
    AttackingCreatureHasSummoningSickness,
    AttackedCreatureAndAttackedPlayerAreNull,
    AttackedCreatureAndAttackedPlayerAreNotNull,
    ChosenCardIsNull,
}