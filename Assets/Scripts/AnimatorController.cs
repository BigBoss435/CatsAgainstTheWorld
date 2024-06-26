using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    PlayerMovement pc;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteDirectionChecker();
    }

    public void SpriteDirectionChecker()
    {
        if (pc.moveDir.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
