using UnityEngine;
// Gemaakt door Boy

public class Healthbar : MonoBehaviour {

	[SerializeField] private Texture2D hpBar;
	[SerializeField] private Texture2D hbBackground;
	[SerializeField] private Texture2D hpOverlay;
	
    private enemyScript enemyHealth;
    private float maxHealth = 0.0f;
	private Vector2 position;

	void Start() {
        enemyHealth = GetComponent<enemyScript>();
        if (enemyHealth != null) {
            maxHealth = enemyHealth.hp;
        }
	}
	
	void Update() {
		position = Camera.main.WorldToScreenPoint(transform.position);
	}

	void OnGUI() {
    	GUI.DrawTexture(new Rect(position.x - 45, (Screen.height - position.y) + (35), hbBackground.width / 7, hbBackground.height / 5), hbBackground);
        GUI.DrawTexture(new Rect(position.x - 40, ((Screen.height - position.y) + (35) + 1), (hpBar.width / 7) / (maxHealth / enemyHealth.hp), hpBar.height / 5), hpBar);
        GUI.DrawTexture(new Rect(position.x - 45, ((Screen.height - position.y) + (35)), hpOverlay.width / 7, hpOverlay.height / 5), hpOverlay);
	}
}
