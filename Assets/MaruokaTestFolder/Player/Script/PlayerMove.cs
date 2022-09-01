using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動を制御するクラス。
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    //<======== メンバー変数 ･ プロパティ ========>//
    // ***** 使用する他コンポーネント ***** //
    Rigidbody _rigidbody;
    Quaternion _targetRotation;

    // ***** 移動に直接的に関わる値 ***** //
    [Header("移動速度"), SerializeField] float _moveSpeed = 5f;
    /// <summary> プレイヤーの移動速度 </summary>
    public float MoveSpeed { get => _moveSpeed; }
    [Header("ジャンプ力"), SerializeField] float _jumpPower = 10f;

    // ***** 接地判定関連 ***** //
    [Header("接地判定のオフセット"), SerializeField] Vector3 _groundCheckPos_Offset;
    [Header("接地判定用キューブのサイズ"), SerializeField] Vector3 _groundCheck_Size;
    [Header("接地判定レイヤーマスク"), SerializeField] LayerMask _groundCheck_LayerMask;
    [Header("回転制限"), SerializeField] float _rotationSpeed;

    // ***** デバッグ関連 ***** //
    /// <summary> ギズモを表示するかどうか </summary>
    [Header("デバッグ用ギズモを表示するかどうか"), SerializeField] bool _isGizmo;
    [Header("デバッグ用Gizmoの色"), SerializeField] Color _gizmoColor;

    // ***** 入力値 ***** //
    float _inputV = 0f;
    float _inputH = 0f;
    bool _isDash = false;

    //<===== Unityメッセージ =====>//
    void Start()
    {
        Initialized();
    }
    void Update()
    {
        Input_Move();
        Update_Move();
    }
    void OnDrawGizmos()
    {
        if (_isGizmo)
        {
            //接地判定範囲をSceneビューに描画する。
            Gizmos.DrawCube(transform.position + _groundCheckPos_Offset, _groundCheck_Size);
        }
    }

    //<===== privateメンバー関数 =====>//
    /// <summary> 初期化処理 </summary>
    /// <returns> 初期化に成功したら true を返す。 </returns>
    bool Initialized()
    {
        //コンポーネントを取得
        _rigidbody = GetComponent<Rigidbody>();
        //その他設定
        Gizmos.color = _gizmoColor;
        _targetRotation = transform.rotation;

        return true;
    }

    /// <summary> 入力処理 </summary>
    void Input_Move()
    {
        //入力ベクトルを取得
        _inputV = Input.GetAxisRaw("Vertical");
        _inputH = Input.GetAxisRaw("Horizontal");
        //ダッシュキーの入力を取得
        _isDash = Input.GetButton("Dash");
    }

    /// <summary> 移動処理 </summary>
    void Update_Move()
    {
        float speed = 0f;
        Vector3 newVelocity = new Vector3(_inputH, 0, _inputV).normalized;

        //　メインカメラを基準に方向を決める。
        newVelocity = Camera.main.transform.TransformDirection(newVelocity);
        // 移動方向を向く
        if (newVelocity.magnitude > 0.5f)
        {
            _targetRotation = Quaternion.LookRotation(newVelocity, Vector3.up);
            speed = _isDash ? 2 : 1;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        //速度を与える
        newVelocity.y = 0;
        _rigidbody.velocity = newVelocity * _moveSpeed + Vector3.up * _rigidbody.velocity.y * speed;

        // ジャンプ処理
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

    //<===== publicメンバー関数 =====>//
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
}
