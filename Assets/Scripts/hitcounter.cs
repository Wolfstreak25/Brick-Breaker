using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class hitcounter : MonoBehaviour
{
    [SerializeField] private int MaxHit;
    private int HitCount = 0;
    public TMP_Text HP;
    void Start()
    {
        HP.text = MaxHit + "";
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ball")
        {
            HitCount += 1;
             HP.text = (MaxHit - HitCount) + "";
            if(HitCount == MaxHit)
            {
                Destroy(HP);
                Destroy(this.gameObject);
            }

        }
    }
}
