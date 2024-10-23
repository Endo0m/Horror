using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 2f;  // Уменьшенная скорость для "легкой" ходьбы
    [SerializeField] private float gravity = -9.81f; // Сила гравитации
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;

    [Header("Настройки камеры")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float upperLookLimit = 80f;
    [SerializeField] private float lowerLookLimit = -80f;

    private float cameraPitch = 0f;
    private Vector3 velocity; // Скорость падения
    private bool isGrounded; // Проверка, на земле ли игрок

    private void Start()
    {
        // Блокируем и скрываем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Проверка на землю
        GroundCheck();

        // Обработка вращения камеры
        HandleMouseLook();

        // Обработка движения игрока
        HandleMovement();

        // Применение гравитации
        ApplyGravity();
    }

    private void GroundCheck()
    {
        // Проверяем, касается ли игрок земли
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // Если на земле и падаем, сбрасываем скорость падения
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Немного отрицательное значение, чтобы гарантировать, что игрок касается земли
        }
    }

    private void HandleMouseLook()
    {
        // Получаем ввод мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Вращаем камеру вверх-вниз
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, lowerLookLimit, upperLookLimit);
        playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

        // Вращаем игрока влево-вправо
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        // Получаем ввод для движения по осям
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Создаем вектор движения относительно направления игрока
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Применение движения через CharacterController
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        // Применяем гравитацию
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
