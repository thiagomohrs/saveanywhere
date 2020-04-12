using MSCLoader;
using System;
using UnityEngine;
using HutongGames.PlayMaker;

namespace SaveAnywhere
{
    public class SaveAnywhere : Mod
    {
        public override string ID => "SaveAnywhere"; //Your mod ID (unique)
        public override string Name => "SaveAnywhere"; //You mod name
        public override string Author => "Dibouas"; //Your Username
        public override string Version => "1.0"; //Version

        private GameObject PLAYER;

        // Keybinds
        private Keybind saveKey = new Keybind("KeyID", "Key name", KeyCode.S, KeyCode.LeftControl);

        // Set this to true if you will be load custom assets from Assets folder.
        // This will create subfolder in Assets folder for your mod.
        public override bool UseAssetsFolder => false;

        public override void OnLoad()
        {
            Keybind.Add(this, saveKey); //register keybind for this class
            ModConsole.Print("SaveAnywhere has been loaded!"); //print debug information
        }

        public override void Update()
        {
            {
                if (saveKey.GetKeybind())
                {
                    PLAYER = GameObject.Find("PLAYER");
                    PlayMakerFSM[] componentsInChildren = PLAYER.GetComponentsInChildren<PlayMakerFSM>();
                    ModConsole.Print("PlayMakerFSM");
                    for (int i = 0; i < componentsInChildren.Length; i++)
                    {
                        PlayMakerFSM playMakerFSM = componentsInChildren[i];
                    }
                    PlayMakerFSM.BroadcastEvent("SAVEGAME");
                    Application.LoadLevel("MainMenu");
                }
            }
        }

        static void Main() { }
    }
}
