using DuelMastersCards.Cards;
using DuelMastersModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards
{
    public static class CardFactory
    {
        static public Card Create(string name)
        {
            return _cards[name].Invoke();
        }

        static public IEnumerable<Card> CreateAll()
        {
            return _cards.Select(x => x.Value.Invoke());
        }

        #region Card names
        const string AquaBouncer = "Aqua Bouncer";
        const string AquaHulcus = "Aqua Hulcus";
        const string AquaShooter = "Aqua Shooter";
        const string AquaSurfer = "Aqua Surfer";

        const string BalzaSeekerOfHyperpearls = "Balza, Seeker of Hyperpearls";
        const string BatteryCluster = "Battery Cluster";
        const string BlizzardOfSpears = "Blizzard of Spears";
        const string BombazarDragonOfDestiny = "Bombazar, Dragon of Destiny";
        const string BronzeArmTribe = "Bronze-Arm Tribe";
        const string BurningMane = "Burning Mane";
        const string BurstShot = "Burst Shot";

        const string CometMissile = "Comet Missile";
        const string Corile = "Corile";
        const string CraniumClamp = "Cranium Clamp";
        const string CrimsonHammer = "Crimson Hammer";

        const string DarkRavenShadowOfGrief = "Dark Raven, Shadow of Grief";
        const string DeadlyFighterBraidClaw = "Deadly Fighter Braid Claw";
        const string DiaNorkMoonlightGuardian = "Dia Nork, Moonlight Guardian";

        const string Emeral = "Emeral";
        const string EmeraldGrass = "Emerald Grass";
        const string EngbeltTheSpydroid = "Engbelt, the Spydroid";
        const string ExplosiveDudeJoe = "Explosive Dude Joe";

        const string FantasyFish = "Fantasy Fish";
        const string FearFang = "Fear Fang";
        const string FerrosaturnSpectralKnight = "Ferrosaturn, Spectral Knight";

        const string GhostTouch = "Ghost Touch";
        const string Gigabalza = "Gigabalza";
        const string GontaTheWarriorSavage = "Gonta, the Warrior Savage";
        const string GranGureSpaceGuardian = "Gran Gure, Space Guardian";
        const string GrayBalloonShadowOfGreed = "Gray Balloon, Shadow of Greed";

        const string HazardCrawler = "Hazard Crawler";
        const string HeartyCapnPolligon = "Hearty Cap'n Polligon";
        const string HolyAwe = "Holy Awe";
        const string HorridWorm = "Horrid Worm";
        const string HunterCluster = "Hunter Cluster";
        const string HunterFish = "Hunter Fish";

        const string ImmortalBaronVorg = "Immortal Baron, Vorg";

        const string KamikazeChainsawWarrior = "Kamikaze, Chainsaw Warrior";
        const string KanesillTheExplorer = "Kanesill, the Explorer";
        const string KingCoral = "King Coral";

        const string Locomotiver = "Locomotiver";
        const string LaUraGigaSkyGuardian = "La Ura Giga, Sky Guardian";

        const string MadrillonFish = "Madrillon Fish";
        const string Magmarex = "Magmarex";
        const string MagrisVizierOfMagnetism = "Magris, Vizier of Magnetism";
        const string MarineFlower = "Marine Flower";
        const string MelniaTheAquaShadow = "Melnia, the Aqua Shadow";
        const string MelodicHunter = "Melodic Hunter";
        const string MikayRattlingDoll = "Mikay, Rattling Doll";
        const string MistRiasSonicGuardian = "Mist Rias, Sonic Guardian";

        const string NaturalSnare = "Natural Snare";
        const string NightMasterShadowOfDecay = "Night Master, Shadow of Decay";

        const string QuixoticHeroSwineSnout = "Quixotic Hero Swine Snout";

        const string PalaOlesisMorningGuardian = "Pala Olesis, Morning Guardian";
        const string PetrovaChannelerOfSuns = "Petrova, Channeler of Suns";
        const string PhantomDragonsFlame = "Phantom Dragon's Flame";
        const string PhantomFish = "Phantom Fish";
        const string PoltalesterTheSpydroid = "Poltalester, the Spydroid";
        const string ProwlingElephish = "Prowling Elephish";
        const string PyrofighterMagnus = "Pyrofighter Magnus";

        const string RevolverFish = "Revolver Fish";
        const string RikabuTheDismantler = "Rikabu, the Dismantler";
        const string RikabusScrewdriver = "Rikabu's Screwdriver";

        const string SariusVizierOfSuppression = "Sarius, Vizier of Suppression";
        const string Seamine = "Seamine";
        const string SenatineJadeTree = "Senatine Jade Tree";
        const string SniperMosquito = "Sniper Mosquito";
        const string Soulswap = "Soulswap";
        const string SpasticMissile = "Spastic Missile";
        const string SupersonicJetPack = "Supersonic Jet Pack";
        const string SzubsKinTwilightGuardian = "Szubs Kin, Twilight Guardian";

        const string TenTonCrunch = "Ten-Ton Crunch";
        const string TerrorPit = "Terror Pit";
        const string TidePatroller = "Tide Patroller";
        const string Torcon = "Torcon";
        const string TornadoFlame = "Tornado Flame";
        const string TriHornShepherd = "Tri-Horn Shepherd";
        const string TwinCannonSkyterror = "Twin-Cannon Skyterror";

        const string ValkyerStarstormElemental = "Valkyer, Starstorm Elemental";
        const string VessTheOracle = "Vess, the Oracle";
        const string VolcanicArrows = "Volcanic Arrows";
        const string VolcanoCharger = "Volcano Charger";

        const string WanderingBraineater = "Wandering Braineater";
        const string WindAxeTheWarriorSavage = "Wind Axe, the Warrior Savage";
        const string WindmillMutant = "Windmill Mutant";

        const string Zepimeteus = "Zepimeteus";
        #endregion Card names

        static readonly private Dictionary<string, Func<Card>> _cards = new()
        {
            { AquaBouncer, () => new AquaBouncer() },
            { AquaHulcus, () => new AquaHulcus() },
            { AquaShooter, () => new AquaShooter() },
            { AquaSurfer, () => new AquaSurfer() },

            { BalzaSeekerOfHyperpearls, () => new BalzaSeekerOfHyperpearls() },
            { BatteryCluster, () => new BatteryCluster() },
            { BlizzardOfSpears, () => new BlizzardOfSpears() },
            { BombazarDragonOfDestiny, () => new BombazarDragonOfDestiny() },
            { BronzeArmTribe, () => new BronzeArmTribe() },
            { BurningMane, () => new BurningMane() },
            { BurstShot, () => new BurstShot() },

            { CometMissile, () => new CometMissile() },
            { Corile, () => new Corile() },
            { CraniumClamp, () => new CraniumClamp() },
            { CrimsonHammer, () => new CrimsonHammer() },

            { DarkRavenShadowOfGrief, () => new DarkRavenShadowOfGrief() },
            { DeadlyFighterBraidClaw, () => new DeadlyFighterBraidClaw() },
            { DiaNorkMoonlightGuardian, () => new DiaNorkMoonlightGuardian() },

            { Emeral, () => new Emeral() },
            { EmeraldGrass, () => new EmeraldGrass() },
            { EngbeltTheSpydroid, () => new EngbeltTheSpydroid() },
            { ExplosiveDudeJoe, () => new ExplosiveDudeJoe() },

            { FantasyFish, () => new FantasyFish() },
            { FearFang, () => new FearFang() },
            { FerrosaturnSpectralKnight, () => new FerrosaturnSpectralKnight() },

            { GhostTouch, () => new GhostTouch() },
            { Gigabalza, () => new Gigabalza() },
            { GontaTheWarriorSavage, () => new GontaTheWarriorSavage() },
            { GranGureSpaceGuardian, () => new GranGureSpaceGuardian() },
            { GrayBalloonShadowOfGreed, () => new GrayBalloonShadowOfGreed() },

            { HazardCrawler, () => new HazardCrawler() },
            { HeartyCapnPolligon, () => new HeartyCapnPolligon() },
            { HolyAwe, () => new HolyAwe() },
            { HorridWorm, () => new HorridWorm() },
            { HunterCluster, () => new HunterCluster() },
            { HunterFish, () => new HunterFish() },

            { ImmortalBaronVorg, () => new ImmortalBaronVorg() },
            
            { KamikazeChainsawWarrior, () => new KamikazeChainsawWarrior() },
            { KanesillTheExplorer, () => new KanesillTheExplorer() },
            { KingCoral, () => new KingCoral() },

            { LaUraGigaSkyGuardian, () => new LaUraGigaSkyGuardian() },
            { Locomotiver, () => new Locomotiver() },

            { MadrillonFish, () => new MadrillonFish() },
            { Magmarex, () => new Magmarex() },
            { MagrisVizierOfMagnetism, () => new MagrisVizierOfMagnetism() },
            { MarineFlower, () => new MarineFlower() },
            { MelniaTheAquaShadow, () => new MelniaTheAquaShadow() },
            { MelodicHunter, () => new MelodicHunter() },
            { MikayRattlingDoll, () => new MikayRattlingDoll() },
            { MistRiasSonicGuardian, () => new MistRiasSonicGuardian() },

            { NaturalSnare, () => new NaturalSnare() },
            { NightMasterShadowOfDecay, () => new NightMasterShadowOfDecay() },

            { PalaOlesisMorningGuardian, () => new PalaOlesisMorningGuardian() },
            { PetrovaChannelerOfSuns, () => new PetrovaChannelerOfSuns() },
            { PhantomDragonsFlame, () => new PhantomDragonsFlame() },
            { PhantomFish, () => new PhantomFish() },
            { PoltalesterTheSpydroid, () => new PoltalesterTheSpydroid() },
            { ProwlingElephish, () => new ProwlingElephish() },
            { PyrofighterMagnus, () => new PyrofighterMagnus() },

            { QuixoticHeroSwineSnout, () => new QuixoticHeroSwineSnout() },

            { RevolverFish, () => new RevolverFish() },
            { RikabuTheDismantler, () => new RikabuTheDismantler() },
            { RikabusScrewdriver, () => new RikabusScrewdriver() },

            { SariusVizierOfSuppression, () => new SariusVizierOfSuppression() },
            { Seamine, () => new Seamine() },
            { SenatineJadeTree, () => new SenatineJadeTree() },
            { SniperMosquito, () => new SniperMosquito() },
            { Soulswap, () => new Soulswap() },
            { SpasticMissile, () => new SpasticMissile() },
            { SupersonicJetPack, () => new SupersonicJetPack() },
            { SzubsKinTwilightGuardian, () => new SzubsKinTwilightGuardian() },

            { TenTonCrunch, () => new TenTonCrunch() },
            { TerrorPit, () => new TerrorPit() },
            { TidePatroller, () => new TidePatroller() },
            { Torcon, () => new Torcon() },
            { TornadoFlame, () => new TornadoFlame() },
            { TriHornShepherd, () => new TriHornShepherd() },
            { TwinCannonSkyterror, () => new TwinCannonSkyterror() },

            { ValkyerStarstormElemental, () => new ValkyerStarstormElemental() },
            { VessTheOracle, () => new VessTheOracle() },
            { VolcanicArrows, () => new VolcanicArrows() },
            { VolcanoCharger, () => new VolcanoCharger() },

            { WanderingBraineater, () => new WanderingBraineater() },
            { WindAxeTheWarriorSavage, () => new WindAxeTheWarriorSavage() },
            { WindmillMutant, () => new WindmillMutant() },

            { Zepimeteus, () => new Zepimeteus() },
        };
    }
}
