using System.Xml.Serialization;

namespace Server;

[XmlRoot(ElementName = "root")]
public class CardsContainer
{
    [XmlArray("cards")]
    [XmlArrayItem("creature", typeof(Creature))]
    [XmlArrayItem("spell", typeof(Spell))]
    public required Card[] Cards { get; set; }
}

public abstract class Card
{
    [XmlElement("name")]
    public required string Name { get; set; }
}

public class Creature : Card
{
    [XmlElement("power")]
    public required string Power { get; set; }
}

public class Spell : Card
{
    [XmlArray("spellAbilities")]
    [XmlArrayItem("spellAbility", typeof(SpellAbility))]
    public required SpellAbility[] SpellAbilities { get; set; }
}

[XmlInclude(typeof(ResolvableAbility))]
public abstract class Ability {}

[XmlInclude(typeof(SpellAbility))]
public abstract class ResolvableAbility : Ability
{
    [XmlElement("destroyOneOfYourOpponentsCreaturesEffect", typeof(DestroyOneOfYourOpponentsCreaturesEffect))]
    [XmlElement("tapAllYourOpponentsCreaturesEffect", typeof(TapAllYourOpponentsCreaturesEffect))]
    public required OneShotEffect OneShotEffect { get; set; }
}

public class SpellAbility : ResolvableAbility {}

[XmlInclude(typeof(TapAllYourOpponentsCreaturesEffect))]
[XmlInclude(typeof(DestroyOneOfYourOpponentsCreaturesEffect))]
public abstract class OneShotEffect {}

public class DestroyOneOfYourOpponentsCreaturesEffect : OneShotEffect {}

public class TapAllYourOpponentsCreaturesEffect : OneShotEffect {}