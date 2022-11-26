#第二次考核笔记
---
##C++模板笔记

* 模板就是建立通用的模具，提高代码的复用性
* 模板是一个框架，不能直接使用
* C++提供两种模板：函数模板和类模板
   * 函数模板：建立一个通用函数，其返回值类型和形参类型不具体定义，可以用一个虚拟的类型来代替
   
```C++
//函数模板
template<typename T>
void Swap(T& a, T& b)
{
    T temp;
    temp = a;
    a = b;
    b = temp;
}

//类模板
template<class NameType, class AgeType>
class People
{
private:
    NameType name;
    AgeType age;
public:
    People(NameType Name, AgeType Age)
    {
        this->name = Name;
        this->age = Age;
    }

    void ShowPeople()
    {
        cout << "姓名：" << this->name << endl;
        cout << "年龄：" << this->age << endl;
    }
};

void test01()
{
    int a, b;
    cin >> a >> b;
    //自动类型推导
    Swap(a, b);

    //显示指定类型
    Swap<int>(a, b);

}

void test02()
{
    string a;
    cin >> a;
    int b;
    cin >> b;
    //类模板没有自动类型推导的方式
    People <string, int>K(a, b);
    K.ShowPeople();
}

int main()
{
    test01();
    test02();
}

```
---
##C#初级编程笔记
* **Awake和Start**
  Awake在Start之前调用，可以用于在开始和初始化之前进行设,Start在初始化之后进行调用，注意，Awake和Sta在一个MonoBehavior生命周期中都只会调用一次。
* **FixUpdate**
  FixUpdate会以固定的时间间隔调用，在FixUpdate调用后会立刻进行任何物理效果相关的计算，所以任何有关刚体组件的脚本内容都应该写在FixUpdate里
* **.enable启用或禁用组件**
  ```
  using UnityEngine;
  using System.Collections;

  public class EnableComponents : MonoBehaviour
  {
    private Light myLight;

    void Start ()
    {
        myLight = GetComponent<Light>();
    }

    void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
  }
  ```
* **线性插值**
  在两个值之间进行线性插值，主要是通过Lerf函数实现
  1. 取4和3之间的50%
  `float result = Mathf.Lerp (3f, 5f, 0.5f);`
  2. Lerp 函数的其他示例包括 Color.Lerp 和 Vector3.Lerp
    ```
    Vector3 from = new Vector3 (1f, 2f, 3f);
    Vector3 to = new Vector3 (5f, 6f, 7f);

    // 此处 result = (4, 5, 6)
    Vector3 result = Vector3.Lerp (from, to, 0.75f);
    ```
    3. 在某些情况下，可使用 Lerp 函数使值随时间平滑
     ```
     void Update ()
    {
        light.intensity = Mathf.Lerp(light.intensity, 8f, 0.5f * Time.deltaTime);
    }
     ```
* **OnMouseDown**
  检测碰撞体或 GUI 元素上的鼠标点击
* **GetComponent**
  GetComponent函数通常用来取得其他脚本或组件的属性，需要注意的是，GetComponent函数会占用大量的处理能力，最好只在Awake和Start里使用
  ```
  using UnityEngine;
  using System.Collections;

  public class UsingOtherComponents : MonoBehaviour
  {
    public GameObject otherGameObject;
    
    
    private AnotherScript anotherScript;
    private YetAnotherScript yetAnotherScript;
    private BoxCollider boxCol;
    
    
    void Awake ()
    {
        anotherScript = GetComponent<AnotherScript>();
        yetAnotherScript = otherGameObject.GetComponent<YetAnotherScript>();
        boxCol = otherGameObject.GetComponent<BoxCollider>();
    }
    
    
    void Start ()
    {
        boxCol.size = new Vector3(3,3,3);
        Debug.Log("The player's score is " + anotherScript.playerScore);
        Debug.Log("The player has died " + yetAnotherScript.numberOfPlayerDeaths + " times");
    }
  ```
* **枚举类型**
  ```
  using UnityEngine;
  using System.Collections;

  public class EnumScript : MonoBehaviour 
  {
    //枚举类型的定义
    enum Direction {North, East, South, West};

        void Start () 
    {
        Direction myDirection;
        
        myDirection = Direction.North;
    }
    
    Direction ReverseDirection (Direction dir)
    {
        if(dir == Direction.North)
            dir = Direction.South;
        else if(dir == Direction.South)
            dir = Direction.North;
        else if(dir == Direction.East)
            dir = Direction.West;
        else if(dir == Direction.West)
            dir = Direction.East;
        
        return dir;     
    }
  }

  ```
    

  
---
##MonoBehavior生命周期笔记
* **调用顺序：**
  加载第一个场景
  Editor
  在第一次帧更新之前
  帧之间
  更新顺序
  动画更新循环
  渲染
  协程
  销毁对象时
  退出时
* （这个笔记我也不知道怎么写，反正看是都看了一遍，复制过来又太麻烦了 XD）
---
##思考题
1. Buff移除相关功能代码
* Player脚本中相关代码
```
 public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
        buff.OnAdd();
       
    }

    public void RemoveBuff(Buff buff)
    {
        //从列表中移除buff实例，并调用该buff的OnRemove
        buff.OnRemove();
        buffs.Remove(buff);

    }

    public void ReFresh()
    {
        for (int i = 0; i < buffs.Count; i++)
        {
            buffs[i].OnUpdate();
        }
    }

    private void Update()
    {
        //每帧跟踪Buff状况
        ReFresh();
    }
```
* SpeedBuff脚本中相关代码
```
public override void OnRemove()
    {
        base.OnRemove();
        m_Player.Speed -= DeltaSpeed;
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(TimeDate>m_Length)
        {
            m_Player.RemoveBuff(this);
        }
        //在Buff基类中添加了TimeDate计数器
        TimeDate += Time.deltaTime;
    }
```
2. HpBuff相关代码
```
public class HpBuff: Buff //继承于Buff类 而不是默认的 MonoBehaviour 类
{
    public float ChangeHp = 10f; //生命值的改变量
    //构造函数传参（话说加血扣血什么的应该没有时间限制吧。。。但如果是暂时增加血量上限什么的应该是有的。。。）
    public HpBuff(Player player, BuffKind buffKind, float length) : base(player, buffKind, length) { } 
    public override void OnAdd() //重写父类OnAdd()函数
    {
        base.OnAdd(); 
        m_Player.Hp += ChangeHp; //加血就加，扣血就减
    }
}
```

---
##几个回答
1. **自我介绍**
   大家好，我是来自物联网2201的陈万奇，很高兴能加入工作室，也很期待将来自己能拿出什么样的作品。
2. **最喜欢的游戏类型和一款游戏以及原因**
   我比较喜欢的还是卡牌和肉鸽，尤其是DBG，最喜欢的是杀戮尖塔，也是我steam目前游戏时长最长的一款游戏，原因其实很简单，肉鸽卡牌可以很好的将策略性和可控随机性结合在一起。
3. **回答Unity中有哪些生命周期函数，它们各自在什么时候调用**
   见上方笔记
4. **你本周的基础知识学习笔记**
5. 见上方笔记
---
