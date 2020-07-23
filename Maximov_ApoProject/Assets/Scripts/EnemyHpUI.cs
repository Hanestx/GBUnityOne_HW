using UnityEngine;


namespace ApoProject
{
    public class EnemyHpUI : MonoBehaviour
    {
        public string HpShow
        {
            set { GetComponent<TextMesh>().text = value; }
        }
    }
}
