using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera; // 주 카메라
    public RectTransform[] imageTransforms; // 이미지 RectTransform 배열
    public float transitionDuration = 1.0f; // 이미지 전환 시간
    public float delayBeforeSceneChange = 5.0f; // 씬 전환 전 대기 시간
    public string nextSceneName; // 다음 씬으로 이동할 씬 이름
    public AnimationCurve transitionCurve; // 애니메이션 곡선

    private int currentImageIndex = 0;
    private float transitionProgress = 0.0f;
    private Vector3 startCameraPosition;
    private Vector3 endCameraPosition;
    private float delayTimer = 0.0f;
    private bool isDelayingSceneChange = false;

    void Start()
    {
        // 처음 이미지들 비활성화
        for (int i = 1; i < imageTransforms.Length; i++)
        {
            imageTransforms[i].gameObject.SetActive(false);
        }

        if (transitionCurve == null)
        {
            transitionCurve = new AnimationCurve(
                new Keyframe(0, 0),
                new Keyframe(0.5f, 1),
                new Keyframe(1, 0)
            );
        }

        // 초기 카메라 위치 설정
        startCameraPosition = mainCamera.transform.position;
        endCameraPosition = GetCameraPositionForImage(currentImageIndex);
    }

    void Update()
    {
        if (currentImageIndex < imageTransforms.Length - 1)
        {
            transitionProgress += Time.deltaTime / transitionDuration;

            if (transitionProgress >= 1.0f)
            {
                transitionProgress = 0.0f;
                imageTransforms[currentImageIndex].gameObject.SetActive(false);
                currentImageIndex++;
                imageTransforms[currentImageIndex].gameObject.SetActive(true);
                startCameraPosition = mainCamera.transform.position;
                endCameraPosition = GetCameraPositionForImage(currentImageIndex);
            }

            float curveValue = transitionCurve.Evaluate(transitionProgress);
            mainCamera.transform.position = Vector3.Lerp(startCameraPosition, endCameraPosition, curveValue);
        }
        else
        {
            // 이미지 전환이 완료되면 씬 전환 대기
            delayTimer += Time.deltaTime;
            if (delayTimer >= delayBeforeSceneChange && !isDelayingSceneChange)
            {
                isDelayingSceneChange = true;
                StartCoroutine(LoadNextScene());
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextSceneName); // nextSceneName 씬으로 씬 이동
    }

    Vector3 GetCameraPositionForImage(int index)
    {
        // 이미지 위치로 카메라 이동
        Vector3 imagePosition = imageTransforms[index].position;
        return new Vector3(imagePosition.x, imagePosition.y, mainCamera.transform.position.z);
    }
}
