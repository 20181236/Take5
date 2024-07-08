using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera; // �� ī�޶�
    public RectTransform[] imageTransforms; // �̹��� RectTransform �迭
    public float transitionDuration = 1.0f; // �̹��� ��ȯ �ð�
    public float delayBeforeSceneChange = 5.0f; // �� ��ȯ �� ��� �ð�
    public string nextSceneName; // ���� ������ �̵��� �� �̸�
    public AnimationCurve transitionCurve; // �ִϸ��̼� �

    private int currentImageIndex = 0;
    private float transitionProgress = 0.0f;
    private Vector3 startCameraPosition;
    private Vector3 endCameraPosition;
    private float delayTimer = 0.0f;
    private bool isDelayingSceneChange = false;

    void Start()
    {
        // ó�� �̹����� ��Ȱ��ȭ
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

        // �ʱ� ī�޶� ��ġ ����
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
            // �̹��� ��ȯ�� �Ϸ�Ǹ� �� ��ȯ ���
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
        SceneManager.LoadScene(nextSceneName); // nextSceneName ������ �� �̵�
    }

    Vector3 GetCameraPositionForImage(int index)
    {
        // �̹��� ��ġ�� ī�޶� �̵�
        Vector3 imagePosition = imageTransforms[index].position;
        return new Vector3(imagePosition.x, imagePosition.y, mainCamera.transform.position.z);
    }
}
