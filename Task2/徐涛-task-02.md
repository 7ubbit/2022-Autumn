# 第二次考核任务
## C++笔记
Input.GetKeyDown(KeyCode.*)   按 * 触发事件
Denug.Log   获取游戏中任意变量的值

pubilc class DestoryBasic : MonoBehaviour/GameObject other;/class DestoryComponent : MonoBehaviour
{
    void Update()
    {
      if(Input.GetKey(KeyCode.Space))
      {
          Destory(gameObject/other/GetComponent<MeshRenderer>());
      }
    }
}

public class UsingDeltaTime : MonoBehaviour   在游戏中将其用于对值进行平滑和解释
{
    public float speed = 8f; 
    public float countdown = 3.0f;
    void Update ()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f)
            light.enabled = true;
        
         if(Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }   
}

public class InvokeScript : MonoBehaviour     可用于安排在以后的时间进行方法调用
{
    public GameObject target;
    void Start()
    {
        Invoke ("SpawnObject", 2);
    }
    void SpawnObject()
    {
        Instantiate(target, new Vector3(0, 2, 0), Quaternion.identity);
    }
}
## MonoBehavior生命周期笔记
>    Reset         在用户点击检视面板的Reset按钮或者首次添加该组件时被调用
     Awake         当一个脚本实例被载入时Awake被调用
     Start         在游戏对象开始存在时（加载场景或实例化游戏对象时）调用
     Update        每帧都会被调用    
     LateUpdate    Update后，每帧都会被调用
     FixedUpdate   每个物理时间步进调用
     OnDestroy     当MonoBehaviour将被销毁时，函数被调用
     OnTriggerXXX(Collider other)
       进入触发器 OnTriggerEnter 当Collider(碰撞体)进入trigger(触发器)时调用OnTriggerEnter。
       逗留触发器 OnTriggerStay  当碰撞体接触触发器时，OnTriggerStay将在每一帧被调用。
       退出触发器 OnTriggerExit  当Collider(碰撞体)停止触发trigger(触发器)时调用OnTriggerExit。
     OnCollisionXXX (Collision collisionInfo)
       进入碰撞 OnCollisionEnter  当此collider/rigidbody触发另一个rigidbody/collider时，OnCollisionEnter将会在开始碰撞时调用
       逗留碰撞 OnCollisionStay 当此collider/rigidbody触发另一个rigidbody/collider时，OnCollisionStay将会在每一帧被调用
       退出碰撞 OnCollisionExit 当此collider/rigidbody停止触发另一个rigidbody/collider时，OnCollisionExit将被调用
     OnMouseXXX()    
          OnMouseUp    当用户释放鼠标按钮时调用OnMouseUp。OnMouseUp只调用在按下的同一物体上。此函数在iPhone上无效
          OnMouseDown  当鼠标在Collider(碰撞体)上点击时调OnMouseDown
          OnMouseEnter 当鼠标进入到Collider(碰撞体)中时调用OnMouseEnter
          OnMouseExit  当鼠标移出Collider(碰撞体)上时调用OnMouseExit
          OnMouseOver  当鼠标悬浮在Collider(碰撞体)上时调用 OnMouseOver 
## 思考题：
思考并写出Buff移除功能相关代码(提示:public virtual void OnRemove(){})
        public virtual void GetRcover() { }// 得到状态  
        public virtual void LoseRecover() { }// 失去状态  
        AddBuff(new HpBuff(this, BuffKind.HpBuff, 10)); // 加上时长为10的HpBuff
思考并写出HpBuff的相关代码(提示:参照SpeedBuff)
``` C#
    public class HpBuff: Buff
    {
        //思考HpBuff类该怎么写，可以参考上方的SpeedBuff，自己尝试写写并是否能在游戏中运行
        //....Your Answer....
    }

    public class HpBuff : Buff
    {
        public BuffKind Kind;// Buff的类型
        public float time;// 计时器
        public float m_Length;// Buff持续时间,我们约定,Buff时间为0,则为瞬时Buff,只执行OnAdd
        public CostumEntityLogic m_CostumEntityLogic; // 所归属的实体
        public Buff(CostumEntityLogic costumEntityLogic, BuffKind buffKind, float length)
        {
            m_CostumEntityLogic = ;
            m_Length = ;
            Kind = ;
            time = ;
        }
        public virtual void OnAdd() { }// 当添加到实体时执行
        public virtual void OnUpdate() { } // 跟随实体每帧更新
        public virtual void OnRemove() { } // 当从实体移除时
    
        

```
## 回答
1. 自我介绍
   > 大家好!我是来自物联网2202的徐涛，老家是江苏无锡，很高兴来到Gamecore游戏工作室，与大家共同学习游戏开发，期待与大家共同进步，携手做出一款属于自己的好游戏<(￣︶￣)↗[GO!]    
2. 最喜欢的游戏类型和一款游戏，以及原因    
   > 我最喜欢的游戏类型是魂系游戏，最喜欢的游戏是魂三（准确来说是魂一到魂三的跨度）。我很喜欢魂系列，是魂系列的忠实玩家，不论是魂系列中与强大boss的激斗、宫崎老贼的心理陷阱还是魂味的故事，都给我留下深刻印象。
3. 回答Unity中有哪些生命周期函数，它们各自在什么时候调用
   > Reset         在用户点击检视面板的Reset按钮或者首次添加该组件时被调用
     Awake         当一个脚本实例被载入时Awake被调用
     Start         在游戏对象开始存在时（加载场景或实例化游戏对象时）调用
     Update        每帧都会被调用    
     LateUpdate    Update后，每帧都会被调用
     FixedUpdate   每个物理时间步进调用
     OnDestroy     当MonoBehaviour将被销毁时，函数被调用
     OnTriggerXXX(Collider other)
     OnCollisionXXX (Collision collisionInfo)
     OnMouseXXX()
4. 笔记和思考题
   > 见上