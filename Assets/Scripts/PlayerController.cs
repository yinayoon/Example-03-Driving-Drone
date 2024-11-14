using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("- Float")]
    public float moveSpeed = 10f; // 이동 속도
    public float rotationSpeed = 100f; // 회전 속도
    public float tiltAmount = 15f; // 기울기 정도
    public float tiltSmoothSpeed = 5f; // 기울기 부드러움 정도

    [Header("- string")]
    public string stopColliderTag = "Stop"; // 충돌 시 제한할 Collider의 태그

    [Header("- AudioClip")]
    public AudioClip coinSound; // 코인 충돌 시 재생할 소리
    public AudioClip moveSound; // 방향키 입력 시 재생할 소리

    // Private
    private AudioSource audioSource; // AudioSource 컴포넌트 참조
    private Vector3 currentTilt; // 현재 기울기 상태
    private Vector3 collisionNormal; // 충돌 표면의 방향
    private bool isColliding = false; // 충돌 상태 플래그   

    // Static
    public static int CoinCount = 0; // 획득한 코인 개수 (static)

    void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // 이동 입력 처리
        float moveVertical = Input.GetAxis("Vertical"); // W, S 입력
        float moveHorizontal = Input.GetAxis("Horizontal"); // A, D 입력
        float moveUpDown = 0f;

        if (Input.GetKey(KeyCode.E)) // 위로 상승
        {
            moveUpDown = 1f;
        }
        else if (Input.GetKey(KeyCode.Q)) // 아래로 하강
        {
            moveUpDown = -1f;
        }

        // 방향키 입력에 따른 소리 처리
        if (moveVertical != 0 || moveHorizontal != 0 || moveUpDown != 0)
        {
            PlayMoveSound();
        }
        else
        {
            StopMoveSound();
        }

        Vector3 moveDirection = transform.forward * moveVertical + transform.right * moveHorizontal + Vector3.up * moveUpDown;

        if (isColliding)
        {
            // 충돌 상태에서는 충돌 표면에 수직인 이동을 제한
            moveDirection = Vector3.ProjectOnPlane(moveDirection, collisionNormal).normalized * moveSpeed * Time.deltaTime;
        }
        else
        {            
            moveDirection *= moveSpeed * Time.deltaTime; // 일반 이동
        }
                
        transform.Translate(moveDirection, Space.World); // 이동        
        transform.Rotate(0, moveHorizontal * rotationSpeed * Time.deltaTime, 0); // 회전

        // 기울기 계산
        float targetTiltX = -moveVertical * tiltAmount; // 전진/후진 시 기울기
        float targetTiltZ = moveHorizontal * tiltAmount; // 좌우 이동 시 기울기

        // 현재 기울기를 목표 기울기로 보간
        currentTilt.x = Mathf.Lerp(currentTilt.x, targetTiltX, Time.deltaTime * tiltSmoothSpeed);
        currentTilt.z = Mathf.Lerp(currentTilt.z, targetTiltZ, Time.deltaTime * tiltSmoothSpeed);
                
        transform.localRotation = Quaternion.Euler(currentTilt.x, transform.localRotation.eulerAngles.y, currentTilt.z); // 기울기 적용
    }

    void PlayMoveSound()
    {
        // 움직임 소리 재생
        if (moveSound != null && !audioSource.isPlaying)
        {
            audioSource.clip = moveSound;
            audioSource.loop = true; // 반복 재생
            audioSource.Play();
        }
    }

    void StopMoveSound()
    {
        // 움직임 소리 중지
        if (audioSource.isPlaying && audioSource.clip == moveSound)
        {
            audioSource.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag(stopColliderTag)) // 충돌한 오브젝트가 특정 태그를 가질 경우
        {
            isColliding = true; // 충돌 상태 활성화
            collisionNormal = collision.contacts[0].normal; // 충돌 표면의 법선 벡터 저장
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 충돌 종료 시 이동 제한 해제
        if (collision.gameObject.CompareTag(stopColliderTag))
        {
            isColliding = false; // 충돌 상태 비활성화
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 "Coin" 태그를 가지고 있을 경우
        if (other.CompareTag("Coin"))
        {
            CoinCount++; // 코인 개수 증가            
            if (coinSound != null) { audioSource.PlayOneShot(coinSound); } // 코인 충돌 소리 재생
            Destroy(other.gameObject); // 코인 오브젝트 제거
        }
    }
}