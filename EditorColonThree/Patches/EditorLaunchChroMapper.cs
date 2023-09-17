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
                        Plugin.Log.Info("Launching External Editor...");
                        Plugin.Log.Debug("Editor Location: " + Config.Instance.ChroMapperLocation);
                        var process = System.Diagnostics.Process.Start(Config.Instance.ChroMapperLocation);
                        if (process != null)
                        {
                            Plugin.Log.Info("External Editor Launched!");
                            Plugin.Log.Debug("pink cute");
                            Application.Quit();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
