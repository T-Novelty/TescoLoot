using UnityEngine;
using System.Collections;

public class Character_move : MonoBehaviour {
    private Animator Animator;
    private int lane;
    // Use this for initialization
    void Start () {
        lane = 0;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Animator.SetBool("jumping", true);
            Invoke("stopJumping", 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Animator.SetBool("sliding", true);
            Invoke("stopSliding", 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lane > -1)
                lane--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lane < 1)
                lane++;
        }

        Vector3 newPosition = transform.position;
        newPosition.x = lane;
        transform.position = newPosition;
    }

    void stopJumping()
    {
        Animator.SetBool("jumping", false);
    }
    void stopSliding()
    {
        Animator.SetBool("sliding", false);
    }
}
