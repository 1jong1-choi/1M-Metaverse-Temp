using System.Collections;
using System.Collections.Generic;
using MLAPI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform cameraArm;
    private Rigidbody m_Rigidbody;
    private Animator m_Animator;
    private bool m_IsJumping;
    private Vector3 m_MoveSpeed;
    private Vector2 m_Move;
    private Vector2 m_Look;
    private float m_Sprint;
    private float m_Jump;

    private void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
        m_IsJumping = false;

        if (IsLocalPlayer)
        {
            transform.Find("CamArm").gameObject.SetActive(true);
            m_Animator = playerBody.GetComponent<Animator>();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        m_Sprint = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        m_Jump = context.ReadValue<float>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        bool isMove = direction.magnitude != 0;
        float offset = 1f + m_Sprint;
        float moveParam;
        float speed = 2;
        moveParam = Mathf.Abs(direction.normalized.magnitude * offset);

        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * direction.y + lookRight * direction.x;
            m_MoveSpeed = moveDir * Time.deltaTime * speed;
            playerBody.forward = moveDir;

            if (m_Sprint > 0)
                transform.position += m_MoveSpeed * 2;
            else
                transform.position += m_MoveSpeed;
        }
        m_Animator.SetFloat("MoveSpeed", moveParam);
    }

    private void Look(Vector2 mouseDelta)
    {
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        x = x < 180f ? Mathf.Clamp(x, -1f, 70f) : Mathf.Clamp(x, 335f, 361f);

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    private void Jump(float jump)
    {
        if (jump == 0) return;
        if (m_IsJumping) return;

        m_Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        m_IsJumping = true;
        m_Animator.SetBool("IsJump", m_IsJumping);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Untagged") && IsLocalPlayer)
        {
            m_IsJumping = false;
            m_Animator.SetBool("IsJump", m_IsJumping);
        }
    }

    public void Update()
    {
        if (!IsLocalPlayer) return;

        this.Move(m_Move);
        this.Look(m_Look);
        this.Jump(m_Jump);
    }
}
