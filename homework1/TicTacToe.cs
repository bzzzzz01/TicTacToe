using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TicTacToe : MonoBehaviour
{

    private int turn = 0;   //0:O turn, 1:X turn
    private int[,] matrix = new int[3, 3];  //0:space, 1:O, 2:X
    private int middle = Screen.width / 2; //screen middle x

    void Start()
    {
        reset();
    }

    void reset()
    {
        turn = 0;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                matrix[i, j] = 0;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(middle - 40, 280, 80, 40), "Reset"))
            reset();
        if (GUI.Button(new Rect(middle - 40, 240, 80, 40), "AI step"))
            AIStep();
        if (ifOver())
        {
            if (turn == 0)
                GUI.Label(new Rect(middle - 20, 200, 80, 40), "X win!");
            else
                GUI.Label(new Rect(middle - 20, 200, 80, 40), "O win!");
        }

        //change the matrix
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix[i, j] == 1)
                    GUI.Button(new Rect(i * 50 + middle - 75, j * 50 + 30, 50, 50), "O");
                if (matrix[i, j] == 2)
                    GUI.Button(new Rect(i * 50 + middle - 75, j * 50 + 30, 50, 50), "X");

                if (GUI.Button(new Rect(i * 50 + middle - 75, j * 50 + 30, 50, 50), " "))
                {
                    if (!ifOver())
                    {
                        matrix[i, j] = turn + 1;
                        turn = 1 - turn;
                    }
                }
            }
        }
    }

    void AIStep()
    {
        if (!ifOver())
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = turn + 1;
                        if (ifOver())
                        {
                            matrix[i, j] = turn + 1;
                            turn = 1 - turn;
                            return;
                        }   //I can win

                        matrix[i, j] = 2 - turn;
                        if (ifOver())
                        {
                            matrix[i, j] = turn + 1;
                            turn = 1 - turn;
                            return;
                        }   //He can win

                        matrix[i, j] = 0;
                    }

                }
            }

            int x, y;
            if (matrix[1, 1] == 0)
            {
                matrix[1, 1] = turn + 1;
                turn = 1 - turn;
            }   //middle first
            else if (matrix[0, 0] == 0 || matrix[0, 2] == 0 || matrix[2, 0] == 0 || matrix[2, 2] == 0)
            {
                do
                {
                    x = 2 * Random.Range(0, 2);
                    y = 2 * Random.Range(0, 2);
                } while (matrix[x, y] != 0);
                matrix[x, y] = turn + 1;
                turn = 1 - turn;
            }   //corner second
            else if (matrix[0, 1] == 0 || matrix[1, 0] == 0 || matrix[1, 2] == 0 || matrix[2, 1] == 0)
            {
                do
                {
                    x = Random.Range(0, 2);
                    y = x + 1;
                    if (Random.Range(0, 2) == 0)
                    {
                        int t = x;
                        x = y;
                        y = t;
                    }
                } while (matrix[x, y] != 0);
                matrix[x, y] = turn + 1;
                turn = 1 - turn;
            }   //side last
        }
    }

    bool ifOver()
    {
        if (matrix[0, 0] != 0 && matrix[0, 0] == matrix[0, 1] && matrix[0, 0] == matrix[0, 2]
         || matrix[1, 0] != 0 && matrix[1, 0] == matrix[1, 1] && matrix[1, 0] == matrix[1, 2]
         || matrix[2, 0] != 0 && matrix[2, 0] == matrix[2, 1] && matrix[2, 0] == matrix[2, 2]   //row

         || matrix[0, 0] != 0 && matrix[0, 0] == matrix[1, 0] && matrix[0, 0] == matrix[2, 0]
         || matrix[0, 1] != 0 && matrix[0, 1] == matrix[1, 1] && matrix[0, 1] == matrix[2, 1]
         || matrix[0, 2] != 0 && matrix[0, 2] == matrix[1, 2] && matrix[0, 2] == matrix[2, 2]   //column

         || matrix[0, 0] != 0 && matrix[0, 0] == matrix[1, 1] && matrix[0, 0] == matrix[2, 2]
         || matrix[0, 2] != 0 && matrix[0, 2] == matrix[1, 1] && matrix[0, 2] == matrix[2, 0])  //diagonal
            return true;
        return false;
    }
}
