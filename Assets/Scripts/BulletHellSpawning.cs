using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSpawning : MonoBehaviour
{
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
    private float lastEmit;
    public Light lightPrefab;

    public ParticleSystem system;

    private void Awake() {
        Summon();
    }

    private void Update() {
        // this.transform.Translate(0, Mathf.Sin(Time.deltaTime), 0);
    }

    private void FixedUpdate() {
        lastEmit += Time.fixedDeltaTime;
        if(lastEmit >= firerate) {
            DoEmit();
            lastEmit = 0; 
        }
    }

    // Start is called before the first frame update
    private void Summon()
    {
        // Spread of each particle emitter
        // angle = angle / number_of_columns;
        
        // Simple particle material
        Material particleMaterial = material;

        for(int i = 0; i < number_of_columns; ++i) {
            //  Instantiation of the Particle System Object
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotates so the system emits upwards
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
            
            // var text = system.textureSheetAnimation;
            // text.enabled = false;
            // text.mode = ParticleSystemAnimationMode.Sprites;
            // text.AddSprite(texture);
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
}
