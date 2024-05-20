using UnityEditor.Animations;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    // PoolObject를 상속받는 자식 클래스로 형변환하는 함수
    public T ReturnMyConponent<T>() where T : PoolObject
    {
        return this as T;
    }
} 