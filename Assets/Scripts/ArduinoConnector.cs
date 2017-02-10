/* ArduinoConnector by Alan Zucconi
 * http://www.alanzucconi.com/?p=2979
 */
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_STANDALONE_WIN
using System.IO.Ports;
#endif
using Random = UnityEngine.Random;
using AssemblyCSharp;

public class ArduinoConnector : MonoBehaviour {

	/* The serial port where the Arduino is connected. */
	[Tooltip("The serial port where the Arduino is connected")]
	public string port = "COM3";
	/* The baudrate of the serial port. */
	[Tooltip("The baudrate of the serial port")]
	public int baudrate = 9600;
	#if UNITY_STANDALONE_WIN
	private SerialPort stream;
	#endif
	public static Limits cameraLimits;
	public bool arduinoMode = false;

	public static string ArduinoMsg;
	// Use this for initialization
	public void Start () {
		cameraLimits = GetLimits ();
		#if UNITY_STANDALONE_WIN
		if(arduinoMode) this.Open ();
		#endif
		Debug.Log (cameraLimits.Left +","+cameraLimits.Right+","+cameraLimits.Top+","+cameraLimits.Bottom);
	}
	public void ReproduceMovie (string s) {
		ArduinoMsg = s;
		//Debug.Log (ArduinoMsg);
    }
	public void Update (){
		if (arduinoMode) {
			#if UNITY_STANDALONE_WIN
			StartCoroutine
			(
				AsynchronousReadFromArduino (
				(string s) => ReproduceMovie (s),     // Callback
				() => Debug.LogError ("Error!"), // Error callback
				10f                             // Timeout (seconds)
			)
			);
			#endif
		} else {
			if(Input.GetKeyUp(KeyCode.Space)){
				this.ReproduceMovie("PONG");
			}
		}

	}
	#if UNITY_STANDALONE_WIN
	public void Open () {
		// Opens the serial port
		stream = new SerialPort(port, baudrate);
		stream.ReadTimeout = 50;
		stream.Open();
	}
	
	public void WriteToArduino(string message)
	{
		// Send the request
		stream.WriteLine(message);
		stream.BaseStream.Flush();
	}
	
	public string ReadFromArduino(int timeout = 0)
	{
		stream.ReadTimeout = timeout;
		try
		{
			return stream.ReadLine();
		}
		catch (TimeoutException)
		{
			return null;
		}
	}
	
	
	public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
	{
		DateTime initialTime = DateTime.Now;
		DateTime nowTime;
		TimeSpan diff = default(TimeSpan);
		
		string dataString = null;
		
		do
		{
			// A single read attempt
			try
			{
				dataString = stream.ReadLine();
			}
			catch (TimeoutException)
			{
				dataString = null;
			}
			
			if (dataString != null)
			{
				callback(dataString);
				yield return null;
			} else
				yield return new WaitForSeconds(0.05f);
			
			nowTime = DateTime.Now;
			diff = nowTime - initialTime;
			
		} while (diff.Milliseconds < timeout);
		

		yield return null;
	}
	
	public void Close()
	{
		stream.Close();
	}
	#endif
	private Limits GetLimits()
	{
		var val=new Limits();

		float screenAspect = (float)Screen.width / (float)Screen.height;
		float cameraHeight = Camera.main.orthographicSize * 2;
		Bounds bounds = new Bounds(
			Camera.main.transform.position,
			new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
		val.Left = bounds.min.x;//lowerLeft.x + 5f;
		val.Right = bounds.max.x;// - 5f;
		val.Top = bounds.max.y;//upperRight.y - 5f;
		val.Bottom = bounds.min.y;//lowerLeft.y + 5f;
		return val;
	}
}