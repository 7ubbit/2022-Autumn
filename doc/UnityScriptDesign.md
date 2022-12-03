<!-- title: Gamecore 2022 -->
``` C#
///<summary>
/// Gamecore 2022
/// By 7ubbti and KevinChang
/// Originally Written in November 17, 2022
///<summary>
```    
       
        
# 关于Unity游戏开发中的脚本设计引子
## 前言
* 当你看到这篇引子的时候，相信你已经完成了第一次考核，并且成功做出了一款拥有自己创意的Roll-A-Ball游戏，作为你们的学长，我也是这么过来的，因为没有基础，一定很多地方都是似懂非懂的，于是便想写下了这篇引子，引导大家去思考，去进步，去学习。
* 你们已经懂得了如何将C#脚本与游戏场景中的对象产生联系与交互(_通过将脚本挂载给游戏对象并拖拽引用_),那么不知大家在开发Roll-A-Ball时是否有遇到诸如此类的问题：
    > 1.不同脚本中的 __变量/参数/函数__ 之间无法互相 __传递/调用__     
    > 2.假设有多个不同种类的拾取物时，需要重复写不同拾取物的功能代码     
    > 3.游戏场景中的对象(_玩家对象和拾取物对象_)无法用脚本统一的控制生成和销毁      
    > 4.Player脚本负责处理的功能太多以至于内容冗杂    
    > .......          
* __我们常说软件开发就是算法+数据结构，而大家有没有思考过为何要研究算法和数据结构？__
* 如果说初阶程序员写脚本只是为了实现功能，那么高阶程序员在写脚本时不仅仅只关注于脚本功能的实现，更重要的是 __脚本(代码)的性能(_内存占用/运行效率_)以及代码的可维护性(_方便后期维护更新_)__ ，安全性等。
* 也许大家会觉得 “__刚开始就在意这么复杂的东西，只要实现功能就好__” ，没错前提是你有成为游戏策划的想法，而作为程序员，论功能其实别的程序员也可以实现，那你如何脱颖而出呢？脚本设计的重要性不言而喻。
## 引子
### 关于Unity中不同脚本间的交互 
* 说到前言中的第一个问题，在Unity中不同脚本之间的交互有以下几种方法：
#### 方法一:
* 通过在编辑器里面拖动，来持有这个对象去调用对应的函数，此方法比较简单。
* 在编辑器中新建2个脚本。
``` C#
public class Ascript : MonoBehaviour {
    public int value = 1; //Ascript类内部变量
    public void DoSomething()
    {
        Debug.Log("Ascript doing!"); //在Unity控制台中显示"Ascript doing!"
    }
}
```
* 我们想用Main脚本去调用Ascript脚本。我们就在Main脚本中声明一个Ascript脚本的对象。
``` C#
public Ascript ascript;
```
* 这样在代码编写的时候已经可以调用A对象中的任何 __public__ 变量和函数(公开出去的成员才能被外部类调用)。
* 现在在Main脚本中有如下内容：
``` C#
public class Main : MonoBehaviour {
    public Ascript ascript;
    private int Mvalue;
    public void DoASomething()
    {   
        //ascript.DoSomething(); 此时若直接这样运行，将报错，因为此时ascript为空引用,程序并不知道是哪个脚本。
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
``` 
* 现在我们要对它赋值,这个时候我们在编辑器拖一个有Ascript脚本的实体对象给Main脚本的ascript就可以了。
     
#### 方法二：
* 直接使用SendMessage()方法,可在Unity API中查看此方法，此方法比较简单。
* 我们把上面的直接调用改成
``` C#
public class Main : MonoBehaviour {
    public Ascript ascript;
    public void DoASomething()
    {   
        //if(ascript != null) ascript.DoSomething();
        if(ascript != null) ascript.SendMessage("DoSomething"); //思考此方法的含义 输出：Ascript doing!
    }
    void Start()
    {
        DoASomething(); //游戏开始时调用
    }
}
```
* 此时我们把Ascript脚本里面的DoSomething函数的public去掉:
``` C#
public class Ascript : MonoBehaviour {
    void DoSomething() //默认为private
    {
        Debug.Log("Ascript doing!"); //在Unity控制台中显示"Ascript doing!"
    }
}
```
* __思考运行结果，或自己运行试试？__

* 到这里，相信各位已经慢慢地对脚本之间的关系有了一定的理解了，那么现在补充一点，如何Ascript内容是这样的会发生什么？
``` C#
public class Ascript : MonoBehaviour {
    void DoSomething() //默认为private
    {
        Debug.Log("Ascript doing!"); //在Unity控制台中显示"Ascript doing!"
    }
    void DoSomething(int value)
    {
        Debug.Log(string.Format("{0} {1}","Ascript doing",value));
    }
}
```
* 举这个例子只是想告诉大家，其实在开发实践中，很容易产生一些问题或者想法，大可一试，然后看看运行结果，你就会比别人多一点经验。
* 这里也就不卖关子了 测试结果是谁在上面谁就会被调用(可以理解成按顺序)。    
      
#### 方法三：
* 现在我们将Ascript脚本的DoSomething()函数改成:
``` C#
public class Ascript : MonoBehaviour {
    public int value = 1; //Ascript类内部变量
    public static void DoSomething() //静态方法
    {
        Debug.Log("Ascript doing!"); //在Unity控制台中显示"Ascript doing!"
    }
}
``` 
* 可以发现一个新的前缀 __static__ 被放到了DoSomething()方法前
* __static__ 表示静态
    > 关于静态类和静态类成员 可以查看C#官方文档中的介绍[静态类和静态类成员(C# 编程指南)](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)      
* 现在在Main脚本中我们就可以直接使用 __Ascript.DoSomething();__ 调用：
``` C#
public class Main : MonoBehaviour {
    private int Mvalue;
    public void DoASomething()
    {   
        //Mvalue = Ascript.value; 调用Ascript的变量会报错，因为此变量不是静态变量
        Ascript.DoSomething(); //直接调用静态方法 输出 Ascript doing!
    }
    void Start()
    {
        DoASomething(); //游戏开始时调用
    }
}
``` 
* 此时你就会想如果想要Ascript.value也可以被Main调用，需要怎么样呢？
``` C#
public static int value; //Ascript类内部静态变量
```
* 答案显而易见，只需要将Ascript的value变量定义为静态变量即可使上方被注释的代码正常运行
* 同理，如果想将整个Ascript内部的所有方法或者变量全都允许被其他类调用，可以直接定义此类为静态类
     
#### 单例设计模式
* __现在让我们来探讨一些更有趣的方法__
* 我们再在上面的基础上改成如下这个样子。
``` C#
public class Ascript : MonoBehaviour {
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
```
* 我们把Main脚本中的调用改成：__Ascript.aStatic.DoSomething();__ 
``` C#
public class Main : MonoBehaviour {
    private int Mvalue;
    public void DoASomething()
    {   
        Ascript.aStatic.DoSomething(); //输出 Ascript doing!
        Mvalue = Ascript.aStatic.value; // Mvalue = 1;
        //Ascript.DoSomething(); 不再使用这种方式
    }
    void Start()
    {
        DoASomething(); //游戏开始时调用
    }
}
``` 
* __注意：我们这个时候Main脚本已经不持有Ascript这个对象了。但是场景一定要这个对象，如果没有的话会报错。如果我们场景里面有很多这个对象，他会找到这个对象最早生成的那个，注意不是你创建的实体对象而是第一个拖上这个脚本的对象。__

* 下面将此方法推广，使得即使不继承于MonoBehaviour的类也可以让其他脚本直接调用(即利用静态构造函数替代Start()方法),称此方法为单例设计模式
``` C#
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
```
* 单例模式是软件工程学中最富盛名的设计模式之一，在开发过程中十分常见，所以我们经常会使用 __泛型__ 写一个单例模式的基类，这样我们就可以通过继承该基类轻松实现单例模式，__并且不会随着场景切换而销毁__，代码如下所示：
``` C#
///<summary>
/// 单例基类
///<summary>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = (T) this;
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
```
#### 方法总结
* 第一种利用脚本互相的挂载，试想想，如果你的交互总是建立在两个或多个脚本之间，我用你的脚本实例，你用他的脚本实例，他用不知道谁的脚本实例，最后越多就越乱，到最后你自己都不想维护了，该怎么行呢？所以第一种方式是非常不推荐大家使用的。
* 第二种利用SendMessage()或者BroadcastMessage()方法，首先要注意的是此方法只能调用别的脚本的函数，并不能直接引用内部成员，其次需要介绍的是SendMessage和BroadcastMessage，是通过对对象自身底下的所有组件发送调用函数的方法，与类型无关，任意处调用，好用方便，但是问题比较明显，首先可能会通过其他组件上的名称调用某函数，抑或是根本不会采用这一方法。由于消息发送至全部组件中，因而用户无法对目标组件进行选取；其次该方法在内部依赖于反射机制，频繁使用会导致性能问题。但是如果只是个别几次，性能问题不大，而且也不需要使用静态，所以此方法可以使用，但如果频繁SendMessage就需要考虑下面的方法了。
* 第三种利用static静态成员直接调用, __但必须要清楚地是我们应该尽量避免使用静态变量__ 
    >   在Unity中，由于总是可以用各种方法找到一个对象，所以静态变量想不用，总是可以不用。比如你在根节点创建一个名为GameMode的GameObject，那么想用静态变量的地方，都可以改成非静态的扔到GameMode里面。访问的时候先找到唯一的那个GameObject对象再访问变量，用起来和静态变量区别不大。   
    >   再说关键的“对象生命周期”的问题，静态变量可以用类名直接访问，感觉写起来很方便，比如如果游戏客户端只有唯一一个玩家对象，类型为class Player，那么Player的血量就可以设计成直接用：Player.Hp 来访问。    
    >   这样写很多时候没问题，但是严格来说，__必须注意__：Player.Hp在什么时候开始可用，什么时候失效？由于Player对象肯定是在某个时刻创建，某个时刻销毁的（最晚是在游戏结束时销毁）。那么在Player创建之前、结束之后，Player.Hp是不可访问的，不应该被访问。这就是带来一个隐患：作为静态变量，Player.Hp可以随时访问，大不了读出来是0，但是原则上来讲，Player对象没有创建好的时候，Hp是不存在的。   
    >   游戏中的绝大部分物体都有这个问题，因为基本上，场景中所有对象都有着出生、死亡的时刻，包括各种管理器对象，用static静态变量，则它的语法与事实会存在出入。（因为static静态变量是绑定在类上，从逻辑上看，类比任何对象出现都早，结束都晚。哪怕一个对象都没有的时候，也已经有类了。）    
    >   这个问题在什么时候变得明显不对呢？就是不同类型的对象之间有相互依赖的时候。比如UI界面用到了任务管理器对象，Player用到了UI对象，任务管理器又在某些时候会访问Player的数据。这时候用静态变量很难理清哪个对象在什么时候能用、什么时候不能用。虽然这些对象大部分时候都不销毁，但未来项目变化的时候，东一个西一个的静态变量，就可能变成滋生BUG的温床。    
* 于是乎今天的主角就要登场了，使用 __单例设计模式__，单例有一个非常大的好处：它把以上讨论的，访问某种唯一对象的模式规范化了。规范化就意味着统一、好查。如果搞错了生命期，发现某个管理器找不到了，你就可以到创建、销毁的地方去查它，很容易就发现设计上的漏洞。当游戏中的某一个游戏对象永远只有一个实例的时候，那么就可以使用单例模式。    
    >   由于单例模式在内存中只有一个实例，减少内存开支，特别是一个对象需要频繁地创建销毁时，而且创建或销毁时性能又无法优化,单例模式就非常明显了     
    >   由于单例模式只生成一个实例，所以，减少系统的性能开销，当一个对象产生需要比较多的资源时，如读取配置，产生其他依赖对象时，则可以通过在应用启动时直接产生一个单例对象，然后永久驻留内存的方式来解决。    
    >   单例模式可以避免对资源的多重占用，例如一个写文件操作，由于只有一个实例存在内存中，避免对同一个资源文件的同时写操作       
    >   单例模式可以在系统设置全局的访问点，优化和共享资源访问，例如，可以设计一个单例类，负责所有数据表的映射处理。     
* 当然单例也并不是完美的：  
    >   单例模式一般没有接口，扩展很困难，若要扩展，除了修改代码基本上没有第二种途径可以实现。     
    >   单例对象如果持有Context，那么很容易引发内存泄漏，此时需要注意传递给单例对象的Context最好是Application Context。    
     
      
* __当然每种方法有每种方法使用的地方，不代表一成不变，所以要根据实际运用，选择合适的方法。__
 
       
### 关于面向对象编程
* 下面我们来到第二个问题，在Roll-A-Ball的开发中，大家一定都有这样的感受但凡遇到想加一个新Buff就要重新复制一边代码，简单来说就是代码的重复性太高，会很麻烦。所以下面就要跟大家介绍面向对象编程的核心。     
* 面向对象的三个特性:封装、继承、多态。对于封装(给予对象public/private/protected等修饰)，相信大家已经理解并掌握了，那么继承和多态呢？   
#### 什么是继承？
* 继承是面向对象程序设计中最重要的概念之一。 
* 借助继承，我们能够定义多个 __可重用、扩展或修改父类行为__ 的子类。   
* 已有的一个类被称为基类(父类)，而新创建的并继承于该父类的一些类被称为派生类(子类)。
* __一个父类可以有多个子类，一个子类只能有一个父类，但一个子类可以通过接口的方式实现多重继承。__
    > 如果想了解接口，可以查阅[Interface C#官方文档](https://learn.microsoft.com/zh-cn/dotnet/visual-basic/programming-guide/language-features/interfaces/)
#### 为什么要用继承？
* 继承允许我们根据一个类来定义另一个类，这使得创建和维护应用程序变得更容易。同时也有利于重用代码和节省开发时间。当创建一个类时，程序员不需要完全重新编写新的数据成员和成员函数，只需要设计一个新的类，继承了已有的类的成员即可。
#### 继承如何在Unity中体现？
* 接下来用大家已经做过的roll a ball举例说明，我们想设计小球吃方块获得相应buff，如果有多种方块，例如加Hp的方块、减Hp的方块、增加速度的方块等等，我们现在打算对每一种方块挂载一个脚本。分别命名为ChangeHpBuff,ChangeSpeedBuff...可能的实现如下：
``` C#
///<summary>
/// Player脚本
///<summary>
public class Player
{
    public float Hp;
    public float Speed;
    //.....等等玩家自身属性
    public void move()
    {
        //处理玩家移动的代码块
    }
}
///<summary>
/// 加血Buff脚本
///<summary>
public class ChangeHpBuff: MonoBehaviour {
    public GameObject player; //声明玩家对象
    public float LastingTime;//声明Buff持续时间
    public float DeltaHp;//声明Buff增加血量
    public BuffEffect()//该Buff的效果处理函数
    {
        player.GetComponent<Player>().Hp+=DeltaHp; //获取Player对象里的Player脚本组件 对其成员Hp进行增加
    }
    void OnTriggerEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            BuffEffect();
            Destroy(gameObject);
        }
    }   
    //......
}
///<summary>
/// 加速Buff脚本
///<summary>
public class ChangeSpeedBuff: MonoBehaviour {
    public GameObject player;//声明玩家对象
    public float LastingTime;//声明Buff持续时间
    public float DeltaSpeed;//声明Buff增加速度
    public BuffEffect()//该Buff的效果处理函数
    {
        player.GetComponent<Player>().Speed+=DeltaSpeed;//获取Player对象里的Player脚本组件 对其成员Speed进行增加
    }
    void OnTriggerEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            BuffEffect();
            Destroy(gameObject);
        }
    }
    //......
}
```
* 可以看到代码里每一种Buff脚本都需要重复引用player,LastingTime等等，那么这些重复的功能(代码)，虽然复制粘贴很方便，但是这实在是太繁琐了(_不够优雅_)，并且代码过于重复，不利于后期维护查阅。于是我们便可以通过继承去优化结构，节省大量时间。
* __这里要提醒大家，下面的内容可能过多的新关键词，不用着急，会慢慢跟大家解释意思。__
``` C#
///<summary>
///Buff基类 场景中不需要挂载
///<summary>
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
    //public virtual void OnRemove(){} 可以自行思考如何写Buff移除功能
}
```
* 关于 __abstract__ 即修饰为抽象类型
    > 具体资料可查阅 [abstract C#官方文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/abstract)
* 关于 __enum__ 即枚举类
    > 具体资料可查阅 [enum C#官方文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.enum?view=net-7.0)
* 关于构造函数 即在为新对象分配内存之后，new 运算符立即调用构造函数。
    > 具体资料可查阅 [构造函数 C#官方文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/using-constructors)
* 关于 __virtual__ 即被它修饰的成员，需要使它们可以在派生类中被重写
    > 具体资料可查阅 [virtual C#官方文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/virtual)
``` C#
///<summary>
///一种Buff类此处为加速Buff 场景中不需要挂载
///<summary>
public class SpeedBuff : Buff //继承于Buff类 而不是默认的 MonoBehaviour 类
{
    public float DeltaSpeed = 10f; //增加的速度
    public SpeedBuff(Player player, BuffKind buffKind, float length) : base(player, buffKind, length) { } //构造函数传参
    public override void OnAdd() //重写父类OnAdd()函数
    {
        base.OnAdd(); 
        m_Player.Speed += DeltaSpeed; //增加玩家对象的Speed
    }
}
```
* 关于 __override__ 即扩展或修改
    > 具体资料可查阅 [override C#官方文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/override)
``` C#
public class HpBuff: Buff //继承于Buff类 而不是默认的 MonoBehaviour 类
{
    //思考HpBuff类该怎么写，可以参考上方的SpeedBuff，自己尝试写写并是否能在游戏中运行
}
``` 
* 现在Buff的管理已经完成了，可以看到Buff的基类包含了每个Buff都需要作用的     
    > 1.作用的对象Player-Player       
    > 2.作用的Buff种类-BuffKind         
    > 3.作用的时长-Length      
    > 4.添加Buff的方法-OnAdd()       
* 而不需要在每个Buff类中都写，避免了重复，在每个Buff类中现在只需要定义该Buff自身的一些效果，利用构造函数传递参数，重写一下添加Buff时调用的函数OnAdd()即可。
* 那么现在该如何给玩家添加Buff呢？请看下方代码：
``` C#
public class Player : MonoBehaviour
{
    public float Speed; //移动速度
    public float Hp; //玩家血量
    //....刚体，移动等省略
    public void AddBuff(Buff buff) //定义一个添加Buff的内部函数 参数为Buff类型
    {
        buff.OnAdd();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedBuff")) //当碰到标签为 SpeedBuff 的触发对象
        {
            //....
            AddBuff(new SpeedBuff(this, Buff.BuffKind.SpeedBuff, 10f));
            ///<summary>        
            ///添加一个 SpeedBuff 作用
            ///实体为Player(this指这里的Player)      
            ///作用类型为Buff类里的枚举类型SpeedBuff       
            ///Buff持续时间为10秒       
            ///<summary>        
            //....
        }
    }
}
```
* 当然为了给大家一些*帮助*，可以看到Buff基类中定义了一个Buff持续时间，但是只有添加Buff(_OnAdd()_)的相关功能，并没有移除Buff(_OnRemove()_)的相关功能，就留给大家来做吧。
* __扩展问题：如果想要能显示玩家此时身上拥有哪些Buff，该如何实现此功能？__    
* 对传入的Buff持续时间进行处理当时间到时，执行Buff移除功能的函数，相信你可以做到的。    
#### 总结
* 通常情况下，继承用于表示基类和一个或多个派生类之间的“is a”关系，其中派生类是基类的特定版本；派生类是基类的具体类型。 例如，Publication 类表示任何类型的出版物，Book 和 Magazine 类表示出版物的具体类型。请注意，“is a”还表示类型与其特定实例化之间的关系。 在以下示例中，Automobile 类包含三个唯一只读属性：Make（汽车制造商）、Model（汽车型号）和 Year（汽车出厂年份）。 Automobile 类还有一个自变量被分配给属性值的构造函数，并将 Object.ToString 方法重写为生成唯一标识 Automobile 实例（而不是 Automobile 类）的字符串。基于继承的“is a”关系最适用于基类和向基类添加附加成员或需要基类没有的其他功能的派生类。     
       
### Unity项目架构设计与开发管理
*重点将介绍利用BuffManager管理Buff,并且推广至GameManager单例的使用以及后续复杂的Manager Of Managers，MVCS框架等*    
## 后记
* 第一次写命题如此*庞大*的引子(还没有也永远难以写完)，相比难免会有些地方有出入，还请大家谅解，__如果有发现或是说你有一些学习经验/想法都可以通过Github来提交你的更改至此文档__。
* 回想起一年前自己在默默一个人自学这些内容的时候，查阅了很多的博客、资料等，拼拼凑凑估摸出了一个大概的脚本设计思路，核心内容其实并没有理解多少(_其实今天也是如此_)，所以当我在尝试写这篇引子时，也是查阅了很多资料并且补充了很多知识，自己也算是很有收获吧。
* 当然最主要的目的还是希望通过这篇引子，能够激发我的学弟们去更好、更快地深入理解到脚本设计。
* 总之，也很感谢我的学长们，在我刚入工作室时，给予了我很大的帮助，所以也算是一种相传吧(笑)。
* 最后，希望Gamecore工作室越来越好，Respect！
## 参考资料
1. https://www.zhihu.com/question/47537779/answer/702268198
1. https://blog.csdn.net/u011550097/article/details/87253629
2. http://raylei.cn/index.php/archives/16/#http://csharpindepth.com/Articles/General/Singleton.aspx
3. https://blog.csdn.net/qq_52855744/article/details/117755154
4. https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/abstract
5. https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
6. https://learn.microsoft.com/zh-cn/dotnet/api/system.enum?view=net-7.0
7. https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/using-constructors
8. https://blog.csdn.net/qq_15020543/article/details/87826009?ops_request_misc=%257B%2522request%255Fid%2522%253A%2522166337842816782427488714%2522%252C%2522scm%2522%253A%252220140713.130102334.pc%255Fblog.%2522%257D&request_id=166337842816782427488714&biz_id=0&utm_medium=distribute.pc_search_result.none-task-blog-2~blog~first_rank_ecpm_v1~rank_v31_ecpm-2-87826009-null-null.nonecase&utm_term=buff&spm=1018.2226.3001.4450
9. https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/virtual
10. https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/override