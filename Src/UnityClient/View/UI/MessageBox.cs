using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityClient
{
    public class MessageBox : MonoBehaviour
    {
        public enum Style
        {
            OnlyOK,
            OKAndCancel,
        }
        [SerializeField]
        Text m_Text;
        [SerializeField]
        Button m_ConfirmButton;
        [SerializeField]
        Button m_CancelButton;

        public void Start()
        {
            m_ConfirmButton.onClick.AddListener(OnClickConfirmButton);
            m_CancelButton.onClick.AddListener(OnClickCancelButton);
        }
        public void Init(Style style, string message)
        {
            m_Text.text = message;

            if(style == Style.OnlyOK)
            {
                m_ConfirmButton.gameObject.SetActive(true);
                m_CancelButton.gameObject.SetActive(false);
            }else if(style == Style.OKAndCancel)
            {
                m_ConfirmButton.gameObject.SetActive(true);
                m_CancelButton.gameObject.SetActive(true);
            }
        }
        public void OnClickConfirmButton()
        {
            Destroy(gameObject);
        }
        public void OnClickCancelButton()
        {
            Destroy(gameObject);
        }
    }
}
