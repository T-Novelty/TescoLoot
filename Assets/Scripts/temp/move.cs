using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int counter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = 0;
        SetText(counter);
    }

    private void SetText(int counter)
    {
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            counter++;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.Beep();
#endif
            SetText(counter);
        }

    }
}
