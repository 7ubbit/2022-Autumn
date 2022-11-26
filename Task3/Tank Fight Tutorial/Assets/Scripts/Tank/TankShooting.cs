using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 坦克攻击类(已给出部分代码,需补充)
/// </summary>
public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;              //区分玩家
    public Rigidbody m_Shell;                   //子弹的刚体，用来实例化
    public Transform m_FireTransform;           //子弹发射位置
    public Slider m_AimSlider;                  //蓄力条
    public AudioSource m_ShootingAudio;         //音效组件
    public AudioClip m_ChargingClip;            //蓄力音效
    public AudioClip m_FireClip;                //发射音效
    public float m_MinLaunchForce = 15f;        //最小发射力
    public float m_MaxLaunchForce = 30f;        //最大发射力
    public float m_MaxChargeTime = 0.75f;       //最大蓄力时间

    /*
    private string m_FireButton;                //发射按键
    private float m_CurrentLaunchForce;         //当前发射力
    private float m_ChargeSpeed;                //发射力的增加速度
    private bool m_Fired;                       //是否子弹已被发射


    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }
    */

    private void Update()
    {
        //跟踪发射按钮的当前状态，并根据当前发射力量做出决定。
    }


    private void Fire()
    {
        //实例化并启动子弹。
    }
}