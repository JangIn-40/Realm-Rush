using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    // MonoBehaviour을 상속을 안함으로써 유니티의 게임 오브젝트로 부착할수없음 
    // 순수하게 그저 게임데이터임 
    // public또한 unity에서는 주의해야하나 순수c#에서는 그냥 기능임
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node coonectTo;

    // 순수 c#에서는 constructor 즉 생성자를 추가한다. constructor는 method와 비슷하나 굉장히 큰 차이점이 있다
    // 그것은 매소드이름은 클래스 이름과 같다는 것이다.
    // new키워드가 뒤에 올것이 생성자라는것을 나타낸다.
    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}
