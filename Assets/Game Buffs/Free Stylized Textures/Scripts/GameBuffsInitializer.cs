using UnityEditor;
using UnityEngine;

namespace GameBuffs.FreeStylizedTextures
{
    [InitializeOnLoad]
    public static class GameBuffsInitializer
    {
        private const string GAMEBUFFS_INITIALIZED_FREETEXTURES = "GameBuffs.Initializer.FreeStylizedTextures";
        private const string GAMEBUFFS_MEGAPACK_URL = "https://prf.hn/l/pmlPp2k";

        /// <summary>
        /// Initialize Game Buffs asset on first install
        /// </summary>
        static GameBuffsInitializer()
        {
            var initializedFreeTextures = EditorPrefs.GetBool(GAMEBUFFS_INITIALIZED_FREETEXTURES, false);
            if (!initializedFreeTextures)
            {
                EditorPrefs.SetBool(GAMEBUFFS_INITIALIZED_FREETEXTURES, true);

                OpenMegapackUrl();
            }
        }

        /// <summary>
        /// Open the Megapack URL the first time the asset is installed
        /// </summary>
        private static void OpenMegapackUrl()
        {
            Application.OpenURL(GAMEBUFFS_MEGAPACK_URL);
        }
    }
}