using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 diff;//ターゲットとなる距離の差
    GameObject player;//ターゲットとなるプレイヤー情報

    public float followSpeed = 8;//カメラの補間スピード

    //カメラの初期位置
    public Vector3 defaultPos = new Vector3(0, 6, -6);
    public Vector3 defaultRotate = new Vector3(12, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //カメラを変数で決めた初期位置・角度にする
        transform.position = defaultPos;
        transform.rotation = Quaternion.Euler(defaultRotate);

        //プレイヤー情報の取得
        player = GameObject.FindGameObjectWithTag("Player");
        
        //プレイヤーとカメラの距離感を記憶しておく
        diff = player.transform.position - transform.position;
    }
    private void LateUpdate()//Updateより後に働くもの
    {
        //プレイヤーが見つからなければ何もしない
        if (player == null) return;

        //線形補間を使って、カメラを目的の場所に動かす
        //Lerpメソッド（今の位置、ゴールとすべき位置、割合）
        transform.position = Vector3.Lerp(transform.position,player.transform.position - diff, followSpeed * Time.deltaTime);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
