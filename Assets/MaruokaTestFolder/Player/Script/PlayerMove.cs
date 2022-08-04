using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    //<======== このクラスで使用する値 ========>//
    /// <summary> ギズモを表示するかどうか </summary>
    [Header("デバッグ用ギズモを表示するかどうか"), SerializeField] bool _isGizmo;
    Rigidbody _rigidbody;
    Quaternion _targetRotation;

    //<===== インスペクタから設定すべき値 =====>//
    [Header("移動速度"), SerializeField] float _moveSpeed;
    [Header("ジャンプ力"), SerializeField] float _jumpPower;
    //=====接地判定関連=====//
    [Header("接地判定のオフセット"), SerializeField] Vector3 _groundCheckPos_Offset;
    [Header("接地判定用キューブのサイズ"), SerializeField] Vector3 _groundCheck_Size;
    [Header("接地判定レイヤーマスク"), SerializeField] LayerMask _groundCheck_LayerMask;
    [Header("回転制限"), SerializeField] float _rotationSpeed;

    //<========デバッグ関連========>//
    [Header("デバッグ用Gizmoの色"), SerializeField] Color _gizmoColor;

    //<========== プロパティ一覧 ==========>
    /// <summary> プレイヤーの移動速度 </summary>
    public float MoveSpeed { get => _moveSpeed; }

    void Start()
    {
        //コンポーネントを取得
        _rigidbody = GetComponent<Rigidbody>();
        //その他設定
        Gizmos.color = _gizmoColor;
        _targetRotation = transform.rotation;
    }

    void Update()
    {
        Move();
    }

    /// <summary> 移動処理 </summary>
    void Move()
    {
        //<====== 通常移動処理 ======>//
        //入力ベクトルを取得
        float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
        float speed = 0f;
        Vector3 newVelocity = new Vector3(inputH, 0, inputV).normalized;

        //メインカメラを基準に方向を決める。
        newVelocity = Camera.main.transform.TransformDirection(newVelocity);
        // 移動方向を向く
        if (newVelocity.magnitude > 0.5f)
        {
            _targetRotation = Quaternion.LookRotation(newVelocity, Vector3.up);
            speed = Input.GetButton("Dash") ? 2 : 1;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        //ローテーションのxとzを0に強制する
        Quaternion adjustmenta = transform.rotation;
        adjustmenta.x = 0f;
        adjustmenta.z = 0f;
        transform.rotation = adjustmenta;


        //速度を与える
        newVelocity.y = 0;
        _rigidbody.velocity = newVelocity * _moveSpeed + Vector3.up * _rigidbody.velocity.y;

        //<===== ジャンプ処理 =====>//
        if (Jump())
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.velocity = Vector3.up * _jumpPower;
        }
    }

    /// <summary> ジャンプ処理 </summary>
    /// <returns> ジャンプする場合trueを返す。そうでなければfalseを返す。 </returns>
    bool Jump()
    {
        //接地かつジャンプ入力でtrueを返す。
        if (Get_IsGround() && Input.GetButtonDown("Jump"))
        {
            return true;
        }
        return false;
    }

    /// <summary> 接地判定 </summary>
    /// <returns> 接地していればtrueを返す。そうでなければfalseを返す。 </returns>
    public bool Get_IsGround()
    {
        Vector3 overLapBoxCenter = transform.position + _groundCheckPos_Offset;
        Collider[] collision = Physics.OverlapBox(
            overLapBoxCenter,
            _groundCheck_Size,
            Quaternion.identity,
            _groundCheck_LayerMask);
        if (collision.Length != 0)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        if (_isGizmo)
        {
            //接地判定範囲をSceneビューに描画する。
            Gizmos.DrawCube(transform.position + _groundCheckPos_Offset, _groundCheck_Size);
        }
    }
}
