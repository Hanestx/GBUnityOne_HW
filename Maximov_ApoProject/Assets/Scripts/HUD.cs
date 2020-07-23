using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ApoProject
{
    public class HUD : MonoBehaviour
    {
        public string Count
        {
            set
            {
                GetComponent<Text>().text = value;
            }
        }
    }
}
