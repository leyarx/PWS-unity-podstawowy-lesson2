using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CombatBase))]
public class PlayerControl : MonoBehaviour
{
    private CombatBase Combat;
    // Start is called before the first frame update
    void Start()
    {
        Combat = GetComponent<CombatBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Combat.TryAttack();
        }
    }
}
