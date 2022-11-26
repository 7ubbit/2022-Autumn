using UnityEngine;
/// <summary>
/// 子弹逻辑(已给出定义,需补充)
/// </summary>
public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;                            //用于过滤爆炸的影响，这应该设置为“Player”。详细请查看遮罩(Mask)在Unity中的运用
    public ParticleSystem m_ExplosionParticles;             //引用将在爆炸中发挥作用的粒子。
    public AudioSource m_ExplosionAudio;                    //引用将在爆炸时播放的音频。
    public float m_MaxDamage = 100f;                        //如果爆炸集中在坦克上，所造成的破坏量。
    public float m_ExplosionForce = 1000f;                  //在爆炸中心加到坦克上的力。
    public float m_MaxLifeTime = 2f;                        //删除子弹之前的时间(以秒为单位)。
    public float m_ExplosionRadius = 5f;                    //子弹爆炸半径。

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime); // 子弹达到最大时长销毁自身
    }


    private void OnTriggerEnter(Collider other)
    {
        //找到炮弹周围区域的所有坦克并将其摧毁
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        //根据目标的位置计算目标返回应该受到的伤害
        return 0f;
    }
}