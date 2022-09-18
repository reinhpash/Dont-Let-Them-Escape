using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class HeroAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform curWaypoint;
    public GameObject[] waypoints;
    int currentWP = 0;
    float accuracy = .8f;
    [SerializeField] private SkinnedMeshRenderer meshRenderer;
    public Material[] mats;
    public Animator anim;

    public int level = 1;

    public float maxHealth = 1;
    private float currentHealth;

    private void Start()
    {
        waypoints = FindObsWithTag("WayPoint");
        curWaypoint = waypoints[currentWP].transform;
        agent.SetDestination(waypoints[currentWP].transform.position);
        agent.speed = Random.Range(1.5f, 3f);
        meshRenderer.material = mats[Random.Range(0, mats.Length - 1)];
        anim = this.GetComponent<Animator>();
        anim.SetBool("Run", true);
        CheckLevel();
        SetScale(agent.gameObject.transform.localScale);

        currentHealth = maxHealth;

    }

    private void SetScale(Vector3 scale)
    {
        if (maxHealth == 1)
        {
            agent.gameObject.transform.localScale = scale;
        }
        else if (maxHealth == 2)
        {
            agent.gameObject.transform.localScale = scale * 1.5f;
        }
        else if (maxHealth == 3)
        {
            agent.gameObject.transform.localScale = scale * 2f;
        }
    }

    private void CheckLevel()
    {
        if (level == 1)
        {
            maxHealth = 1;
        }
        else if (level == 2)
        {
            maxHealth = 2;
        }
        else if (level == 3)
        {
            maxHealth = 3;
        }
        else
        {
            maxHealth = 1;
        }
    }

    private void Update()
    {
        SetPath();
    }

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
    }

    void SetPath()
    {
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position, agent.gameObject.transform.position) < accuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        agent.SetDestination(waypoints[currentWP].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && other.GetComponent<Collider>().isTrigger == true)
        {
            ParticleManager.Instance.PlayExploadeEffect(agent.gameObject.transform.position, meshRenderer.material);
            TakeDamage(other.GetComponent<DamageAmount>().damageAmount);
        }
    }


    private GameObject[] FindObsWithTag(string tag)
    {
        GameObject[] foundObs = GameObject.FindGameObjectsWithTag(tag);
        Array.Sort(foundObs, CompareObNames);
        return foundObs;
    }

    void TakeDamage(float i)
    {
        currentHealth -= i;

        if (currentHealth <= 0)
        {
            var obj = GameObject.FindGameObjectWithTag("HeroSpawner");
            if (obj.GetComponent<HeroSpawner>().heroList.Contains(this.transform.parent.gameObject))
                obj.GetComponent<HeroSpawner>().heroList.Remove(this.transform.parent.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }


    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }
}
