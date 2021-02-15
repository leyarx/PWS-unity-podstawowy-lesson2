using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatBase : MonoBehaviour
{
    // For debugging purpose
    [SerializeField]
    List<CombatBase> cb;

    public float Health = 100f;
    public float Damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cb = new List<CombatBase>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != this.tag)
        {
            CombatBase col = collision.gameObject.GetComponent<CombatBase>();
            if (col && !cb.Contains(col))
            {
                cb.Add(col);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != this.tag)
        {
            CombatBase col = collision.gameObject.GetComponent<CombatBase>();
            if (col && cb.Contains(col))
            {
                cb.Remove(col);
            }
        }
    }

    public void TryAttack()
    {
        // Check for destroyed objects
        cb.RemoveAll(item => item == null);

        if (cb.Count() == 0)
            return;

        cb = cb.OrderBy((x) => Vector3.Distance(cb[0].transform.position, this.transform.position)).ToList();

        // Attack first opponent in the list
        cb[0].TakeDamage(Damage);
    }

    void TakeDamage(float amount)
    {
        Health -= amount;

        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
