using UnityEngine;
using System.Collections;//这两个头文件写unity脚本必带

public class ExampleBehaviourScript//文件名 : MonoBehaviour
{
    
    void Start()//程序开始时执行一次
    {
        rb = GetComponent<Rigidbody>();//获得刚体
    }
    void Update()
    {
         MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;// 监听鼠标事件wasd
    }
    void FixedUpdate()
    {
        rb.AddForce(MoveDir * moveSpeed);//实现移动，AddForce是推力
    }
}
-----------------------------------------------------------------------------------------
public class ForeachLoop : MonoBehaviour //foreach循环
{   
    void Start () 
    {
        string[] strings = new string[3];
        
        strings[0] = "First string";
        strings[1] = "Second string";
        strings[2] = "Third string";
        
        foreach(string item in strings)//若符合条件自动加一
        {
            print (item);
        }
    }
}
-------------------------------------------------------------------------------------------
public class Example:MonoBehaviour
{
    public int a;//开放，可以在unity内修改
    private int b;//私有，需在脚本内修改
    void Start()
    {
        myOtherClass = new AnotherClass();//获得AnotherClass的实例
        myOtherClass.FruitMachine(alpha, myOtherClass.apples);//可以调用AnotherClass中开放的FruitMachine函数
    }
}//如果其他脚本需要调用，开放，否则私有
public class AnotherClass
{
    public int apples;
    public int bananas;

    public void FruitMachine (int a, int b)
    {
        int answer;
        answer = a + b;
        Debug.Log("Fruit total: " + answer);
    }
}
-------------------------------------------
void Awake ()
    {
        Debug.Log("Awake called.");
    }//脚本未被调用时也可以运行
    
    
    void Start ()
    {
        Debug.Log("Start called.");
    }//脚本调用时运行
//两个生命周期内只调用一次
---------------------------------------------------------
    vector = player.transform.position - enemy.transform.position;//方向向量，由enemy指向player
//各个分量分别除以magnitude模长就等于单位向量
    float a = player.transform.position.magnitude;//magnitude可以计算player相对于（0,0,0）的距离
     计算公式: 单位长度：（1,1,1）
     Vector v1= new Vector(2,2,3);
     v1= new Vector(v1.x/v1.magnitude,v1.y/v1.magnitude,v1.z/v1.magnitude); //单位化向量之后
------------------------------------------------------
  点乘：
     Vector A(a,b,c)
     Vector B(x,y,z)
     AB的点积 m=(a*x)+(b*y)+(c*z)=A*B

     点乘的几何意义：
     得到B在A上投影的长度

     点乘的大致方位：
     m>0:锐角
     m=0:直角
     m<0:钝角

     点乘用途：
     可以判断对象的方位；
    可以计算两个向量之间的夹角;
--------------------------------------------
public class EnableComponents : MonoBehaviour
{
    private Light myLight;
    
    
    void Start ()
    {
        myLight = GetComponent<Light>();//启用组件
    }
}
----------------------------------












unity生命周期说明
public class ExampleBehaviourScript : MonoBehaviour
{
    void Awake()//在任何start函数之前执行
    {

    }
     private void OnEnable()//启用对象后立即调用，可用于加载关卡或有脚本的游戏对象
    {
        
    }
    private void OnLevelWasLoaded(int level)//可告知游戏已加载新关卡
    {
        
    }


    void OnApplicationPause()//帧的结尾调用
    {

    }




    void Update()//每帧调用一次，受电脑帧数影响，放需要实时调用的函数，放多了会卡顿
    {

    }
    void FixedUpdate()//一秒调用五十次，次数稳定
    {

    }
    void LateUpdate()//每帧调用一次，在Update之后，通常用于第三人称跟随相机
    {

    }
}
-------------------------------------------
调用其他脚本函数的方法：
1.
//A脚本
public class Ascript : MonoBehaviour 
{
    public int value = 1; //Ascript类内部变量
    public void DoSomething()
    {
        Debug.Log("Ascript doing!"); //在Unity控制台中显示"Ascript doing!"
    }
}
//B脚本
public class Main : MonoBehaviour 
{
    public Ascript ascript;//要调用A脚本，必须先定义
    private int Mvalue;
    public void DoASomething()
    {   
        
        if(ascript != null) //加上一个判断，使程序更安全，如果为空了，就不执行此代码。
        {
            Mvalue = ascript.value; //Mvalue = 1;
            ascript.DoSomething(); //输出 Ascript doing!
        }
    }
    void Start()
    {
        DoASomething(); //游戏开始时调用
    }
}
创建一个空对象，挂载A脚本，再将该空对象拖至B脚本的ascript中
法2：
public class Main : MonoBehaviour 
{
    public Ascript ascript;
    public void DoASomething()
    {   
       
        if(ascript != null) ascript.SendMessage("DoSomething");//Ascript中的DoSomething可开放可私有
    }
    void Start()
    {
        DoASomething();
    }
}

---------------------------------------------------
单例
public class Ascript : MonoBehaviour
{
    public static Ascript aStatic;
    public int value = 1;
    void Start() 
    {
        aStatic = this;
    }
    public void DoSomething()
    {
        Debug.Log("Ascript doing!");
    }
}
public class Main : MonoBehaviour {
    private int Mvalue;
    public void DoASomething()
    {   
        Ascript.aStatic.DoSomething();//调用
        Mvalue = Ascript.aStatic.value; // Mvalue = 1;
    }
    void Start()
    {
        DoASomething();
    }
}
扩展：单例设计模式
使得即使不继承于MonoBehaviour的类也可以让其他脚本直接调用
利用静态构造函数替代Start()方法
public class Singleton 
{
    public static Singleton instance;
    public static Singleton Instance
    {
        get {
            if (instance==null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
//在另一个类中使用 Singleton.Instance. 就可以调用Singleton内部的方法或者变量



public class Singleton<T> : MonoBehaviour where T : Singleton<T>//限制范类
{
    public static T Instance { get; private set; }
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = (T) this;//调用自身
            DontDestroyOnLoad(gameObject); //该实例不会随场景切换而销毁
        }
        else
        {
            Destroy(gameObject); //消除重复实例
        }
    }
}
///<summary>
/// 游戏核心管理脚本
///<summary>
public class Manager : Singleton<GameManager> //继承于单例类的Manager
{
    public int Value { get; set; } = 0;
}
//在另一个类中使用 Manager.Instance. 就可以调用Manager内部的方法或者变量
//单例在场景中只能实例一个，单例常见用在gamemanager或menumanager中，该类在场景中只存在一个
-----------------------------------------------------------



继承
public abstract class Buff //定义抽象基类Buff
{
    public enum BuffKind //定义枚举类型 Buff种类
    {
        HpBuff, //回血Buff
        SpeedBuff,//加速Buff
    }
    public float m_Length;//Buff持续时间
    public BuffKind m_BuffKind;//Buff的类型
    public Player m_Player;//作用的实体
    public Buff(Player player, BuffKind buffKind, float length)//构造函数传参 
    {
        m_Player = player; //第一个参数表示作用的实体 本例子中只有玩家 所以命名为Player 其实应该命名为实体
        m_BuffKind = buffKind; //第二个参数表示作用Buff的种类
        m_Length = length; //第三个表示该Buff持续的时间
    }
    public virtual void OnAdd() { }//添加Buff的虚函数
}
--------------------------------------------------




