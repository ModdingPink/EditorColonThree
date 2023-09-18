using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components.Settings;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Settings;
using UnityEngine;
using Zenject;

namespace EditorColonThree.UI
{
	public class Menu : MonoBehaviour, IInitializable, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = null!;

        [UIValue("list-options")]
        private List<object> options = new object[] { "Right", "Left", "Hidden", "Default" }.ToList();

        [UIValue("list-choice")]
        private string listChoice = "Right";

        [UIValue("launch-chromapper")]
        private bool launchChroMapper = true;

        [UIAction("#apply")]
        public void OnApply()
        {
            Config.Instance.Location = listChoice;
            Config.Instance.LaunchChroMapper = launchChroMapper;
        }


        public void Initialize()
		{
            BSMLSettings.instance.AddSettingsMenu("EditorColonThree", "EditorColonThree.UI.Menu.bsml", this);
		}
	}
}
