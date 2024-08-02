using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField]
    public StackPartController[] stackPartControllers = null;

    public void ShatterAllParts()
    {
       if(transform.parent != null)
       {
            transform.parent = null;
            FindObjectOfType<Ball>().IncreaseBrokenStacks();
       }
       
       foreach(StackPartController o in stackPartControllers)
       {
            o.Shatter();
       }
       StartCoroutine(RemoveParts());
    }
    IEnumerator RemoveParts()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
