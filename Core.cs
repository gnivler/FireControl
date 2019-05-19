using System;
using System.Reflection;
using Harmony;
using Newtonsoft.Json;
using static Logger;

public class Core
{
    internal static Settings ModSettings;

    public static void Init(string modDir, string settings)
    {
        var harmony = HarmonyInstance.Create("ca.gnivler.BattleTech.DevMod");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
        // read settings
        try
        {
            ModSettings = JsonConvert.DeserializeObject<Settings>(settings);
            ModSettings.modDirectory = modDir;
        }
        catch (Exception)
        {
            ModSettings = new Settings();
        }

        Clear();
    }

    public class Settings
    {
        public bool enableDebug = false;
        public string modDirectory;
    }
}