using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CombatBase))]
public class PlayerControl : MonoBehaviour
{
    private CombatBase cb;
    // Start is called before the first frame update
    void Start()
    {
        cb = GetComponent<CombatBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cb.TryAttack();
        }
    }
}
