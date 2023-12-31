﻿using IPA;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using Conf = IPA.Config.Config;
using HarmonyLib;
using System.Reflection;
using System.IO;
using UnityEngine;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.IO.Compression;
using EditorColonThree.Installers;
using EditorColonThree;

namespace EditorColonThree
{
    [Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
    public class Plugin
    {
        internal static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();
        internal static IPALogger Log { get; private set; }


        [Init]
        public Plugin(IPALogger logger, Conf conf, Zenjector zenjector)
        {

            Config.Instance = conf.Generated<Config>();
            Log = logger;
            zenjector.UseLogger(logger);
            zenjector.Install<MenuInstaller>(Location.Menu);

         
        }

        [OnStart]
        public void OnStart()
        {
            var harmony = new Harmony("Pink.EditorColonThree");
            harmony.PatchAll(Assembly);
         
        }
    }
}
