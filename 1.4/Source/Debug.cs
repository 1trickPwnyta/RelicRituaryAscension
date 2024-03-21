namespace RelicRituaryAscension
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{RelicRituaryAscensionMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
