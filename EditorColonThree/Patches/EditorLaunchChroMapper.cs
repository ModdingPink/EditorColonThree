using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace EditorColonThree.Patches
{
    [HarmonyPatch(typeof(MainMenuViewController))]
    [HarmonyPatch("HandleMenuButton")]

    internal class EditorLaunchChroMapper
    {
        [HarmonyPrefix]
        private static bool Prefix(ref MainMenuViewController.MenuButton menuButton)
        {
            if (menuButton == MainMenuViewController.MenuButton.BeatmapEditor)
            {
                if (Config.Instance.LaunchChroMapper)
                {
                    if (!string.IsNullOrEmpty(Config.Instance.ChroMapperLocation))
                    {
                        Plugin.Log.Info("Launching ChroMapper...");
                        Plugin.Log.Debug("ChroMapper Location: " + Config.Instance.ChroMapperLocation);
                        System.Diagnostics.Process.Start(Config.Instance.ChroMapperLocation);
                        Application.Quit();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
