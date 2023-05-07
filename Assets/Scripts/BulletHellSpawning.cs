using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSpawning : MonoBehaviour
{
    public ParticleSystem system;

    // Particle System Configurations
    public int number_of_columns;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    public float angle;
    public Material material;
    public float spin_speed;
    public float time;
    public float lastEmit;
    public Light lightPrefab;

    // World Bounds
    public static Vector2 worldBoundary;
    public float boundaryX;
    public float boundaryY;
    public Vector2 SpawnPoint;
    public float elapsedTime = 0;
    public bool isMoving = false;

    // Enemy Stats
    public int enemyHealth = 5;

    private void Awake() {
        worldBoundary = Camera.main.ScreenToWorldPoint( new Vector2( Screen.width, Screen.height ));
        boundaryX = worldBoundary.x;
        boundaryY = worldBoundary.y;
    }

    private void Start() {
        Spawn(new Vector2(SpawnPoint.x , SpawnPoint.y));
    }

    private void FixedUpdate() {
        //horizontalPingPong(5, "right");
        emit();
        //rotationalMovement();

        if (!isMoving && this.transform.position.x != 5)
             StartCoroutine(move(new Vector2Int(5, 5), 10.0f));
    }

    public void Spawn(Vector2 startPoint){
        // Simple particle material
        Material particleMaterial = material;
        transform.position = new Vector3(startPoint.x, startPoint.y, 0);
        
        for(int i = 0; i < number_of_columns; ++i) {
            //  Instantiation of the Particle System Object
            var go = new GameObject("Particle System");
            if(number_of_columns == 1 )  go.transform.Rotate(angle, 90, 0); // Rotates so the system emits upwards
            else go.transform.Rotate(angle * i, 90, 0);
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;

            var mainModule = system.main;
            mainModule.startColor = color;
            mainModule.startSize = size;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 1000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            if(number_of_columns == 1)
                mainModule.startRotation = ((angle) + 90) * Mathf.Deg2Rad;
            else
                mainModule.startRotation = ((angle * i) + 90) * Mathf.Deg2Rad;

            var emission = system.emission;
            emission.enabled = false;
            
            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Sprite;
            forma.sprite = null;

            var _light = system.lights;
            _light.light = lightPrefab;
            _light.enabled = true;

            var collisions = system.collision;
            collisions.enabled = true;
            collisions.type = ParticleSystemCollisionType.World;
            collisions.mode = ParticleSystemCollisionMode.Collision2D; 
            collisions.bounce = 0;
            collisions.lifetimeLoss = 1;
            collisions.sendCollisionMessages = true;
            collisions.collidesWith = LayerMask.GetMask("Player");
            
            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
        }

        
    }

    public void DoEmit() {
        foreach(Transform child in transform){
            system = child.GetComponent<ParticleSystem>();

            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;
            system.Emit(emitParams, 1);

            system.Play();
        }
    }

    public void emit() {
        lastEmit += Time.fixedDeltaTime;
        if(lastEmit >= firerate) {
            DoEmit();
            lastEmit = 0; 
        }
    }

    public IEnumerator move(Vector2Int direction, float travelTime)
    {
        elapsedTime = 0;
        Vector2 startingPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPos = new Vector2(transform.position.x, transform.position.y) + direction;
        isMoving = true;

        while(elapsedTime < travelTime) {
            transform.position = Vector2.Lerp(startingPos, targetPos, elapsedTime / travelTime);
            elapsedTime +=  Time.deltaTime;
            yield return null;
        }
        
        transform.position = targetPos;

        isMoving = false;
    }

    public void horizontalPingPong(float length, string direction) {
        Vector3 pos = transform.position;
        pos.x = (direction == "right") ? Mathf.PingPong(Time.time,  length) : -Mathf.PingPong(Time.time,  length);
        transform.position = pos;
    }

    public void verticalPingPong(float length, string direction) {
        Vector3 pos = transform.position;
        pos.y = (direction == "up") ? Mathf.PingPong(Time.time, length) + SpawnPoint.y : - (Mathf.PingPong(Time.time, length) - SpawnPoint.y);
        transform.position = pos;
    }

    void OnParticleCollision(GameObject other)
    {
        if(other.name == "playerParticleSystem") { enemyHealth--; }
    }

    public void rotationalMovement() { transform.rotation = Quaternion.Euler(0, 0, Time.time * spin_speed); }
}
