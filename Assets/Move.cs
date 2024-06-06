using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�����炩�ɓ������@�\��񋟂���
/// </summary>
public class Move : MonoBehaviour
{
    /// <summary>�ړ��܂łɂ����鎞�ԁi�b�j</summary>
    public float duration = 0.2f;
    /// <summary>�ړ����n�߂Ă���o�߂������ԁi�b�j</summary>
    float elapsedTime;
    Vector3 destination;
    Vector3 origin;

    void Start()
    {
        destination = transform.position;
        origin = destination;
    }

    void Update()
    {
        if (transform.position == destination)
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        float timeRatio = elapsedTime / duration;

        //if (timeRatio > 1)
        //{
        //    timeRatio = 1;
        //}

        float easing = timeRatio;

        Vector3 currentPosition
            = Vector3.Lerp(origin, destination, easing);
        transform.position = currentPosition;
    }

    /// <summary>
    /// �I�u�W�F�N�g�����炩�Ɉړ�������
    /// </summary>
    /// <param name="destination">�ړI�n�̍��W</param>
    public void MoveTo(Vector3 destination)
    {
        elapsedTime = 0;
        origin = this.destination;
        // �ړ����������ꍇ�̓L�����Z�����ĖړI�Ƀ��[�v����
        transform.position = origin;
        this.destination = destination;
    }

}