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
  [SerializeField]
  GameObject resourcePoolPrefab = null;
  [SerializeField]
  int startingPools = 3;

  List<ResourcePool> componentPools = new List<ResourcePool>();

  int componentCount = 0;

  static public bool TakeComponentIfAvailable(int componentID)
  {
    ResourcePool pool = Instance.componentPools[componentID - 1];
    return pool.TakeSome();
  }

  static public void AwardComponents(int componentID, int amount)
  {
    if (componentID - 1 >= Instance.componentPools.Count) Instance.AddResourcePool();
    ResourcePool pool = Instance.componentPools[componentID - 1];
    pool.CreateSome(amount);
  }

  static public int GetComponentQuantity()
  {
    return Instance.componentCount;
  }
  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    foreach (Transform T in resourcePoolParent.transform) Destroy(T.gameObject);
    for (int i = 0; i < startingPools; ++i)
    {
      ResourcePool pool = AddResourcePool();
      pool.CreateSome(Random.Range(2, 6));
    }
  }

  private ResourcePool AddResourcePool()
  {
    ResourcePool pool = Instantiate(resourcePoolPrefab, resourcePoolParent.transform).GetComponent<ResourcePool>();
    InitializeResourcePool(pool);
    return pool;
  }

  private void InitializeResourcePool(ResourcePool pool)
  {
    if (!pool)
    {
      Debug.LogError("Non resource pool type found in resource pool parent");
      return;
    }

    Resource resource = pool.GetResource();
    resource.DisplayFilled();

    componentPools.Add(pool);
    resource.SetComponentID(++componentCount);
    pool.UpdateName(componentCount);
    pool.UpdatePrice(componentCount);
  }
}
