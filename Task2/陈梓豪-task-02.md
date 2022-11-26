##第二次考核

###1.自我介绍

姓名：陈梓豪
性别：男
籍贯：贵州贵阳
专业：智能科学与技术

###2.我喜欢的游戏
魔兽争霸3：这是一款即时战略类（RTS）的游戏，也是我除了flash页游之外接触的第一款游戏。作为一款由那个时代的暴雪所推出的游戏，他的剧情和游戏玩法放到现在都无疑是数一数二的，他把“划时代”三个字展现得淋漓尽致。但因为RTS独有的强对抗性和学习门槛，让他在操作更加简单的Dota和LOL等游戏出现后便消失在了主流玩家的视野中。我很高兴能够接触魔兽争霸3，能够接触暴雪，是他为我打开了游戏世界的大门，让我能够欣赏门后世界的风景。

###3.生命周期

####场景开始时：
 **Awake**:始终在任何 Start 函数之前并在实例化预制件之后调用此函数。（如果游戏对象在启动期间处于非活动状态，则在激活之后才会调用 Awake。）
**OnEnable**：（仅在对象处于激活状态时调用）在启用对象后立即调用此函数。
**OnLevelWasLoaded**：执行此函数可告知游戏已加载新关卡。
**注意**，对于添加到场景中的对象，在为任何对象调用 Start 和 Update 等函数之前，会为_所有_脚本调用 Awake 和 OnEnable 函数。当然，在游戏运行过程中实例化对象时，不能强制执行此调用。
####编辑时：
**Reset**：调用 Reset 可以在脚本首次附加到对象时以及使用 Reset 命令时初始化脚本的属性。
在第一次帧更新之前：
**tart**：仅当启用脚本实例后，才会在第一次帧更新之前调用 Start。
对于添加到场景中的对象，在为任何脚本调用 Update 等函数之前，将在所有脚本上调用 Start 函数。
####帧之间：
**OnApplicationPause**：在帧的结尾处调用此函数（在正常帧更新之间有效检测到暂停）。
注：在调用 OnApplicationPause 之后，将发出一个额外帧，从而允许游戏显示图形来指示暂停状态。
####更新顺序：
**FixedUpdate**：调用 FixedUpdate 的频度常常超过 Update。如果帧率很低，可以每帧调用该函数多次；如果帧率很高，可能在帧之间完全不调用该函数。
注：在 FixedUpdate 之后将立即进行所有物理计算和更新。在 FixedUpdate 内应用运动计算时，无需将值乘以 Time.deltaTime。这是因为 FixedUpdate 的调用基于可靠的计时器（独立于帧率）。
**Update**：每帧调用一次 Update。这是用于帧更新的主要函数。
**LateUpdate**：在Update完成后调用LateUpdate
####动画更新循环：
**OnStateMachineEnter**：在状态机更新 (State Machine Update) 步骤中，当控制器的状态机进行流经 Entry 状态的转换时，将在第一个更新帧上调用此回调。在转换到 StateMachine 子状态时不会调用此回调。
**OnStateMachineExit**：在状态机更新 (State Machine Update) 步骤中，当控制器的状态机进行流经 Exit 状态的转换时，将在最后一个更新帧上调用此回调。在转换到 StateMachine 子状态时不会调用此回调。
仅当动画图中存在控制器组件（例如，
**AnimatorController**（动画控制器，通过具有状态机（由参数控制）的层来控制动画。）、**AnimatorOverrideController**（用于控制动画器重写控制器的接口。） 或 **AnimatorControllerPlayable**（用于控制动画 **RuntimeAnimatorController**（使用此表示可在运行时期间更改 Animator Controller。）。））时才会发生此回调。
注意：将此回调添加到 StateMachineBehaviour（一个可添加到状态机状态的组件。它是一个基类，所有状态脚本都派生自该类。） 组件会禁用多线程的状态机评估。
触发动画事件 (**Fire Animation Events**)：调用在上次更新时间和当前更新时间之间采样的所有剪辑中的所有动画事件。
**StateMachineBehaviour (OnStateEnter/OnStateUpdate/OnStateExit)**：一个层最多可以有 3 个活动状态：当前状态、中断状态和下一个状态。使用一个定义 OnStateEnter、OnStateUpdate 或 OnStateExit 回调的 StateMachineBehaviour 组件为每个活动状态调用此函数。依次针对当前状态、中断状态和下一个状态调用此函数。
仅当动画图中存在控制器组件（例如，AnimatorController、AnimatorOverrideController 或 AnimatorControllerPlayable）时才会执行此步骤。
**OnAnimatorMove**：在每个更新帧中为每个 Animator 组件调用一次此函数来修改根运动 (Root Motion)。
**StateMachineBehaviour(OnStateMove)**：使用定义此回调的 StateMachineBehaviour 在每个活动状态中调用此函数。
**OnAnimatorIK**：设置动画 IK。为每个启用 IK pass 的 Animator Controller 层进行一次此调用。仅当使用人形骨架时才会执行此事件。
**StateMachineBehaviour(OnStateIK)**：使用在启用 IK pass 的层上定义此回调的 StateMachineBehaviour 组件在每个活动状态中调用此函数。
**WriteProperties**：从主线程将所有其他动画属性写入场景。
####有用的性能分析标记：
某些动画函数不是可以调用的事件函数；它们是 Unity 处理动画时调用的内部函数。这些函数具有 Profiler 标记，因此您可以使用 Profiler 查看 Unity 在帧中调用这些函数的时间。知道 Unity 调用这些函数的时间有助于准确了解所调用的事件函数的具体执行时间。
**状态机更新 (State Machine Update)**:在执行序列的此步骤中评估所有状态机。仅当动画图中存在控制器组件（例如，AnimatorController、AnimatorOverrideController 或 AnimatorControllerPlayable）时才会发生此回调。
注意：状态机评估通常是多线程的,但添加某些回调（例如，OnStateMachineEnter 和 OnStateMachineExit）会禁用多线程。
**ProcessGraph**：评估所有动画图。此过程包括对需要评估的所有动画剪辑进行采样以及计算根运动 (Root Motion)。
**ProcessAnimation**：混合动画图的结果。
**WriteTransforms**：将所有动画变换从工作线程写入场景。
（如果一个人形骨架的多个层启用了 IK pass，则该人形骨架可以有多个 WriteTransforms 通道）
####渲染
**OnPreCull**：在摄像机剔除场景之前调用。剔除操作将确定摄像机可以看到哪些对象,并在进行剔除之前调用 OnPreCull。
**OnBecameVisible/OnBecameInvisible**：对象变为对任何摄像机可见/不可见时调用。
**OnWillRenderObject**：如果对象可见，则为每个摄像机调用一次。
**OnPreRender**：在摄像机开始渲染场景之前调用。
**OnRenderObject**：所有常规场景渲染完成之后调用。此时，可以使用 GL 类或 Graphics.DrawMeshNow 来绘制自定义几何形状。
**OnPostRender**：在摄像机完成场景渲染后调用。
**OnRenderImage**：在场景渲染完成后调用以允许对图像进行后处理，请参阅后期处理效果。
**OnGUI**：每帧调用多次以响应 GUI 事件。首先处理布局和重新绘制事件，然后为每个输入事件处理布局和键盘/鼠标事件。
**OnDrawGizmos** 用于在场景视图中绘制辅助图标以实现可视化。
####协程
Update 函数返回后将运行正常协程更新。协程是一个可暂停执行 (yield) 直到给定的 YieldInstruction 达到完成状态的函数。 协程的不同用法：
**yield**：在下一帧上调用所有 Update 函数后，协程将继续。
**yield WaitForSeconds**：在为帧调用所有 Update 函数后，在指定的时间延迟后继续协程
**yield WaitForFixedUpdate**：在所有脚本上调用所有 FixedUpdate 后继续协程
**yield WWW**：在 WWW 下载完成后继续。
**yield StartCoroutine**：将协程链接起来，并会等待 MyFunc 协程先完成。

####销毁对象时
**OnDestroy**：对象存在的最后一帧完成所有帧更新之后，调用此函数（可能应 Object.Destroy 要求或在场景关闭时销毁该对象）。

####退出时
在场景中的所有活动对象上调用以下函数：
**OnApplicationQuit**：在退出应用程序之前在所有游戏对象上调用此函数。在编辑器中，用户停止播放模式时，调用函数。
**OnDisable**：行为被禁用或处于非活动状态时，调用此函数。


## 4.学习笔记
####public变量：
```
using UnityEngine;
using System.Collections;

public class MainPlayer : MonoBehaviour 
{
   //设置变量“myName”
    public string myName;
    
    // 此函数用于初始化
    void Start () 
    {
        Debug.Log("I am alive and my name is " + myName);
    }
}
```
在 C# 中，必须将变量声明为 public 才能在 Inspector 中查看该变量。


####访问组件

组件实际上是类的实例，因此第一步是获取对需要使用的组件实例的引用。这是通过 GetComponent 函数来完成的。通常，希望将组件对象分配给变量，获得对组件实例的引用后，可以像在 Inspector 中一样设置其属性的值：
```
void Start () 
{
  //获取组件 “Rigidbody”
    Rigidbody rb =GetComponent<Rigidbody>();
    
    // 改变对象的刚体质量。
    rb.mass = 10f;
}

Inspector 中所没有的一项额外功能是可以在组件实例上调用函数：
void Start ()
{
    Rigidbody rb = GetComponent<Rigidbody>();
    
    // 向刚体添加作用力。
    rb.AddForce(Vector3.up * 10f);
   //vector3（三维向量）
}
```
另外请注意，完全可以将多个自定义脚本附加到同一对象。如果需要从一个脚本访问另一个脚本，可以像往常一样使用 GetComponent，只需使用脚本类的名称（或文件名）来指定所需的组件类型。如果尝试检索尚未实际添加到游戏对象的组件，则 GetComponent 将返回 null；如果尝试更改 null 对象上的任何值，将在运行时出现 null 引用错误（如果尝试访问被引用的对象而又没有该对象，则将出现 NullReferenceException）。

#### 将游戏对象与变量链接

查找相关游戏对象的最直接方法是向脚本添加公共的游戏对象变量，GetComponent 函数和组件访问变量与其他任何变量一样可用于此对象，因此可以使用如下代码：
```
public class Enemy : MonoBehaviour 
{
   //GameObject（Unity 场景中所有实体的基类）
    public GameObject player;
    
    void Start()
  {
        // 在玩家角色背后十个单位的位置生成敌人。
        transform.position =   player.transform.position -Vector3.forward * 10f;
    }
}
```
此外，如果在脚本中声明组件类型的公共变量，则可以拖动已附加该组件的任何游戏对象。这样可以直接访问组件而不是游戏对象本身。
```
//用于获取角色的transform组件。
public Transform playerTransform; 
```

###在运行时定位对象

####寻找子游戏对象
使一组游戏对象成为一个父游戏对象的所有子对象，使用父游戏对象的变换组件来检索子游戏对象。
```
using UnityEngine;

public class WaypointManager : MonoBehaviour
 {
    public Transform[] waypoints;
    
    void Start() 
    {
        waypoints = new Transform[transform.childCount];
        int i = 0;
        
        foreach (Transform t in transform)
        {
            waypoints[i++] = t;
        }
    }
}
```
####按名称或标签来查找游戏对象

只要有某种信息可以识别游戏对象，就可以在场景层级视图中的任何位置找到该游戏对象。可使用 GameObject.Find 函数按名称检索各个对象：
```
GameObject player;

void Start() 
{
    player = GameObject.Find("MainHeroCharacter");
}

还可以使用 GameObject.FindWithTag 和 GameObject.FindGameObjectsWithTag 函数按标签来查找对象或者对象集合：

GameObject player;
GameObject[] enemies;

void Start() 
{
    player = GameObject.FindWithTag("Player");
    enemies = GameObject.FindGameObjectsWithTag("Enemy");
}
```
###事件函数

Unity 中的脚本与传统的程序概念不同。在传统程序中，代码在循环中连续运行，直到完成任务。相反，Unity 通过调用在脚本中声明的某些函数来间歇地将控制权交给脚本。函数执行完毕后，控制权将交回 Unity。这些函数由 Unity 激活以响应游戏中发生的事件，因此称为事件函数。

####常规更新事件
**Update：**
在渲染帧之前以及计算动画之前都会调用 Update 函数（50次/秒）。
```
void Update() {
    float distance = speed * Time.deltaTime * Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * distance);
}
```
**FixedUpdate：**
物理引擎也采用与帧渲染类似的方式以离散时间步骤进行更新。在每次物理更新之前都会调用一个称为 FixedUpdate 的单独事件函数。由于物理更新和帧更新不会以相同频率进行，所以如果将物理代码放在 FixedUpdate 函数而不是 Update 中，此代码将产生更准确的结果。
```
void FixedUpdate() {
    Vector3 force = transform.forward * driveForce * Input.GetAxis("Vertical");
    rigidbody.AddForce(force);
}
```
**LateUpdate：**
在所有对象调用 Update 和 FixedUpdate 函数之后以及计算所有动画之后调用LateUpdate。
```
void LateUpdate() {
    Camera.main.transform.LookAt(target.transform);
}
```
####初始化事件
**Start：**
在第一帧之前或开始对象的物理更新之前需要调用 Start 函数。
**Awake：**
场景加载时会为场景中的每个对象调用 Awake 函数。
注：虽然各种对象的 Start 和 Awake 函数的调用顺序是任意的，但在调用第一个 Start 之前，所有 Awake 都要完成。

####GUI 事件
**OnGUI：**
Unity 有一个系统用于渲染场景中主要操作的 GUI 控件，并响应对这些控件的点击。此代码的处理方式与正常的帧更新有些不同，因此应将此代码置于定期调用的 OnGUI 函数中。
```
void OnGUI() {
    GUI.Label(labelRect, "Game Over");
}
```
此外，还可以检测场景中出现的游戏对象上发生的鼠标事件：OnMouseOver
    当鼠标悬停在 Collider （所有碰撞体的基类）上时，每帧调用一次
**OnMouseExit**
    当鼠标不再处于 Collider 上方时调用。
**OnMouseEnter**
    当鼠标停留在对象上时，调用相应的 OnMouseOver函数； 当鼠标移开时，调用 OnMouseEnter函数。
**OnMouseDown**
    当用户在 Collider 上按下鼠标按钮时，将调用OnMouseDown。

####物理事件
物理引擎将通过调用该对象的脚本上的事件函数来报告对象的碰撞情况。
**OnCollisionEnter**
     当该碰撞体/刚体已开始接触另一个刚体/碰撞体时，调用 OnCollisionEnter。
**OnCollisionStay**
     对应正在接触刚体/碰撞体的每一个碰撞体/刚体，每帧调用一次 OnCollisionStay。
**OnCollisionExit**
     当该碰撞体/刚体已停止接触另一个刚体/碰撞体时，调用 OnCollisionExit。
**OnTriggerEnter**
     GameObject 与另一个 GameObject 碰撞时，Unity 会调用 OnTriggerEnter。
**OnTriggerStay**
    对于接触触发器的每一个 Collider /other/，每次物理更新调用一次 OnTriggerStay。
**OnTriggerExit**
    当 Collider other 已停止接触该触发器时调用 OnTriggerExit。
如果在物理更新期间检测到多次接触，可能连续多次调用这些函数，因此会将一个参数传递给函数，从而提供碰撞的详细信息（位置、进入对象标识等）。
```
void OnCollisionEnter(otherObj: Collision) {
    if (otherObj.tag == "Arrow") {
        ApplyDamage(10);
    }
}
```
###时间和帧率管理
借助 Update （如果启用了 MonoBehaviour，则每帧调用 Update。）函数，可定期通过脚本监控输入和其他事件，并采取适当的操作。例如，可在按下“forward”键时移动一个角色。在处理这种基于时间的动作时要记住的一项重要规则是，游戏的帧率不是恒定的，并且 Update 函数调用之间的时间长度也不是恒定的。
举例来说，假设在一项任务中需要逐步向前移动某个对象，一次一帧。起初看起来好像可以在每帧将对象移动一个固定距离：
```
using UnityEngine;
using System.Collections;

public class ExampleScript : MonoBehaviour {
    public float distancePerFrame;
    
    void Update() {
        transform.Translate(0, 0, distancePerFrame);
    }
}
```
但是，如果帧时间不是恒定的，那么对象看起来会以不规则的速度移动。解决方案是通过可从 Time.deltaTime （完成上一帧所用的时间（以秒为单位）。
使用 Time.deltaTime 可在 y 方向以 n 单位/秒的速度移动 GameObject。将 n 乘以 Time.deltaTime，然后与 y 分量相加。）属性读取的帧时间来缩放移动距离大小：
```
using UnityEngine;
using System.Collections;

public class ExampleScript : MonoBehaviour {
    public float distancePerSecond;
    
    void Update() {
        transform.Translate(0, 0, distancePerSecond * Time.deltaTime);
    }
}
```
####固定时间步长

与主帧更新不同，Unity 的物理系统会工作到固定的时间步长，这对于模拟的准确性和一致性很重要。在物理更新开始时，Unity 通过将固定的时间步长值添加到上次物理更新结束的时间来设置“警报”时间。然后，物理系统将执行计算，直到警报响起。

####时间
对于特殊效果，例如“子弹时间”，有时减慢游戏时间的流逝会很有用，能够使动画和脚本响应以较低的速率发生。Unity 有一个 Time Scale 属性可以控制游戏时间相对于实时时间的进展速度。如果该标度设置为 1.0，则游戏时间与实时时间匹配。值为 2.0 会使 Unity 中的时间流逝速度加倍（即，动作将加速），而值为 0.5 则会将游戏速度减半。值为零将使时间完全“停止”。
注：时间标度实际上并不会降低执行速度，而只是更改了通过 Time.deltaTime 和 Time.fixedDeltaTime （执行物理和其他固定帧率更新 （如FixedUpdate）的时间间隔）报告给 Update 和 FixedUpdate 函数的时间步长。当游戏时间减慢时，调用 Update 函数的频率可能高于平常，但每帧报告的 deltaTime 步长将会缩短。
Time （（菜单：__Edit > Project Settings__，然后选择 Time_ 类别）可用于设置多个属性以控制游戏中的时序。）窗口有一个属性可用于全局设置时间标度，但使用 Time.timeScale 属性从脚本设置该值通常更有用：
```
using UnityEngine;
using System.Collections;

public class ExampleScript : MonoBehaviour {
    void Pause() {
        Time.timeScale = 0;
    }
    
    void Resume() {
        Time.timeScale = 1;
    }
}
```
**Capture Framerate**:该属性的值设置为零以外的任何值时，游戏时间将减慢，而帧更新将以精确的定期时间间隔发出。帧之间的时间间隔等于 1 / Time.captureFramerate，因此如果该值设置为 5.0，则每五分之一秒更新一次。随着对帧率的要求有效降低，在 Update 函数中便有了时间保存截屏或采取其他操作：
```
using UnityEngine;
using System.Collections;

public class ExampleScript : MonoBehaviour {
    // 捕获帧作为截屏序列。图像
    // 作为 PNG 文件存储在文件夹中 - 这些文件可通过
    //图像实用程序软件（例如，QuickTime Pro）组合成电影。
    //该文件夹将包含我们的截屏。
    //如果该文件夹存在，我们将附加数字来创建一个空文件夹。
    string folder ="ScreenshotFolder";
    int frameRate = 25;
        
    void Start () {
        // 设置回放帧率（实时时间将与此后的游戏时间不相关）。
        Time.captureFramerate = frameRate;
        
        //创建文件夹
        System.IO.Directory.CreateDirectory(folder);
    }
    
    void Update () {
        // 将文件名附加到文件夹名（格式为"0005 shot.png""）
        string name = string.Format("{0}/{1:D04} shot.png", folder, Time.frameCount );
        
        // 将截屏捕获到指定的文件。
        Application.CaptureScreenshot(name);
    }
}
```
####创建和销毁游戏对象
有些游戏在场景中保留恒定数量的对象，但是在游戏运行过程中创建和删除角色、宝藏和其他对象是很常见的做法。在 Unity 中，可以使用 Instantiate （生成）函数来创建游戏对象。该函数可以生成现有对象的新副本：
```
public GameObject enemy;

void Start() {
    for (int i = 0; i < 5; i++) {
        Instantiate(enemy);
    }
} 
```
请注意，进行复制的源对象不必存在于场景中。更常见的做法是在 Editor 中使用从 Project 面板拖动到公共变量的预制件。此外，实例化游戏对象将复制原始对象中存在的所有组件。
此外，还有一个 Destroy （销毁）函数。该函数将在帧更新完成后或选择在短时间延迟后销毁对象：
```
void OnCollisionEnter(Collision otherObj) {
    if (otherObj.gameObject.tag == "Missile") {
        Destroy(gameObject,.5f);
    }
}
```
请注意，Destroy 函数可以在不影响游戏对象本身的情况下销毁个别组件。

###协程

调用函数时，函数将运行到完成状态，然后返回。这实际上意味着在函数中发生的任何动作都必须在单帧更新内发生；函数调用不能用于包含程序性动画或随时间推移的一系列事件。
例如，假设需要逐渐减少对象的 Alpha（不透明度）值，直至对象变得完全不可见：
```
void Fade() 
{
    for (float ft = 1f; ft >= 0; ft -= 0.1f) 
    {
        Color c = renderer.material.color;
        c.a = ft;
        renderer.material.color = c;
    }
}
```
就目前而言，Fade 函数不会产生期望的效果。为了使淡入淡出过程可见，必须通过一系列帧降低 Alpha 以显示正在渲染的中间值。但是，该函数将完全在单个帧更新中执行。这种情况下，永远不会看到中间值，对象会立即消失。
可以通过向 Update 函数添加代码（此代码逐帧执行淡入淡出）来处理此类情况。但是，使用协程来执行此类任务通常会更方便。
协程就像一个函数，能够暂停执行并将控制权返还给 Unity，然后在下一帧继续执行。在 C# 中，声明协程的方式如下：
```
IEnumerator Fade() 
{
    for (float ft = 1f; ft >= 0; ft -= 0.1f) 
    {
        Color c = renderer.material.color;
        c.a = ft;
        renderer.material.color = c;
        yield return null;
    }
}
```
此协程本质上是一个用返回类型 IEnumerator 声明的函数，并在主体中的某个位置包含 yield return 语句。yield return null 行是暂停执行并随后在下一帧恢复的点。要将协程设置为运行状态，必须使用 StartCoroutine （启动协程。可以使用 yield 语句，随时暂停协程的执行。使用 yield 语句时，协程会暂停执行，并在下一帧自动恢复。）函数：
```
void Update()
{
    if (Input.GetKeyDown("f")) 
    {
        StartCoroutine("Fade");
    }
}
```
默认情况下，协程将在执行 yield 后的帧上恢复，但也可以使用 WaitForSeconds （使用缩放时间将协程执行暂停指定的秒数。）来引入时间延迟：
```
IEnumerator Fade() 
{
    for (float ft = 1f; ft >= 0; ft -= 0.1f) 
    {
        Color c = renderer.material.color;
        c.a = ft;
        renderer.material.color = c;
        yield return new WaitForSeconds(.1f);
    }
}
```
###命名空间
命名空间就是类的集合；引用集合中的类时需要在类名中使用所选的前缀，用以解决随着项目变得越来越大并且脚本数量增加，脚本类名称之间发生冲突的问题。

在下面的示例中，类 Controller1 和 Controller2 是名为 Enemy 的命名空间的成员：
```
namespace Enemy {
    public class Controller1 : MonoBehaviour {
        ...
    }
    
    public class Controller2 : MonoBehaviour {
        ...
    }
```
在代码中，这些类分别以 Enemy.Controller1 和 Enemy.Controller2 的形式引用。

通过在文件顶部添加 using 指令可避免重复输入命名空间前缀。
```
 using Enemy;
```
此行表示，在出现类名 Controller1 和 Controller2 的位置，它们应分别表示 Enemy.Controller1 和 Enemy.Controller2。如果脚本还需要引用不同命名空间中同名的类（比如说名为 Player 的命名空间），那么仍然可以使用前缀。如果同时使用 using 指令导入两个包含冲突类名的命名空间，则编译器将报错。

###5.思考作业
移除Buff
```
public abstract class Buff 
{
    public float time;
    public enum BuffKind 
    {
        HpBuff, 
        SpeedBuff,
    }
    public float m_Length;
    public BuffKind m_BuffKind;
    public Player m_Player;
    public Buff(Player player, BuffKind buffKind, float length)
        m_Player = player; 
        m_BuffKind = buffKind; 
        m_Length = length; 
    }
    public virtual void OnAdd() 
    { 

    }
    public virtual void OnRemove()
    {

    } 


    public class SpeedBuff : Buff
{
    public float DeltaSpeed= 10f;
    public SpeedBuff(Player player, BuffKind buffKind, float length) : base(player, buffKind, length) { }
    public override void OnAdd()
    {
        base.OnAdd();
        m_Player.speed += DeltaSpeed;
    }

    public override void OnRemove()
    {
        base.OnRemove();
        if ( timer>= m_Length)
            m_Player.speed -= DeltaSpeed;
        timer+=Time.deltaTime;
    }
    
}
}
```
血量回复
```
public class HpBuff : Buff 
{
    public float DeltaHp = 1f; 
    public HpBuff(Player player, BuffKind buffKind, float length) : base(player, buffKind, length) { } 
    public override void OnAdd() 
    {
        base.OnAdd(); 
        m_Player.Hp += DeltaHp; 
    }

}
```