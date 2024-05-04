using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UIElements;

namespace RandomWeaponEveryLevel;

[HarmonyPatch(typeof(SceneHelper), "LoadScene")]
internal class RandomWeaponSelection {

    private static readonly string[] weaponIDs = {"rev", "sho", "nai", "rai", "rock"};
    private static string lastWeapon = "";

    private static void Postfix(SceneHelper __instance) {

        string chosenWeapon;
        do {
            chosenWeapon = GetRandomWeapon();
        } while (lastWeapon == chosenWeapon);

        bool isAlternate = UnityEngine.Random.Range(0, 100) >= 50;

        if (SceneHelper.CurrentScene != "Main Menu" && SceneHelper.CurrentScene != "Turorial" && SceneHelper.CurrentScene != "Credits") {
            
            if (lastWeapon != "")
                MonoSingleton<PrefsManager>.Instance.SetInt("weapon." + lastWeapon, 0);
            MonoSingleton<PrefsManager>.Instance.SetInt("weapon." + chosenWeapon, isAlternate ? 2 : 1);
            lastWeapon = chosenWeapon;
            
        }
    }

    private static string GetRandomWeapon() {
        string chosenWeapon = weaponIDs[UnityEngine.Random.Range(0,weaponIDs.Length)];
        int chosenVariant = UnityEngine.Random.Range(0, 3);
        return chosenWeapon + chosenVariant;
    }
}