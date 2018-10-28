using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public float score;
    public float value;
    public float health;
    public float shield;
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI shieldDisplay;
    public TextMeshProUGUI scoreDisplay;

    public ParticleSystem explosion;

    public void Start() {
        SetLabels();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DoesDamage doesDamage = collision.gameObject.GetComponent<DoesDamage>();
        if (doesDamage != null) {
            TakeDamage(doesDamage.damage, collision.gameObject.GetComponent<Stats>());
        }
    }

    public void SetLabels() {
        if (healthDisplay != null) {
            healthDisplay.text = health.ToString();
        }
        if (shieldDisplay != null) {
            shieldDisplay.text = shield.ToString();
        }
        if (scoreDisplay != null) {
            scoreDisplay.text = score.ToString();
        }
    }

    private void TakeDamage(float damage, Stats stats) {
        if (shield > damage) {
            shield -= damage;
            damage = 0f;
        } else {
            damage -= shield;
            shield = 0f;
        }
        if (health > damage) {
            health -= damage;
        } else {
            health = 0f;
            Die(stats);
        }
        SetLabels();
    }

    void Explode() {
        if (explosion == null) {
            return;
        }
        ParticleSystem ps = Instantiate(explosion, gameObject.transform.parent);
        ps.Play();
        ps.transform.position = gameObject.transform.position;
        ps.transform.rotation = gameObject.transform.rotation;
        Destroy(ps, ps.main.duration);
    }

    public void Die(Stats stats) {
        Explode();
        if (stats != null) {
            stats.score += value;
            stats.SetLabels();
        }
        Destroy(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Explode();
        }
    }
}
