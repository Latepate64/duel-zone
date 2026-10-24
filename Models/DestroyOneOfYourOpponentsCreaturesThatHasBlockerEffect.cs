namespace Models;

public partial class DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect : OneShotEffect
{
    public override DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect Copy()
    {
        return new DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect();
    }
}
