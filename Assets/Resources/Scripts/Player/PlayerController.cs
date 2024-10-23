using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 2f;  // ����������� �������� ��� "������" ������
    [SerializeField] private float gravity = -9.81f; // ���� ����������
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;

    [Header("��������� ������")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float upperLookLimit = 80f;
    [SerializeField] private float lowerLookLimit = -80f;

    private float cameraPitch = 0f;
    private Vector3 velocity; // �������� �������
    private bool isGrounded; // ��������, �� ����� �� �����

    private void Start()
    {
        // ��������� � �������� ������
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // �������� �� �����
        GroundCheck();

        // ��������� �������� ������
        HandleMouseLook();

        // ��������� �������� ������
        HandleMovement();

        // ���������� ����������
        ApplyGravity();
    }

    private void GroundCheck()
    {
        // ���������, �������� �� ����� �����
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // ���� �� ����� � ������, ���������� �������� �������
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ������� ������������� ��������, ����� �������������, ��� ����� �������� �����
        }
    }

    private void HandleMouseLook()
    {
        // �������� ���� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ������� ������ �����-����
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, lowerLookLimit, upperLookLimit);
        playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

        // ������� ������ �����-������
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        // �������� ���� ��� �������� �� ����
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // ������� ������ �������� ������������ ����������� ������
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // ���������� �������� ����� CharacterController
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        // ��������� ����������
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
