namespace hud {
  using entities;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class EventLog : MonoBehaviour {

    Queue<string> log = new Queue<string>();
    string text = "";

    public int maxLines = 10;
    public int textAreaHeight = 300;
    public int textAreaWidth = 150;

    void OnGUI() {
      GUI.Label(
          new Rect(
            Screen.width - textAreaWidth,
            0f, 
            textAreaWidth, 
            textAreaHeight), 
          text, 
          GUI.skin.textArea);
    }

    private void addEvent(string eventString) {
      if (log.Count >= maxLines) log.Dequeue();
      log.Enqueue(eventString);

      text = "";

      foreach (string logEvent in log)
        text += (logEvent + "\n");
    }

    public void logAttack(
        string attackerName, 
        string targetName, 
        string animationName) {
      this.addEvent("Entity " + attackerName + " attacked " + targetName + " with animation " + animationName);
    }

    public void logMovement(
        string name,
        Direction direction) {
      this.addEvent("Entity " + name + " moved " + direction);
    }

    public void logAlert(string msg) {
      this.addEvent(msg);
    }
  }
}
