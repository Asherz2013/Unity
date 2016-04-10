using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public static int m_breakableCount = 0;

    public AudioClip crack;
    public Sprite[] m_hitSprites;
    public GameObject Smoke;

    private int maxHits;
    private int timesHit;
    private LevelManager m_levelManager;
    private bool isBreakable;
    
    // Use this for initialization
    void Start ()
    {
        m_levelManager = FindObjectOfType<LevelManager>();
        timesHit = 0;
        maxHits = m_hitSprites.Length + 1;
        
        isBreakable = (tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable) m_breakableCount++;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // After applying a tag to the "Breakable" bricks
        // This is how we check it.
        if(isBreakable) HandleHits();
    }

    void HandleHits()
    {
        timesHit++;
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.5f);
        if (timesHit >= maxHits)
        {
            m_breakableCount--;
            m_levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else LoadSprites();
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(Smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        // Apply the new "broken" image
        if (m_hitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = m_hitSprites[spriteIndex];
        }
        else Debug.LogError("Missing sprite: " + spriteIndex);
    }
}
