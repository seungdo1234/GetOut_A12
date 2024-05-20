using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 6; // 최대 체력
    private float CurrentHP; // 현재 체력
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = maxHP; //현재 체력을 최대 체력과 같게 설정
        spriteRenderer = GetComponent<SpriteRenderer>();     
    }

    public void TakeDmage(float damage)
    {
        // 현재 체력을 damage만큼 감소
        CurrentHP -= damage;

        StopCoroutine("hitcolorAnimation");
        StartCoroutine("HitcolorAnimation");

        // c체력이 0이하 = 플레이어 캐릭터 사망
        if (CurrentHP < 0)
        {
            Debug.Log("Player HP : 0..Die");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // 플레이어의 색상을 빨간색으로
        spriteRenderer.color = Color.red;
        // 0.1초 동안 대기
        yield return new WaitForSeconds(0.1f);
        // 플레이어의 색상을 원래 색상인 하얀색으로
        // (원래 색상이 하얀색이 아닐 경우 원래 색상 변수 선언)
        spriteRenderer.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
