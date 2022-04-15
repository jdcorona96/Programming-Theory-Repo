using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject _attackObject;
    private GameObject ability;

    [SerializeField] float horizontalMvmt;
    [SerializeField] float verticalMvmt;
    [SerializeField] float speed;
    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _attackObject = transform.Find("AbsorbAttack").gameObject;

    }

    void Update()
    {
        PlayerMovement();

        bool spaceBar = Input.GetKey(KeyCode.Space);

        if(spaceBar) {
            _attackObject.SetActive(true);
        } else {
            _attackObject.SetActive(false);

        }
    }

    void PlayerMovement() {

        horizontalMvmt = Input.GetAxis("Horizontal");
        verticalMvmt = Input.GetAxis("Vertical");

        // velocity

        _rb.AddForce(new Vector3(horizontalMvmt, _rb.velocity.y, verticalMvmt) 
            * speed, ForceMode.Impulse);

        Vector3 movement = new Vector3(horizontalMvmt, 0.0f, verticalMvmt);

        if(movement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(movement), 0.05F);

    }

}
