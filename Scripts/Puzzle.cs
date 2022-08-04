using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;

    public NumberBox[,] boxes = new NumberBox[4, 4];

    public Sprite[] sprites;
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
            for(int x = 0; x < 4; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                n++;
            }
    }
    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x,y);
        int dy = getDy(x,y);

        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];

        //두 상자를 바꾸는
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        //2 박스 위치 업데이트
        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x , y);
    }
    
    int getDx(int x, int y)
    {
        //오른쪽이 비어있는
        if(x<3 && boxes[x + 1, y].IsEmpty())
            return 1;
        //왼쪽이 비어있는
        if (x > 0 && boxes[x + -1, y].IsEmpty())
            return -1;

        return 0;

        }

    int getDy(int x, int y)
    {
        //위가 비어있는
        if (y < 3 && boxes[x, y + 1].IsEmpty())
            return 1;
        //아래가 비어있는
        if (y > 0 && boxes[x , y - 1].IsEmpty())
            return -1;

        return 0;

    }
}
