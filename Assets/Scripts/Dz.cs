using System;
using UnityEngine;

public class Dz : MonoBehaviour
{
    private void Start()
    {
        /*Задание 5
        int[] array = new int[15] { 5, 7, 8, 2, 1, 3, 13, 15, 11, 14, 4, 6, 9, 10, 12 };
        int[] sortArray = new int[array.Length];

        string unsorted = string.Join(", ", array);
        Debug.Log(unsorted);

        for (int i = 0; i < array.Length; i++) 
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int k = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = k;
                }
            }
        }
        string sorted = string.Join(", ", array);
        Debug.Log(sorted);*/
        

        /*Задание 4
        int[] countEnemyInWaves = new int[15] { 3, 2, 16, 7, 9, 23, 5, 2, 1, 70, 8, 5, 4, 45, 6 };

        int allEnemys = countEnemyInWaves.Sum();

        int points = 0;


        if (allEnemys > 30)
        {
            Debug.Log("Сложный уровень");
        }
        else
        {
            Debug.Log("Легкий уровень");
        }


        int countEasyWave = 0;
        int countNormalWave = 0;
        int countHardWave = 0;

        foreach (var c in countEnemyInWaves)
        {
            if (c <= 5)
            {
                countEasyWave = countEasyWave + 1;
                points = points + 1;
            }
            else if (c >= 6 && c <= 10)
            {
                countNormalWave = countNormalWave + 1;
                points = points + 2;
            }
            else if (c >= 11)
            {
                countHardWave = countHardWave + 1;
                points = points + 3;
            }
        }

        Debug.Log($"Количесво легких волн {countEasyWave}");
        Debug.Log($"Количество средних волн {countNormalWave}");
        Debug.Log($"Количество сложных волн {countHardWave}");
        Debug.Log(points);*/


        /*Задание 3
        int[] items = new int[9] {12,77,3,90,5,65,99,44,8};
        
        int sum = 0;

           foreach (int score in items)
           {
               sum += score;
           }

        Debug.Log($"Общая ценность инвенторя {sum}");


        int numberOfRareItems = 0;

        foreach (var i in items)
        {
            if (i > 70)
            {
                numberOfRareItems = numberOfRareItems + 1;
            }
        }
        Debug.Log($"Количество редких предметов {numberOfRareItems}");


        if (numberOfRareItems > 2)
        {
            Debug.Log($"Вы Богатый игрок");
        }
        else
        {
            Debug.Log($"Вы Бедный игрок");
        }*/


        /*Задание 2
        int[] enemyHealth = new int[14] {15,60,78,34,155,344,2,68,20,59,60,67,91,9};

        int max = enemyHealth[0];


        foreach (var i in enemyHealth)
        {
            if (i > max)
            {
                max = i;
            }
        }


        if (max >= 100)
        {
            Debug.Log($"Босс со здоровьем {max}");
        }
        else if (max < 50)
        {
            Debug.Log($"Обычный со здоровьем {max}");
        }
        else
        {
            Debug.Log($"Элитный со здоровьем {max}");
        }*/


        /*Задание 1

        int[] scores = new int[6] { 29, 80, 2, 13, 9, 44 };
        
        int sum = 0;

        foreach (int score in scores)
        {
            sum += score;
        }

        int middle = sum / scores.Length;


        foreach (var b in scores)
        {
            middle += b;
        }

        if (middle >= 50)
        {
            Debug.Log("Победа");
        }
        else
        {
            Debug.Log("Попробуй снова!");
        }*/
    }
}