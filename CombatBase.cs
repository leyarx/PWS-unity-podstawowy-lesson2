using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatBase : MonoBehaviour
{
    // For debugging purpose
    [SerializeField]
    List<CombatBase> Oponents;

    public float Health = 100f;
    public float Damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Oponents = new List<CombatBase>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != this.tag)
        {
            CombatBase Oponent = collision.gameObject.GetComponent<CombatBase>();
            if (Oponent && !Oponents.Contains(Oponent))
            {
                Oponents.Add(Oponent);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != this.tag)
        {
            CombatBase Oponent = collision.gameObject.GetComponent<CombatBase>();
            if (Oponent && Oponents.Contains(Oponent))
            {
                Oponents.Remove(Oponent);
            }
        }
    }

    public void TryAttack()
    {
        // Check for destroyed objects
        // Destroy() method don't call OnCollisionExit
        Oponents.RemoveAll(item => item == null);

        if (Oponents.Count() == 0)
            return;

        Oponents = Oponents.OrderBy((x) => Vector3.Distance(Oponents[0].transform.position, this.transform.position)).ToList();

        // Attack first opponent in the list
        Oponents[0].TakeDamage(Damage);
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
