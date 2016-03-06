using ColossalFramework;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Mod_Lang_JAEX
{
    internal class DecorationPropertiesPanelTranslator : MonoBehaviour
    {
        private UIScrollablePanel m_Container;
        private UIPanel m_SizePanel;

        private void Start()
        {
            m_Container = (UIScrollablePanel)typeof(DecorationPropertiesPanel).GetField("m_Container", BindingFlags.GetField | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(UIView.Find<UIPanel>("DecorationProperties").GetComponent<DecorationPropertiesPanel>());
            
            m_SizePanel = (UIPanel)typeof(DecorationPropertiesPanel).GetField("m_SizePanel", BindingFlags.GetField | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(UIView.Find<UIPanel>("DecorationProperties").GetComponent<DecorationPropertiesPanel>());
        }

        private void Update()
        {
            foreach (UITextComponent textComponent in m_SizePanel.GetComponentsInChildren<UITextComponent>())
            {
                textComponent.text = Translation.GetString(textComponent.text);
            }
            foreach (UITextComponent textComponent in m_Container.GetComponentsInChildren<UITextComponent>())
            {
                textComponent.text = Translation.GetString(textComponent.text);
            }
        }

        private void OnDestroy()
        {
            m_Container = null;
        }
    }
}
