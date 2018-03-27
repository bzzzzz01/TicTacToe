##### 1.解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。
	游戏对象是指包括空对象，3D物体，2D物体，摄像机，灯光，音频，UI元素，粒子系统等的实例。
	资源则是指在游戏中用到的东西，包括对象，场景，预制，脚本，声音，图片等。
	游戏对象可以是一个资源，而资源中的脚本，声音，图片等又可以作为组件参与到游戏对象当中。

##### 2.下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）
	资源就像文件管理器中的各种文件，在Assets中有着各种不同形式的资源，这些资源可以用到游戏之中。
	游戏对象树则是显示了对象之间的从属关系。

##### 3.编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件。
	Awake 当一个脚本实例被载入时Awake被调用。
	Start Start在所有Update函数之前被调用一次。
	Update 当行为启用时，其Update在每一帧被调用。
	FixedUpdate 当行为启用时，其 FixedUpdate 在每一时间片被调用。
	LateUpdate 当行为启用时，在所有Update函数之后执行。例如：摄像机跟随。
	OnGUI 在控制脚本激活的状态下，OnGUI函数可以在每帧调用，就像Update函数一样。
	OnEnable 对象变可用或处于激活状态时 OnEnable函数被调用
	OnDisable 对象变不可用或处于非激活状态时 OnDisable函数被调用

##### 4.查找脚本手册，了解 GameObject，Transform，Component 对象。
	GameObject：所有在Unity场景中的实体的基本类
	Transform：一个对象的位置，角度和尺寸
	Component 一切东西连接到游戏对象的基本类
	table属性 游戏对象
	table的Transform属性 位置0,0,0 角度0,0,0 尺寸1*1*1
	table的部件 Transform, Mesh Filter, Box Collider, Mesh Renderer
![avatar](http://wx1.sinaimg.cn/mw690/932e8e0cgy1fprqltv1tej20jp0bmt8o.jpg)

##### 5.整理相关学习资料，编写简单代码验证以下技术的实现：
	查找对象  GameObject.Find("Name");
	添加子对象	Child.transform.parent = Parent.transform;
	遍历对象树	foreach (Transform child in grandpa){ }
	清除所有子对象	foreach(Transform child in grandpa) { Destroy(child.gameObject);}

##### 6.资源预设（Prefabs）与 对象克隆 (clone)。
	预设（Prefabs）有什么好处？
	可以将重复利用的资源快速地同时使用到各个地方。
	预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？
	预设相当于引用，对原对象地更改将会绑定地更改到各个使用预设的地方（浅复制），而克隆则是重新复制一份出来（深复制）。
	制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象
	GameObject table = Instantiate(tablePrefabs);

##### 7.尝试解释组合模式（Composite Pattern / 一种设计模式）。
	一种对象由其他几种对象组合而成，这种设计方式可以更好地表示出生活中物体的状态例如一辆车。
	是由车身，前轮12，后轮12组合而成。而不需要通过继承的方式从 物体->工具->交通工具 一层层继承下来。

##### 8.使用 BroadcastMessage() 方法向子对象发送消息。
```
public class ExampleClass : MonoBehaviour {
    void ApplyDamage(float damage) {
        print(damage);
    }
    void Example() {
        BroadcastMessage("ApplyDamage", 5.0F);
    }
}
```
