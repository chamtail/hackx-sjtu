using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloKit;

public class GazeNextSphere : MonoBehaviour {

	public TextMesh instruction;
	public TextMesh nextText;
	public GameObject timer;
	public TextMesh timerText;

	private List<string> instructions;
	private List<float> timers;

	private int index = 0;

	// Use this for initialization
	void Start () {
		// todo
		instructions = new List<string>();
		instructions.Add ("步骤一：\n\n鸡翅洗干净，直接丢入锅里干炒，焯干水分");
		instructions.Add ("步骤二：\n\n捞出鸡翅，锅里倒油热烧，再倒入鸡翅，\n煎至表皮金黄");
		instructions.Add ("步骤三：\n\n放两个整的干辣椒，倒可乐，翻炒两分钟左右，\n差不多漫到鸡翅一半还多点的高度。\n加老抽调色以至调咸味");
		instructions.Add ("步骤四：\n\n大火煮开一分钟，煮开捞一捞浮沫");
		instructions.Add ("步骤五：\n\n关小火，熬一熬，熬入味，最后收汁，\n加一点鸡精或者味精");
		instructions.Add ("步骤六：\n\n完成");

		timers = new List<float> ();
		timers.Add (-1);
		timers.Add (-1);
		timers.Add (10);
		timers.Add (5);
		timers.Add (-1);
		timers.Add (-1);

		float timerTime = timers [index];
		bool timerActive = timerTime > 0;
		timer.GetComponent<MeshRenderer>().enabled = timerActive;
		timer.active = timerActive;
		timerText.GetComponent<MeshRenderer>().enabled = timerActive;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void GazeEnter() {
		Debug.Log("Gaze entered on " + gameObject.name);
		if (index == instructions.Count - 1) {
			return;
		}
		++index;
		instruction.text = instructions[index];
		if (index == instructions.Count - 1) {
			nextText.text = "完成";
		}
		float timerTime = timers [index];
		bool timerActive = timerTime > 0;
		timer.GetComponent<MeshRenderer>().enabled = timerActive;
		timer.active = timerActive;
		timerText.GetComponent<MeshRenderer>().enabled = timerActive;
		GetComponent<Renderer>().material.color = Color.red;
	}

	public void GazeExit() {
		Debug.Log("Gaze exit from " + gameObject.name);
		GetComponent<Renderer>().material.color = Color.white;
	}

	public void KeyDownOnGaze(HoloKitKeyCode KeyCode) {
		Debug.Log(KeyCode.ToString() +  " KeyDown while gazing on " + gameObject.name);
	}
}
