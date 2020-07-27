using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApoProject
{
    public class KillCount : MonoBehaviour
    {
        [SerializeField] int _killCount;
        //WinScreen




        public void KillCounts(int d)
        {
            _killCount += d;
            if (_killCount >= 9)
            {
                
            }
        } 
    }
}
