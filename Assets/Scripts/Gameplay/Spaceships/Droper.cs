using System.Collections.Generic;
using Gameplay.Items;
using UnityEngine;

public class Droper : MonoBehaviour
{
    [SerializeField] private List<ItemBase> items;

    public void DropItem()
    {
        float chanceEmpty = Random.Range(0, 1f);
        if (chanceEmpty < 0.5f)
        {
            Instantiate(items[Random.Range(0, items.Count)], gameObject.transform.position,
                Quaternion.Euler(Vector3.zero));
        }
    }
}