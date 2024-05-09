using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;

    int[,] map;

    /// <summary>
    /// number �𓮂���
    /// </summary>
    /// <param name="number">����������</param>
    /// <param name="moveFrom">�ړ����C���f�b�N�X</param>
    /// <param name="moveTo">�ړ���C���f�b�N�X</param>
    /// <returns></returns>
    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }   // �����Ȃ��ꍇ�� false ��Ԃ�

        //if (map[moveTo] == 2)
        {
            // �ړ������i���Ȃ灨�A���Ȃ灩���v�Z����j
            int velocity = moveTo - moveFrom;
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            if (!success)
            {
                return false;
            }
        }   // �v���C���[�̈ړ���ɔ��������ꍇ�̏���

        // �v���C���[�E���̋��ʏ���
        //map[moveTo] = number;
        //map[moveFrom] = 0;
        return true;
    }

    int GetPlayerIndex()
    {
        //for (int i = 0; i < map.Length; i++)
        //{
        //    if (map[i] == 1)
        //    {
        //        return i;
        //    }   // ������
        //}   // ���`�T������

        return -1;  // ������Ȃ�����
    }

    void PrintArray()
    {
        string debugText = "";

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }

            debugText += "\n";
        }

        Debug.Log(debugText);
    }

    void Start()
    {
        GameObject instant = Instantiate(
            playerPrefab, new Vector3 (0,0,0), Quaternion.identity);
        map = new int[,]
        {
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
            { 0, 0, 1, 0, 1, 0, 0, 2, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 2, 0, 0, 1, 0, 2, 0, 0, 0 },
        };

        PrintArray();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = GetPlayerIndex();
            MoveNumber(1, playerIndex, playerIndex + 1);    // ���Ɉړ�
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = GetPlayerIndex();
            MoveNumber(1, playerIndex, playerIndex - 1);    // ���Ɉړ�
            PrintArray();
        }
    }
}