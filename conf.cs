using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class conf
    {
        public static double startDif = 1.0, endgame = 10.0;
        public static List<string> ExtensionNames = new List<string> {"Factoria (Se especializa en fabrica de bombas nucleares, produccion de seres magicos," +
            " o Reactores Nucleares Modulares (Reducen coste produccion de Expansiones)"),
            "Enriquecidora de Uranio (Bueno Combinar con mina de uranio de alto nivel, imprecindible para hacer los primeros reactores breeder)",
            "Pacer (Reactor que usa detonaciones fision-fusion subterraneas, util para tener suficiente energia y producir Pu239 o U233 de forma mas rapida, muy recomendado)",
            "Enriquecidora de Litio(Util para bombas termonucleares, pero no imprescindible)",
        "Instalacion de investigacion nuclear(Acelera el desarrollo de tecnologia nuclear, mas que el uso de armas nucleares)",
            "Enriquecidora de Hidrogeno(imprescindible para armas termonucleares, BoostedFission, y reactores de Agua pesada)",
            "Mina de Uranio(Extraccion maritima incluida)","Mina de Torio(nesesario para producir U233, extraccion mas rapida que con uranio, transmutacion a U233 muy lenta," +
            "puede casi sustituir al Uranio en armas termonucleares)",
        "Mina de Berilio(Be aumenta Breeding ratio de reactor Pacer, recomendado en primarios de bombas thermonucleares, pero no nesesario)",
        "Mina de Litio (Nesesario para produccion de Tritio si no se dispone de Deuterio, muy recomendado para armas termonucleares)",
            "Mina de Materiales no Fisibles o Fertiles para contencion de Radiacion X(Ejemplo: Plomo, Tungsteno), disminuye el uso de Uranio o torio en armas nucleares pero disminuye la potencia de estas",
            "Instalacion de Investigacion Magica, (Investiga la extraña tecnologia del enemigo para crear algo mas poderoso," +
            " un ser de nivel lo bastante alto puede acceder al trono de los monstruos (y ganar la partida))"

        };
        public static List<string> ShortExtensionNames = new List<string> {"Fact",
            "U E","PACER","Li E",
        "Nuclear I+D","D E","U M","Th M","Be M",
        "Li M","HighZ M",
            "Magic I+D"
        };
        public static readonly Dictionary<string, double> SC = new Dictionary<string, double> {
        { "NuclearTechLevel", 0.1},
        {"MagicalTechLevel",0.2},
        { "elecpower", 4000.0 },
        { "U", 1000.0 },
        { "Pu239", 0.0},
        { "Th", 5000.0 },
        { "U233", 0.0001 },
        { "Li", 10.0 },
        { "Be", 0.5 },
        { "H2", 4000.0 },
        { "H3", 0.01 },
        { "NFRCM", 16000.0 }};
        public static readonly Dictionary<string, double> NuclearTechLevelAndAvailableTech = new Dictionary<string, double>
        {
            {"FissionImplotion",0.05 },
            {"DTBoostedFission",0.08},
            {"10MT_2StagedCylindricalRadiationImplotion",0.12 },
            {"1MT_RadiationImplotion",0.15 },
            {"3orMoreStagedDesing",0.2 },
            {"subMT_RadiationImplotion",0.25},
            {"SphericalRadiationImplotion",0.7},
            {"Sub20KT_radiationImplotion",0.8},
            {"Sub2KT_radiationImplotion",0.85},
            {"SubKT_radiationImplotion",0.95},
            {"DeuterideOfFissionFuelInPrimary",0.99}

        };
        public static readonly Dictionary<string, double> MJperKG = new Dictionary<string, double>
        {
            {"U233",79420000.0},
            {"U235",79390000.0},
            {"Pu239",80620000.0}
        };
        public static readonly Dictionary<string, double> BareSphereCriticalMass = new Dictionary<string, double>
        {
            {"U233",16.0},
            {"U235",47.0},
            {"Pu239",10.0},
        };
        public static readonly Dictionary<string, double> MaxSuperCriticalMassBeforePredetonation = new Dictionary<string, double>
        {
            {"U233",50.0},
            {"U235",120.0},
            {"Pu239",22.0},
        };
        public static readonly Dictionary<string, double> RadiationImplotionMultPerFusionFuelFor1MT = new Dictionary<string, double>
        {
            {"Li6D",100.0},
            {"Li7D",30.0},
            {"D", 10.0},
            {"1P_9D",7.5}
        };
        public static readonly Dictionary<string, double> FusionStageSparkPlugMinMassPerMeter = new Dictionary<string, double>
        {
            {"U233",1.6},
            {"U235",4.8},
            {"50%U235",70},
            {"Pu239",1.0},
        };
        public static readonly Dictionary<string, double> KTperKG = new Dictionary<string, double>
        {
            {"U233",18.98},
            {"U235",18.9746},
            {"Pu239",19.2686},
            {"Li6D",64.0},
            {"Li7D",38.5},
            {"D", 82.2},
            {"1P_9D",86.3}
        };
        public static readonly Dictionary<string, double> BaseBreedingRatio = new Dictionary<string, double> {
            {"Pacer",10.0},
            {"PureFissionBreeder", 1.3}};

        public static readonly Dictionary<string, double> concentration = new Dictionary<string, double>
        {
            {"U235",0.0071},
            {"U238",0.992836},
            {"Li6",0.0759}
        };
        public static readonly Dictionary<string, double> MiningKGPerLevelPerTurn = new Dictionary<string, double>
        {
            {"U",1.0},
            {"Th",1.8},
            {"Li",0.5},
            {"Be",0.3},
            {"NFRCM",20.0}
        };
        public static readonly Dictionary<string, double> MWhPerLevel = new Dictionary<string, double>
        {
            {"Pacer",3000.0},
            {"PureFissionBreeder",30.0},
            {"HeavyWaterModeratedFissionReactor",20.0},
            {"EnrichmentFacility",-20.0 },
            {"Mine",-60.0},
            {"Factory",-10.0}

        };
        public static readonly Dictionary<string, double> ReactorEfficiency = new Dictionary<string, double>
        {
            {"Pacer",0.28},
            {"PureFissionMetalCooledBreeder",0.45},
            {"HeavyWaterModeratedFissionReactor",0.35},
            {"SuperCriticalHeavyWaterModeratedFissionReactor",0.45}
        };
        public static readonly Dictionary<string, double> DecayChainHalfLife = new Dictionary<string, double>
        {
            {"U239ToPu239",3398.5},
            {"Th233ToU233",34560.0}
        };
        public static double KTtoMJ = 4184000.0, maxKTPerKGFissionBomb = 0.5, maxKTperKGCylindricFusionStage = 5.0, maxKTperKGSphericalFusionStage = 10.0,
            DeathOverlordStartLv;
        public static int TurnsBeforeGame = 70000;
        public static readonly Dictionary<string, double> MetaFactorySpeed = new Dictionary<string, double>
        {
            { "Fact",0.001},
            { "U E",0.008},{"NR",0.0},{"Li E",0.008},
            { "Nuclear I+D",0.0005},{"D E",0.008},{"U M",0.005},{"Th M",0.008 },{"Be M",0.008},
            { "Li M",0.008},{"HighZ M",0.01},
            { "Magic I+D",0.0001}
        };
        public static readonly Dictionary<string, double> BaseBuildTime = new Dictionary<string, double>
        {
            { "Fact",100.0},
            { "U E",50.0},{"NR",400.0},{"Li E",50.0},
            { "Nuclear I+D",100.0},{"D E",10.0},{"U M",200.0},{"Th M",200.0 },{"Be M",200.0},
            { "Li M",200.0},{"HighZ M",200.0},
            { "Magic I+D",100.0}
        };
        public static readonly Dictionary<string, double> BaseBuildTimeMaxFractionalReductionFromSMR = new Dictionary<string, double>
        {
            { "Fact",0.01},
            { "U E",0.05},{"NR",0.001},{"Li E",0.05},
            { "Nuclear I+D",0.001},{"D E",0.05},{"U M",0.002},{"Th M",0.05},{"Be M",0.05},
            { "Li M",0.05},{"HighZ M",0.05},
            { "Magic I+D",0.0001}
        };


    }