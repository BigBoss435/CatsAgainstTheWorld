using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAferSeconds;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAferSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale  = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left
        {
            rotation.z = 90f;
        }
        else if (dirx == 0 &&  diry < 0) //down
        {
            rotation.z = 180f;
        }
        else if (dirx == 0 && diry > 0) //up
        {
            rotation.z = 0f;
            
        }
        else if (dir.x > 0 && dir.y > 0) //right up
        {
            rotation.z = -45f;
        }
        else if (dir.x > 0 && dir.y < 0) //right down
        {
            rotation.z = -145f;
        }
        else if (dir.x < 0 && dir.y > 0) //left up
        {
            rotation.z = 45f;
        }
        else if (dir.x < 0 && dir.y < 0) //left down
        {
            rotation.z = 145f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
