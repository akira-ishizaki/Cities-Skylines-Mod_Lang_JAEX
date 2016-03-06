using ICities;
using System.Collections.Generic;
using UnityEngine;

namespace Mod_Lang_JAEX
{
    public class Loader : LoadingExtensionBase
    {
        private GameObject _gameObject;
        private DecorationPropertiesPanelTranslator _translator;

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode == LoadMode.NewAsset || mode == LoadMode.LoadAsset)
            {
                if (Mod_Lang_JAEX.ModConf.LocalizeAssetEditor)
                {
                    _gameObject = new GameObject("Mod_Lang_JAEX");
                    _translator = _gameObject.AddComponent<DecorationPropertiesPanelTranslator>();
                }
            }
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            if (_translator != null) UnityEngine.Object.Destroy(_translator);
            if (_gameObject != null) UnityEngine.Object.Destroy(_gameObject);
        }
    }
}