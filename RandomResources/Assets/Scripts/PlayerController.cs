// Tracks all of the player's resources and allows interaction with player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  static private PlayerController Instance
  {
    get 
    {
      if (!instance) Debug.LogError("Instance of player controller does not exist or was not awake");
      return instance;
    }
    set
    {
      if (instance) Debug.LogError("More than one player controller found! The game is broken now!");
      else instance = value;
    }
  }
  static private PlayerController instance = null;

  [SerializeField, Tooltip("All of the resource pools that the player has control of are a child of this")]
  GameObject resourcePoolParent = null;

  int componentCount = 0;
  int productCount = 0;

  static public int GetComponentQuantity()
  {
    return Instance.componentCount;
  }

  static public int GetProductQuantity()
  {
    return Instance.productCount;
  }

  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    foreach (Transform t in resourcePoolParent.transform)
    {
      ResourcePool pool = t.GetComponent<ResourcePool>();
      if (!pool)
      {
        Debug.LogError("Non resource pool type found in resource pool parent");
        continue;
      }

      Resource resource = pool.GetResource();

      if (pool.resourceType == ResourcePool.ResourceType.Component)
      {
        pool.CreateSome(Random.Range(2, 6));
        resource.SetComponentID(componentCount++);
      }
      else 
      {
        resource.SetProductID(productCount++);
      }
      
    }
  }
}
