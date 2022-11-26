using UnityEngine;
/// <summary>
/// 坦克移动类(已给出部分代码,需补充)
/// </summary>
public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;              //区分玩家
    public float m_Speed = 12f;                 //移动速度
    public float m_TurnSpeed = 180f;            //转向速度
    public AudioSource m_MovementAudio;         //音效组件
    public AudioClip m_EngineIdling;            //坦克待机音效
    public AudioClip m_EngineDriving;           //坦克运行音效
    public float m_PitchRange = 0.2f;           //发动机噪音的螺距可能变化的量。
    /*
    private string m_MovementAxisName;          //前进和后退的输入轴的名称。
    private string m_TurnAxisName;              //旋转的输入轴的名称。
    private Rigidbody m_Rigidbody;              //移动Tank的引用
    private float m_MovementInputValue;         //移动输入的当前值。
    private float m_TurnInputValue;             //转向输入的当前值。
    private float m_OriginalPitch;              //场景开始时音频源的音高。
    private ParticleSystem[] m_particleSystems; //引用坦克使用的所有粒子系统 下方没有提供粒子相关代码 可自学尝试添加


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;

        m_OriginalPitch = m_MovementAudio.pitch;
    }
    */

    private void Update()
    {
        // 存储玩家的输入并确保引擎的音频正在播放。
    }


    private void EngineAudio()
    {
        // 根据坦克是否在移动以及当前正在播放哪种音频，播放正确的音频剪辑。
    }


    private void FixedUpdate()
    {
        // 移动并转动坦克。
    }


    private void Move()
    {
        // 根据玩家的输入调整坦克的位置。
    }


    private void Turn()
    {
        // 根据玩家的输入调整坦克的旋转。
    }
}