using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;
using UnityEngine;

namespace EditorColonThree
{
    public class Config
    {
        public static Config? Instance { get; set; }
        public virtual string Location { get; set; } = "Right";

    }
}