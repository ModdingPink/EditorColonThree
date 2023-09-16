using HarmonyLib;
using HMUI;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace EditorColonThree.Patches
{
    internal class EditorMovePatch
    {
        [HarmonyPatch(typeof(MainMenuViewController))]
        [HarmonyPatch("DidActivate")]
        [HarmonyPriority(Priority.Last)]

        internal class ScrollViewStickDrift
        {
            private static void Postfix(ref Button ____beatmapEditorButton, ref Button ____optionsButton, ref Button ____musicPackPromoButton)
            {
                if(Config.Instance.Location == "Left" || Config.Instance.Location == "Right")
                {
                    float xValue = 2.1f;
                    if (____musicPackPromoButton.gameObject.active)
                    {
                        if (Config.Instance.Location == "Left") xValue = -1.8f;
                        else if (Config.Instance.Location == "Right") xValue = 2.1f;
                    }
                    else
                    {
                        if (Config.Instance.Location == "Left") xValue = -1.5f;
                        else if (Config.Instance.Location == "Right") xValue = 1.8f;
                    }
                    ____beatmapEditorButton.transform.SetParent(____optionsButton.transform.parent.parent, true);
                    ____beatmapEditorButton.transform.position = new Vector3(xValue, 0.375f, 4.35f);
                }else if(Config.Instance.Location == "Hidden")
                {
                    ____beatmapEditorButton.gameObject.SetActive(false);
                }
                //could this have been done a lot better? Yes! Do I care? No!
            }
        }
    }
}
