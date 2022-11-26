using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 坦克生命值类(已给出部分代码,需补充)
/// </summary>
public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;               //每个坦克开始时的生命值
    public Slider m_Slider;                             //血量的滑块
    public Image m_FillImage;                           //滑块的图像组件
    public Color m_FullHealthColor = Color.green;       //血量满时 颜色为绿
    public Color m_ZeroHealthColor = Color.red;         //血量为0时 颜色为红
    public GameObject m_ExplosionPrefab;                //预制件，将在Awake时实例化，然后在坦克死亡时使用
    /*
    private AudioSource m_ExplosionAudio;               //爆炸音效
    private ParticleSystem m_ExplosionParticles;        //当坦克被摧毁时，粒子系统会发挥作用。
    private float m_CurrentHealth;                      //坦克目前的健康水平。
    private bool m_Dead;                                //判断坦克是否被摧毁     

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }
    */

    public void TakeDamage(float amount)
    {
        //调整坦克的当前健康状况，根据新健康状况更新UI并检查坦克是否已死亡。
    }


    private void SetHealthUI()
    {
        // 调整滑块的值和颜色。
    }


    private void OnDeath()
    {
        // 发挥坦克死亡的影响并将其停用。
    }
}