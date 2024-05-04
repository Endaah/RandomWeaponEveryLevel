using BepInEx;
using HarmonyLib;

namespace RandomWeaponEveryLevel;

[BepInPlugin("com.ender.randomweaponeverylevel", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        // Harmony
        new Harmony("com.ender.randomweaponeverylevel").PatchAll();
    }
}
