using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecer : MonoBehaviour
{
    public TMPro.TMP_Text text;
        void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); 
    }
}
