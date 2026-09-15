using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //プレイヤーの移動入力値を保存する変数(x:左右方向 y:前後方向)
    private Vector2 moveInput;

    //プレイヤーの移動速度（1秒あたりの移動距離）
    [SerializeField] private float moveSpeed = 0.5f;

    public void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Move()
    {
        //入力値から移動ベクトルを計算
        //moveInput.x が左右の移動、moveInput.y が前後の移動に対応
        //y 軸は水平移動のため常に 0（上下の移動は行わない）
        //moveSpeed を掛けることで速度を調整
        //Time.deltaTime を掛けることでフレームレートに依存しない移動
        Vector3 move = new Vector3(moveInput.x,0,moveInput.y) * moveSpeed * Time.deltaTime;

        // 計算された移動ベクトル分、プレイヤーオブジェクトをワールド空間内で移動する
        transform.Translate(move, Space.World);
    }
}
