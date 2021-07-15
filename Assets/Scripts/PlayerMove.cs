using System;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PlayerMove : NetworkBehaviour
{
    public Transform playerBody;
    public Transform cameraArm;
    private Rigidbody m_Rigidbody;
    private Animator animator;
    private bool isJumping;
    private void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
        isJumping = false;

        if (IsLocalPlayer)
        {
            transform.Find("CamArm").gameObject.SetActive(true);
            animator = playerBody.GetComponent<Animator>();
        }
    }

    public NetworkVariableVector3 Position = new NetworkVariableVector3(new NetworkVariableSettings
    {
        WritePermission = NetworkVariablePermission.ServerOnly,
        ReadPermission = NetworkVariablePermission.Everyone
    });

    public override void NetworkStart()
    {
        this.DefaultPosition();
    }

    private void DefaultPosition()
    {
        var defaultPosition = new Vector3(10,2,0);
        transform.position = defaultPosition;
        Position.Value = defaultPosition;
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
            x = Mathf.Clamp(x, -1f, 70f);
        else
            x = Mathf.Clamp(x, 335f, 361f);

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    private void Walk()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        float offset = 1f + Input.GetAxis("Sprint");
        float moveParam;
        float speed = 2;
        moveParam = Mathf.Abs(moveInput.normalized.magnitude * offset);

        // animator.SetBool("IsMove", isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            Vector3 moveSpeed = moveDir * Time.deltaTime * speed;
            playerBody.forward = moveDir;

            if (Input.GetAxis("Sprint") > 0)

                transform.position += moveSpeed * 2;
            else
                transform.position += moveSpeed;
        }
        animator.SetFloat("MoveSpeed", moveParam);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                m_Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                isJumping = true;
                animator.SetBool("IsJump", isJumping);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Untagged") && IsLocalPlayer)
        {
            isJumping = false;
            animator.SetBool("IsJump", isJumping);
        }
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            this.Jump();
            this.Walk();
            this.LookAround();
        }
    }
}

