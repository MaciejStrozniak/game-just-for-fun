using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.tag == "Player")
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
        
    }
}
