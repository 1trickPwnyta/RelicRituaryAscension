using Verse;

namespace RelicRituaryAscension
{
    public class RelicRituaryAscensionMod : Mod
    {
        public const string PACKAGE_ID = "relicrituaryascension.1trickPwnyta";
        public const string PACKAGE_NAME = "Relic Rituary Ascension";

        public RelicRituaryAscensionMod(ModContentPack content) : base(content)
        {
            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
